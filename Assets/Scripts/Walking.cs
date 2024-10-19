using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 3f;
    private float jump = 10f;

    public bool isGrounded;
    public bool canMove;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Sword sword;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.7f, groundLayer);

        if (canMove && isGrounded)
        {
            rb.velocity = new Vector2(inputX * speed, rb.velocity.y); 

            if (inputX > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (inputX < 0)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
            }
        }

        if(Input.GetKeyDown(KeyCode.Z) && isGrounded)
        {
            rb.velocity = new Vector2(inputX * (speed/3), jump);
        }

        canMove = isGrounded;        
    }
}
