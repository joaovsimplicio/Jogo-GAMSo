using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizadorMenu : MonoBehaviour
{
    Image img;
    [SerializeField] Sprite  imgPTBR, imgENG;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

        TrocarLinguagem(Application.systemLanguage);
    }

    public void TrocarLinguagem(SystemLanguage lang)
    {
        switch (lang)
        {
            case SystemLanguage.Portuguese:
                img.sprite = imgPTBR;
                break;
            case SystemLanguage.English:
                img.sprite = imgENG;
                break;
            default:
                img.sprite = imgPTBR;
                break;
        }
    }

}
