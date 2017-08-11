using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float generalSpeedValue;
    float greenEnemySpeed = 20f;
    float redEnemySpeed = 10f;
    float blueEnemySpeed = 30f;

    public float generalDamageValue;
    float greenEnemyDamage = 2f;
    float redEnemyDamage = 3f;
    float blueEnemyDamage = 1f;

    public float generalHealthValue;
    float greenEnemyHealth = 2f;
    float redEnemyHealth = 3f;
    float blueEnemyHealth = 1f;

    //BulletDamage!!:)
    public float generalBulletDamage;
    float normalBulletDamage = 3f;
    bool bulletHit = true;

    Rigidbody2D rigi;

    spaceShipScript ship;
    bulletSCript bullet;
    HUDScript hud;

    GameObject theBullet;

    private void Start()
    {
        rigi = GetComponent<Rigidbody2D>();

        ship = GameObject.Find("spaceship").GetComponent<spaceShipScript>();
        bullet = Resources.Load<GameObject>("bullet").GetComponent<bulletSCript>();
        hud = GameObject.Find("SceneManager").GetComponent<HUDScript>();

        if (gameObject.tag == ("greenEnemy"))
        {
            //Debug.Log("Enemy is green");

            generalSpeedValue = greenEnemySpeed;
            generalDamageValue = greenEnemyDamage;
            generalHealthValue = greenEnemyDamage;
        }

        if (gameObject.tag == ("redEnemy"))
        {
            //Debug.Log("Enemy is red");

            generalSpeedValue = redEnemySpeed;
            generalDamageValue = redEnemyDamage;
            generalHealthValue = redEnemyDamage;
        }

        if (gameObject.tag == ("blueEnemy"))
        {
            //Debug.Log("Enemy is blue");

            generalSpeedValue = blueEnemySpeed;
            generalDamageValue = blueEnemyDamage;
            generalHealthValue = blueEnemyDamage;
        }

    }

    void Update()
    {
        EnemyMovement();

        if(generalHealthValue <= 0)
        {
            hud.counter++;
            Debug.Log("EnemyDestroyed");
            Destroy(this.gameObject);
        }

        if(bulletHit)
        {
            generalHealthValue -= generalBulletDamage;
            Debug.Log("bullet hit enemy" + "-bulletDamage " + bullet.bulletDamage + "-enemyHealth " + generalHealthValue);
        }
        else
        {
            generalBulletDamage = 0;
        }
    }

    void EnemyMovement()
    {
        rigi.AddForce(-transform.right * generalSpeedValue, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Bullet"))
        {
            generalBulletDamage = normalBulletDamage;
            Destroy(collision.gameObject);
            bulletHit = true;
        }
        else
        {
            bulletHit = false;
        }

        if(collision.gameObject.name == ("spaceship"))
        {
            ship.shipHealth -= generalDamageValue;
            Debug.Log("ship got hit" + "-enemyDamageValue " + generalHealthValue);
            Destroy(gameObject);
        }
    }
}
