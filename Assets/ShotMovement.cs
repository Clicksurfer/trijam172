using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShotMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public float Damage;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
}
