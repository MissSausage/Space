using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSCript : MonoBehaviour
{
    float bulletSpeed = 30f;
    Rigidbody2D rigi;
    public float bulletDamage = 4f;
    public enemyMovement enemyScript;

    private void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        rigi.AddForce(transform.right * bulletSpeed, 0);
    }
}
