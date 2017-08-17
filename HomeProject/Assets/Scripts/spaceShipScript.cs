using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShipScript : MonoBehaviour
{
    float speed = 15f;
    public bool isShooting = false;
    public float shipHealth;
    public bool gameOverActive = false;

    Vector3 transition;

    public GameObject _bullet;
    public GameObject _gun;

    public float ShipHealth
    {
        get { return shipHealth; }
        set { shipHealth = value; }
    }

    void Start()
    {
        shipHealth = 100;
    }


    void FixedUpdate()
    {
        Movement();
        Shoot();

        if (Input.GetKey(KeyCode.Space))
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }

        if (shipHealth <= 0)
        {
            Time.timeScale = 0;
            GameObject.Find("SceneManager").GetComponent<HUDScript>()._gameOverPanel.SetActive(true);
            gameOverActive = true;
        }
        else
        {
            gameOverActive = false;
        }
    }

    public void Movement()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, translation, 0);
    }
    void Shoot()
    {
        if (isShooting)
        {
            //Debug.Log("shoooooot");
            GameObject GO = Instantiate(_bullet, _gun.transform.position, Quaternion.identity);
            GO.transform.parent = GameObject.Find("EnemyParent").transform;
        }
    }
}
