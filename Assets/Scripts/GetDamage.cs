using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDamage : MonoBehaviour
{
    public int health = 15;
    [SerializeField] private Slider bar;
    private BoxCollider2D col2d;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void OnTriggerEnter2D(Collider2D other )
    {
        if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine(DamageAnim());
        }
    }

    private void Start()
    {
        col2d = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DamageAnim()
    {
        health -= 2;
        bar.value = health;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.3f);
        
    }
}
