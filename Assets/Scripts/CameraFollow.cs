using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 diff;
    [SerializeField] private float z;
    private void Update()
    {
        diff = new Vector3(0, 0, z);

        transform.position = player.position + diff;
    }
}
