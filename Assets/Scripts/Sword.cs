using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    private float attackDuration = 0.5f;
    private float swingSpeed = 200f;
    [HideInInspector]public bool isAttacking = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isAttacking)
        {
            StartCoroutine(Beat());
        }
    }

    private IEnumerator Beat()
    {
        isAttacking = true;

        float rotationAmount = 0f;

        while (rotationAmount < 90f)
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
