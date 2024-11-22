using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    public float speed = 5; // velocidade de movimento
    public float jump = 10; // força de pulo
    public float dashSpeed = 20; // velocidade do dash
    public float dashDuration = 0.1f; // duração do dash
    public float dashCooldown = 1f; // tempo de recarga do dash

    private Animator animator; // variável animator: Animator
    private Rigidbody2D rb; // variável rb: Rigidbodt2D
    private bool isAttacking = false; // verifica se está atacando
    private bool isDashing = false; // verifica se está em dash
    private float dashCooldownTimer = 0f; // contador para recarga do dash
    private int maxHealth = 300; // vida máxima
    private int currentHealth; // vida atual

    private void Start() // executa apenas no início do jogo
    {
        currentHealth = maxHealth; // quando o jogo iniciar, vida máxima
        animator = GetComponent<Animator>(); // define que animator é igual ao componente Animator do objeto
        rb = GetComponent<Rigidbody2D>(); // define que rb é igual ao componente Rigidbody2D do objeto
    }

    private void Update() // executa em série (atualizando)
    {
        // CHAMA AS FUNÇÕES
        if (!isDashing)
        {
            Jump();
            Move();
            Attack();
        }
        Dash();
        Hit();
        Death();
    }

    private void Move()
    {
        if (isAttacking) return; // se mover e estiver atacando ao mesmo tempo, cancela a animação

        float tecla = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(tecla * speed, rb.velocity.y);

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

    private void Hit()
    {

    }

    private void Death()
    {

    }

    private void Dash()
    {
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) // quando shift é pressionado
        {
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        isDashing = true; // indica que está em dash
        dashCooldownTimer = dashCooldown; // reinicia o cooldown do dash

        Vector2 dashDirection = transform.eulerAngles.y == 180 ? Vector2.left : Vector2.right; // define a dircao do dash

        float startTime = Time.time;
        while (Time.time < startTime + dashDuration)
        {
            rb.velocity = dashDirection * dashSpeed; // aplica a velocidade do dash
            yield return null; // espera o próximo frame
        }

        rb.velocity = Vector2.zero; // para o movimento ao final do dash
        isDashing = false;
    }

    private void Jump()
    {
        bool mouse2 = Input.GetMouseButtonDown(1);

        if (mouse2 == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }

}
