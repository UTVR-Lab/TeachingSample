using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swarm : MonoBehaviour
{

    ///*
    public Transform pivot;
    public Transform swarmPar;
    public GameObject[] swarmies;
    public float speed=1;
    
    public Material[] swarmSkin;
    private int skinCount;
    
    public GameObject swarmPrefab;
    public static GameObject[] newSwarm;
    public int numSwarm;
    public float swarmRange;
    
    
    //Create array of swarmies
    void makeSwarm(int n){
        if(newSwarm!=null){
            for(int i=0; i<newSwarm.Length; i++){
                Destroy(newSwarm[i]);
            }
        }//*/
    
        newSwarm = new GameObject[n];
    
        for(int i=0; i<n; i++){
            /*if(newSwarm[i]!=null){
                Destroy(newSwarm[i]);
            }//*/
        
            newSwarm[i] = Instantiate(swarmPrefab, swarmPar.transform);
            newSwarm[i].transform.position = swarmPar.transform.position + new Vector3(Random.Range(-swarmRange, swarmRange),Random.Range(-.7f, .7f),Random.Range(-.7f, .7f));
            newSwarm[i].GetComponent<Renderer>().enabled = true;
        }
        return;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        skinCount = swarmSkin.Length;
        
        /*for(int i=0; i<swarmies.Length; i++)
        {swarmies[i].transform.position=swarmies[i].transform.position + new Vector3(i,0,0);}*/
    }

    // Update is called once per frame
    void Update()
    {
        /*string output="";
        for(int i=0; i<swarmies.Length; i++)
        {output+=i + ": " + swarmies[i].transform.position + ", ";}
        print(output);//*/
        
        swarmPar.RotateAround(pivot.position, Vector3.up, speed*3);
        
        for(int i=0; i<swarmies.Length; i++){
            swarmies[i].transform.RotateAround(swarmPar.position,Vector3.up,speed);
            swarmies[i].transform.RotateAround(swarmPar.position,Vector3.right,i*speed);
            swarmies[i].transform.RotateAround(swarmPar.position,Vector3.forward,(swarmies.Length-i)*speed);
        }//*/
        
        if(Input.GetKeyDown(KeyCode.N)){
            makeSwarm(numSwarm);
        }
        
        if(newSwarm!=null){
            for(int i=0; i<newSwarm.Length; i++){
                speed=speed*-1;
                newSwarm[i].transform.RotateAround(swarmPar.position,Vector3.up,(Random.Range(1f,10f))*speed);
                newSwarm[i].transform.RotateAround(swarmPar.position,Vector3.right,(Random.Range(1f,10f))*speed);
                newSwarm[i].transform.RotateAround(swarmPar.position,Vector3.forward,(Random.Range(1f,10f))*speed);
            }
        }
        
        
        //Change Material
        if(Input.GetKeyDown(KeyCode.R))
        {
            skinCount = (skinCount+1)%swarmSkin.Length;
            for(int i=0; i<swarmies.Length; i++)
            {
                swarmies[i].GetComponent<Renderer>().material = swarmSkin[skinCount];
            }
            for(int i=0; i<newSwarm.Length; i++)
            {
                newSwarm[i].GetComponent<Renderer>().material = swarmSkin[skinCount];
            }
        }
        
    }//*/
}