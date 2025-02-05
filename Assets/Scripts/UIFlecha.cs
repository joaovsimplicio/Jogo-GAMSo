using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFlecha : MonoBehaviour
{
    List<Image> FlechaHUDImages;

    public GameObject flechaIMG;
    [SerializeField]
    TMP_Text textoReload;

    // rodando no awake pq se o start do arco for antes do start do flecha, as imagens n vao estar instanciadas na tentativa de rodar o updateglechaui
    private void Start()
    {

        FlechaHUDImages = new List<Image>();
        for(int i = 0; i < PlayerStatus.instancia.totalFlechas; i++)
        {
            FlechaHUDImages.Add(Instantiate(flechaIMG, this.transform).GetComponent<Image>());
        }
        textoReload.enabled = false;
        UpdateFlechaUI(PlayerStatus.instancia.totalFlechas);
    }

    public void UpdateFlechaUI(int flechasDisponiveis)
    {
        textoReload.enabled = flechasDisponiveis == 0;
        for(int i = 0; i < PlayerStatus.instancia.totalFlechas; i++)
        {
            FlechaHUDImages[i].enabled = i < flechasDisponiveis;
        }
    }

    public void AddIMG(int flechasDisponiveis)
    {
        FlechaHUDImages.Add(Instantiate(flechaIMG, this.transform).GetComponent<Image>());
        UpdateFlechaUI(flechasDisponiveis);
    }
}
