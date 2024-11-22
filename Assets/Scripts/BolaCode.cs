using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaCode : MonoBehaviour
{

    Rigidbody2D rb;
    int jumpPower = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool mouse1 = Input.GetMouseButtonDown(0);

        if (mouse1 == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}
