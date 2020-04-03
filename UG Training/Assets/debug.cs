using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug : MonoBehaviour
{

    public GameObject interior;
    public float rotSpeed;
    
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        
        print("game start: " + count);
    }

    // Update is called once per frame
    void Update()
    {
    
        if(count%60 == 0)
        {
            interior.transform.position += new Vector3(rotSpeed,0,0);
            
            print("done");
        }
        count++;
    }
}
