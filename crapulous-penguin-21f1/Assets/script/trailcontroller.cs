using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailcontroller : MonoBehaviour
{
    public TrailRenderer trail;
    public GameObject bodypart;
    private Vector3[] positions=new Vector3[2000];
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int i= trail.GetPositions(positions);
        Instantiate(bodypart,positions[i-1>0?i-1:0],default);
        bodypart.GetComponent<selfdestruct>().survivetime=trail.time;
    }
}
