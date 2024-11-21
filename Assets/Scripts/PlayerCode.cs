// IMPORT DAS BIBLIOTECAS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour 
{
    public float speed = 5f; // velocidade de movimento
    private Animator animator; // variável animator: Animator
    private Rigidbody2D rb; // variável rb: Rigidbodt2D

    private void Start() // executa apenas no início do jogo
    {
        animator = GetComponent<Animator>(); // define que animator é igual ao componente Animator do objeto
        rb = GetComponent<Rigidbody2D>(); // define que animator é igual ao componente Rigidbody2D do objeto
    }

    private void Update() // executa em série (atualizando)
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // define variável horizontalInput: detecta o controle (-1:esquerda, 0:idle, 1:direita)

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y); // define a velocidade do rb com base na direção

        // CONTROLE DE ANIMAÇÕES DO OBJETO
        if (horizontalInput != 0)
        {
            animator.SetInteger("transition", 1);  // transição de andar
        }
        else
        {
            animator.SetInteger("transition", 0);  // transição de idle
        }
    }
}
