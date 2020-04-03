using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class racer : MonoBehaviour
{

    public Transform runner;
    public float speed=1;
    public float dist=6;
    public float rot=90;
    public Material run;
    public Material blank;
    public Material[] colors;
    
    private float time=0;
    private Vector3 pivot;
    private Vector3 oPos;
    private Vector3 oRot;
    private Vector3 startPos;
    private Vector3 endPos;
    private int lap=0;
    private int corner=0;
    private bool color=false;
    private int colorCount=0;
    
    // Start is called before the first frame update
    void Start()
    {
        oPos=new Vector3(1,.85f,-1);
        oRot=new Vector3(0,90,0);
        startPos=oPos;
    }

    // Update is called once per frame
    void Update()
    {
        ///*short code, compromised performance
        if(Input.GetKey(KeyCode.Keypad1))
        {
            pivot = new Vector3(4,0,-4);
            runner.RotateAround(pivot, Vector3.up, speed);
        }
        //*/
        
        
        ///*Longer Code, Accurate at low speed
        //print(Time.time + ", " + Mathf.Sin(Time.time * (Mathf.PI/speed)));
        if(Input.GetKey(KeyCode.Keypad2))
        {
            if(Mathf.Sin(time * (Mathf.PI*speed)) >= 0)
                {runner.Translate(Vector3.forward * Time.deltaTime * dist * speed);}
            else
                {runner.Rotate(0f,Time.deltaTime * rot * speed,0f);}
            time+=Time.deltaTime;
        }
        
        ///* Longest Code, but most accurate at high speed
        if(Input.GetKey(KeyCode.Keypad3))
        {
            float distCovered = time * speed * 2;
            float completion = distCovered / dist;
            
            switch(corner)
            {
                case 0:
                    endPos = startPos + new Vector3(6,0,0);
                    break;
                case 1:
                    endPos = startPos + new Vector3(0,0,-6);
                    break;
                case 2:
                    endPos = startPos + new Vector3(-6,0,0);
                    break;
                case 3:
                    endPos = startPos + new Vector3(0,0,6);
                    break;
                default:
                    break;
            }
            
            runner.position = Vector3.Lerp(startPos, endPos, completion);
            
            if(runner.position==endPos)
            {
                corner = (corner+1)%4;
                //print(corner);
                if(corner==0)
                {
                    lap++;
                    print("Lap: " + lap);
                }
                
                startPos=runner.position;
                
                time=0;
            }
            
            time+=Time.deltaTime;
        }
        //*/
        
        //Reset on 4
        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            time=0;
            lap=0;
            runner.position=oPos;
            runner.eulerAngles=oRot;
        }
        
        //Change Color
        if(Input.GetKeyDown(KeyCode.Q))
        {
            color=!color;
            
            colorCount++;
            
            runner.GetComponent<Renderer>().material = colors[colorCount%colors.Length];
            
            /*if(color)
            {runner.GetComponent<Renderer>().material = run;}
            else
            {runner.GetComponent<Renderer>().material = blank;}//*/
        }
        
        //Adjust Speed
        if(Input.GetKeyDown(KeyCode.W))
        {
            speed*=2;
            print(speed);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            speed/=2;
            print(speed);
        }
        
        if(Input.GetKeyDown(KeyCode.D))
        {
            
        }
    }
}
