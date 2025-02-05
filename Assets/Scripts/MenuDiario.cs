using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDiario : MonoBehaviour
{
    
    public static bool DiarioAberto = false;
    public static bool podeUsarDiario = true;
    int paginasMostraveis;

    [SerializeField] float pageSpeed = 0.1f;

    [SerializeField] List<Transform> paginas;
    [SerializeField] GameObject DiarioCanvas;
    int paginaEsquerda = -1;
    int paginaDireita = 0;
    bool paginaVirando = false;
    [SerializeField] GameObject AnteriorButton;
    [SerializeField] GameObject ProximoButton;


    public void Start()
    {
        //+3 pq a primeira, a capa e uma vazia não contam
        paginasMostraveis = PlayerStatus.instancia.paginasColetadas+3;

        Inicializar();
    }

    private void Update()
    {
        if(podeUsarDiario)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                if(DiarioAberto)
                {
                    FecharDiario();
                }
                else
                {
                    AbrirDiario();
                }
            }

            if (DiarioAberto && Input.GetKeyDown(KeyCode.Q))
            {
                PagVolta();
            }

            if (DiarioAberto && Input.GetKeyDown(KeyCode.E))
            {
                PagAvanca();
            }
        }
    }

    void AbrirDiario()
    {
        DiarioCanvas.SetActive(true);
        DiarioAberto = true;
        PlayerStatus.instancia.ToggleMovMira(false);
    }

    void FecharDiario()
    {
        DiarioCanvas.SetActive(false);
        DiarioAberto = false;
        PlayerStatus.instancia.ToggleMovMira(true);
    }


    void Inicializar()
    {
        //zera rotações das paginas, bota a primeira na grente e desativa o botão de voltar
        for (int i = 0; i < paginas.Count; i++)
        {
            paginas[i].transform.rotation = Quaternion.identity;
        }
        for (int i = 1; i < (paginas.Count-2); i++)
        {
            paginas[i].gameObject.SetActive(false);
        }
        paginas[0].SetAsLastSibling();
        AnteriorButton.SetActive(false);
    }

    public void PagAvanca()
    {
        if (paginaVirando || paginaDireita >= paginas.Count) { return; }


        do{
            paginas[paginaDireita].SetAsLastSibling();

            StartCoroutine(Rotate(true));

            paginaEsquerda++;
            paginaDireita++;

            if(paginaDireita >= paginas.Count)
            {
                break;
            }
        }while(paginas[paginaDireita].gameObject.activeInHierarchy == false);

        ProximoButtonActions();
    }

    public void PagVolta()
    {
        if (paginaVirando || paginaEsquerda < 0) { return; }

        do{
            paginas[paginaEsquerda].SetAsLastSibling();

            StartCoroutine(Rotate(false));

            paginaEsquerda--;
            paginaDireita--;

            if(paginaEsquerda < 0)
            {
                break;
            }
        }while(paginas[paginaEsquerda].gameObject.activeInHierarchy == false);

        AnteriorButtonActions();
    }

    public void ProximoButtonActions()
    {
        if (AnteriorButton.activeInHierarchy == false)
        {
            AnteriorButton.SetActive(true);
        }
        if (paginaDireita >= paginas.Count)
        {
            ProximoButton.SetActive(false);
        }
    }

    public void AnteriorButtonActions()
    {
        if (ProximoButton.activeInHierarchy == false)
        {
            ProximoButton.SetActive(true);
        }
        if (paginaEsquerda < 0)
        {
            AnteriorButton.SetActive(false);
        }
    }

    //rotacao da folha
    IEnumerator Rotate(bool avancando)
    {
        float value = 0f;
        float angulo;
        int paginaavirar;

        if (avancando)
        {
            paginaavirar = paginaDireita;
            angulo = -180f;
        }
        else
        {
            paginaavirar = paginaEsquerda;
            angulo = 0f;
        }

        //determina o angulo objetivo
        Quaternion targetRotation = Quaternion.Euler(0, angulo, 0);

        float auxAngle = Quaternion.Angle(paginas[paginaavirar].localRotation, targetRotation);

        // se o objeto nao esta ativo giramos instantaneamente
        if(paginas[paginaavirar].gameObject.activeInHierarchy)
        {
            paginaVirando = true;
            while (auxAngle >= 0.1f)
            {

                //determina o quanto vai girar a cada iteração
                value += Time.deltaTime * pageSpeed;

                //gira a pagina com slerp
                paginas[paginaavirar].localRotation = Quaternion.Slerp(paginas[paginaavirar].localRotation, targetRotation, value);

                //se o angulo entre a rotação atual e a rotação objetivo for menor que 0.1, para a rotação
                auxAngle = Quaternion.Angle(paginas[paginaavirar].localRotation, targetRotation);

                yield return null;
            }
            paginaVirando = false;
        }
        else
        {
            paginas[paginaavirar].localRotation = targetRotation;
        }
    }


    public void AtualizarPaginas(int paginasColetadas)
    {
        paginasMostraveis++;

        Debug.Log("Pagina coletada. Total de paginas coletadas: " + paginasColetadas);

        paginas[paginasColetadas].gameObject.SetActive(true);

    }
}