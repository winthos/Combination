using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsparkController : MonoBehaviour
{
    public GameObject JabSpark = null;
    public GameObject StraightSpark = null;
    public GameObject LeftHookSpark = null;
    public GameObject RightHookSpark = null;
    public GameObject LeftUpperSpark = null;
    public GameObject RightUpperSpark = null;

    public GameObject ComboFinishSpark = null;
	// Use this for initialization
	void Start () 
    {
		
	}
	
    public void PlayJabSpark()
    {
        JabSpark.GetComponent<ParticleSystem>().Play();
    }

    public void PlayStraightSpark()
    {
        StraightSpark.GetComponent<ParticleSystem>().Play();
    }

    public void PlayLeftHookSpark()
    {
        LeftHookSpark.GetComponent<ParticleSystem>().Play();
    }

    public void PlayRightHookSpark()
    {
        RightHookSpark.GetComponent<ParticleSystem>().Play();
    }

    public void PlayLeftUpperSpark()
    {
        LeftUpperSpark.GetComponent<ParticleSystem>().Play();
    }

    public void PlayRightUpperSpark()
    {
        RightUpperSpark.GetComponent<ParticleSystem>().Play();
    }

    public void PlayComboFinishSpark()
    {
        ComboFinishSpark.GetComponent<ParticleSystem>().Play();
    }
	// Update is called once per frame
	void Update () 
    {
		
	}
}
