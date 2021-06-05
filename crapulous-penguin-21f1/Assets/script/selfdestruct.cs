using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestruct : MonoBehaviour
{
    public float survivetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        survivetime-=Time.deltaTime*1;
        if(survivetime<=0){
            Destroy(gameObject,Time.deltaTime);
            Debug.Log("died");
        }
    }
}
