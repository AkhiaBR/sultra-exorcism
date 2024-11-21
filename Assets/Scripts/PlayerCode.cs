// IMPORT DAS BIBLIOTECAS
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerCode : MonoBehaviour 
{
    public float speed = 5f; // velocidade de movimento
    private Animator animator; // vari�vel animator: Animator
    private Rigidbody2D rb; // vari�vel rb: Rigidbodt2D
    private bool isAttacking = false; // verifica se est� atacando

    private void Start() // executa apenas no in�cio do jogo
    {
        animator = GetComponent<Animator>(); // define que animator � igual ao componente Animator do objeto
        rb = GetComponent<Rigidbody2D>(); // define que animator � igual ao componente Rigidbody2D do objeto
    }

    private void Update() // executa em s�rie (atualizando)
    {
        // CHAMA AS FUN��ES
        Move();
        Attack();
    }

    private void Move()
    {
        if (isAttacking) return; // se mover e estiver atacando ao mesmo tempo, cancela a anima��o

        float tecla = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(tecla * speed, 0);

        if (tecla < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            animator.SetInteger("transition", 1);
        }
        else if (tecla > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            animator.SetInteger("transition", 1);
        }
        else if (tecla == 0)
        {
            animator.SetInteger("transition", 0);
        }
    }

    private void Attack()
    {
        bool mouse1 = Input.GetMouseButtonDown(0);

        if (mouse1 == true)
        {
            isAttacking = true;
            animator.SetInteger("transition", 2);
        }
        else
        {
            isAttacking = false;
        }

    }

}
