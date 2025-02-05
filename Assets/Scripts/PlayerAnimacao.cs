using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;
//using Unity.VisualScripting;

public class PlayerAnimacao : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;
    PlayerMovimento movim;

    bool olhandoEsquerda = false;
    bool andarFrente;

    private void Start() {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        movim = GetComponent<PlayerMovimento>();
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetFloat("MOV_HORIZONTAL", Mathf.Abs(movim.inputHorizontal));
        animator.SetFloat("MOV_VERTICAL", movim.inputVertical);
        animator.SetBool("GROUNDED", movim.grounded);

        // se ta andando na mesma direção que ta olhando, anda de frente, senao de costas
        andarFrente = !(movim.inputHorizontal > 0f ^ !olhandoEsquerda);
        animator.SetBool("ANDAR_FRENTE", andarFrente);

    }

    public void VirarPlayer(bool esquerda)
    {
        olhandoEsquerda = esquerda;
        sprite.flipX = esquerda;
        //animator.SetBool("OLHA_ESQUERDA", olhandoEsquerda);
    }

    public void AnimPular()
    {
        animator.SetTrigger("PULAR");
    }
    
    public void AnimMorrer()
    {
        animator.SetTrigger("MORRER");
    }

    public void AnimSegCorda(bool segurou)
    {
        animator.SetBool("SEGURANDO_CORDA", segurou);
    }

    public void PausarAnim()
    {
        animator.speed = 0f;
    }

    public void ContinuarAnim()
    {
        animator.speed = 1f;
    }

    public void ResetAnim()
    {
        animator.Rebind();
        animator.Update(0f);
    }
}
