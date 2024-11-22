using UnityEngine;

public class PatrulhaNPC : MonoBehaviour
{
    public float speed = 2f;
    public bool ground = true;
    public Transform groundCheck;
    public LayerMask groundLayer;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        ground = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);
        Debug.Log(ground);

        if (ground == false)
        {
            speed *= -1;
        }
    }

}
