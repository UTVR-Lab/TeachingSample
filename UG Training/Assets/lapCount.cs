using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lapCount : MonoBehaviour
{
    private int lapNum=0;
    
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name=="Goal")
        {
            lapNum++;
            print("Lap Number: " + lapNum);
        }
    }
}
