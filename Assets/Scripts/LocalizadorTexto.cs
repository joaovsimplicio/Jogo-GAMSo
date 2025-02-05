using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocalizadorTexto : MonoBehaviour
{
    Text texto;
    TMP_Text tmptexto;
    [SerializeField] string strPTBR, strENG;

    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<Text>();
        tmptexto = GetComponent<TMP_Text>();

        if (texto != null)
            TrocarLinguagemTexto(Application.systemLanguage);
        if (tmptexto != null)
            TrocarLinguagemTMPro(Application.systemLanguage);
    }

    public void TrocarLinguagemTexto(SystemLanguage lang)
    {
        switch (lang)
        {
            case SystemLanguage.Portuguese:
                texto.text = strPTBR;
                break;
            case SystemLanguage.English:
                texto.text = strENG;
                break;
            default:
                texto.text = strPTBR;
                break;
        }
    }
    public void TrocarLinguagemTMPro(SystemLanguage lang)
    {
        switch (lang)
        {
            case SystemLanguage.Portuguese:
                tmptexto.text = strPTBR;
                break;
            case SystemLanguage.English:
                tmptexto.text = strENG;
                break;
            default:
                tmptexto.text = strPTBR;
                break;
        }
    }

}
