using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatforms : MonoBehaviour
{
    public float backLimit = 2F;
    public float frontLimit = 2F;
    private int direction = 1;
    public float speed = 2.0F;
    Vector3 movement;

    void Update()
    {
        if (transform.position.z > frontLimit)
        {
            direction = -1;
        }
        else
        {
            if (transform.position.z < backLimit)
            {
                direction = 1;
            }

        }
        movement = Vector3.forward * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
