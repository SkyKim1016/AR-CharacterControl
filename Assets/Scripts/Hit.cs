using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public bool contact = false;
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Goblin")
        {
            /*Destroy(other.gameObject);*/

            contact = true;
        }
    }


}
