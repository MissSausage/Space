using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == ("Player"))
        {
            static_memories.isgrounded = true;
        }
    }
}
