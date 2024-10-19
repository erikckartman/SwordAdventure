using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 3f;

    [SerializeField] private GameObject sword;
    private float attackDuration = 0.5f;
    private float swingSpeed = 200f;
    [HideInInspector] public bool isAttacking = false;

    private float defaultRotatAm = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(inputX * speed, inputY * speed);

        if (Input.GetKeyDown(KeyCode.X) && !isAttacking)
        {
            StartCoroutine(Beat());
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            defaultRotatAm = -180f; ;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            defaultRotatAm = 90f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            defaultRotatAm = 180f;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            defaultRotatAm = 0f;
        }
    }

    private IEnumerator Beat()
    {
        isAttacking = true;

        float rotationAmount = defaultRotatAm;

        while (rotationAmount < defaultRotatAm + 90f)
        {
            float rotationStep = swingSpeed * Time.deltaTime;
            sword.transform.Rotate(0, 0, -rotationStep);
            rotationAmount += rotationStep;
            yield return null;
        }

        yield return new WaitForSeconds(attackDuration);

        sword.transform.rotation = Quaternion.identity;

        isAttacking = false;
    }
}