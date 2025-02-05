using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
public enum tipoFinal
{
    PaisVivos,
    FugaFloresta,
    Morte
}
*/

public class ImagemFinalSelector : MonoBehaviour
{
    [SerializeField] Sprite[] imagensFinais;
    Image displayFinal;

    // Start is called before the first frame update
    void Start()
    {
        displayFinal = GetComponent<Image>();
    }

    
    public void SetImagemFinal(int final)
    {
        displayFinal.sprite = imagensFinais[final];

        /*
        //tipoFinal final = tipoFinal.FugaFloresta;
        switch (final)
        {
            case tipoFinal.PaisVivos:
                displayFinal.sprite = imagensFinais[0];
                break;
            case tipoFinal.FugaFloresta:
                displayFinal.sprite = imagensFinais[1];
                break;
            case tipoFinal.Morte:
                displayFinal.sprite = imagensFinais[2];
                break;
        }*/
    }
}
