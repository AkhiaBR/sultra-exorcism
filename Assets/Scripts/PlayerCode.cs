// IMPORT DAS BIBLIOTECAS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour 
{
    public float speed = 5f; // velocidade de movimento
    private Animator animator; // vari�vel animator: Animator
    private Rigidbody2D rb; // vari�vel rb: Rigidbodt2D

    private void Start() // executa apenas no in�cio do jogo
    {
        animator = GetComponent<Animator>(); // define que animator � igual ao componente Animator do objeto
        rb = GetComponent<Rigidbody2D>(); // define que animator � igual ao componente Rigidbody2D do objeto
    }

    private void Update() // executa em s�rie (atualizando)
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // define vari�vel horizontalInput: detecta o controle (-1:esquerda, 0:idle, 1:direita)

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y); // define a velocidade do rb com base na dire��o

        // CONTROLE DE ANIMA��ES DO OBJETO
        if (horizontalInput != 0)
        {
            animator.SetInteger("transition", 1);  // transi��o de andar
        }
        else
        {
            animator.SetInteger("transition", 0);  // transi��o de idle
        }
    }
}
