using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endOFMap : MonoBehaviour
{
    GameObject spaceShip;
    Transform respawnPoint;
    float timer;
    bool spaceshipDisabled = false;
    spaceShipScript shipFunction;

    private void Start()
    {
        spaceShip = GameObject.Find("spaceship");
        respawnPoint = GameObject.Find("Respawn").transform;
        shipFunction = spaceShip.GetComponent<spaceShipScript>();
    }

    private void Update()
    {
        if (spaceshipDisabled)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if(!spaceshipDisabled)
            {
                timer = 0;
            }
        }

        if(timer >= 3)
        {
            spaceShip.GetComponent<BoxCollider2D>().enabled = true;
            shipFunction.enabled = true;
            spaceshipDisabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Bullet") || other.gameObject.tag == ("redEnemy") || other.gameObject.tag == ("greenEnemy") || other.gameObject.tag == ("blueEnemy"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == ("spaceship"))
        {
            spaceShip.GetComponent<BoxCollider2D>().enabled = false;
            shipFunction.enabled = false;
            spaceShip.transform.position = respawnPoint.position;
            spaceshipDisabled = true;
        }
    }
}
