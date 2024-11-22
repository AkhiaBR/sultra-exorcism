using UnityEngine;

public class NPC_noFlip : MonoBehaviour
{
    public float speed = 2f;
    public bool ground = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private float directionTimer = 0f;
    private float changeDirectionInterval = 2f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        ground = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);
        directionTimer += Time.deltaTime;

        if (directionTimer >= changeDirectionInterval)
        {
            speed *= -1;
            directionTimer = 0f;
        }
    }

}
