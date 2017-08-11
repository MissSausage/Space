using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    [SerializeField]
    float thrust = 10;
    public float speed = 10.0F;
    public Rigidbody rigi;


    void Start()
    {
        rigi = this.GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (static_memories.isgrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigi.AddForce(transform.up * (thrust * Time.deltaTime), ForceMode.Impulse);
            }
        }
    }

    void Jump()
    {
       
       
    }
         //rigi.AddForce(new Vector3(0, transform.position.y * thrust, 0));
       
}
