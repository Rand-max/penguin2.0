using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmcontroller : MonoBehaviour
{    
    public Transform target;
    public float offsety;
    public float turnbackspeed;
    void Start(){
    }
    void FixedUpdate()
    {
        //Vector3 pos=target.transform.position-transform.position;
        //pos[1]+=offsety;
        //transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(pos),turnbackspeed*Time.deltaTime);
    }
}