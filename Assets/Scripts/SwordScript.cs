using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SwordScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D collisionsword;
    [SerializeField] private Sword sword;

    private void Awake()
    {
        
    }
    private void Update()
    {
        if (sword.isAttacking)
        {
            spriteRenderer.enabled = true;
            collisionsword.enabled = true;
        }
        else
        { 
            spriteRenderer.enabled = false;
            collisionsword.enabled = false;
        }

        Vector3 currentRotation = transform.rotation.eulerAngles;
        float targetYRotation = player.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(currentRotation.x, targetYRotation, currentRotation.z);

        transform.position = player.position + offset;
    }
}
