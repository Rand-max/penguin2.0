using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObjectController : MonoBehaviour
{
    public SkillObject skillObject;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<playercontroler>())
        {
            GameObject.Instantiate(skillObject.DestroyParticle, this.gameObject.transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
