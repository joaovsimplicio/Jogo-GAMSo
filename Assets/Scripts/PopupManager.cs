using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;

public class PopupManager : MonoBehaviour
{

    [SerializeField]Animator anim;
    [SerializeField]TMP_Text numtext;


    public void MostrarPopup(string info)
    {
        numtext.text = info;
        anim.Play("PopupFade");
    }

}
