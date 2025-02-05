using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMira : MonoBehaviour
{
    //bool para menupausa
    private bool isActive = true;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        Cursor.visible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isActive)
        {
            Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouseCursorPos;
        }
    }

    public void MiraAtiva(bool value)
    {
        Cursor.visible = !value;
        isActive = value;
        spriteRenderer.enabled = value;
    }
}

