using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="bumper")
        {
            print("Hit!");
        }
        
        if(other.gameObject.name=="lapper")
        {
            print("Lap!");
        }
        
    }
}
