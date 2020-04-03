using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsControl : MonoBehaviour
{
    public Transform cam;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            cam.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            cam.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
        
        if(Input.GetKey(KeyCode.RightArrow)){
            cam.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            cam.Translate(-Vector3.right * speed * Time.deltaTime);
        }
    }
}
