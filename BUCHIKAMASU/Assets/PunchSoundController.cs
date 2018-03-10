using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PunchSoundController : MonoBehaviour 
{
    public GameObject CrazyDSound = null;
    public bool DORARA = false;

    public AudioSource JabSource = null;

    public AudioSource StraightSource = null;

    public AudioSource LeftHookSource = null;

    public AudioSource RightHookSource = null;

    public AudioSource LeftUpperSource = null;

    public AudioSource RightUpperSource = null;

	// Use this for initialization
	void Start () 
    {
        //MyAudioSource = gameObject.GetComponent<AudioSource>();
	}

	void Update () 
    {
		
	}

    public void PlayJab()
    {
        JabSource.pitch = Random.Range(0.9f, 1.2f);
        //vibrate controller here

        JabSource.Play();
        StartCoroutine("JabRumble");

        gameObject.GetComponent<HitsparkController>().PlayJabSpark();

        if (DORARA == true)
        {
            CrazyDSound.GetComponent<AudioSource>().Play();
            DORARA = false;
            gameObject.GetComponent<HitsparkController>().PlayComboFinishSpark();
        }

    }

    IEnumerator JabRumble()
    {
        //rumble here
        GamePad.SetVibration(0, 1.0f, 0.1f);
        yield return new WaitForSeconds(0.12f);
        GamePad.SetVibration(0, 0f, 0f);
    }

    public void PlayStraight()
    {
        StraightSource.pitch = Random.Range(0.9f, 1.2f);

        StraightSource.Play();
        StartCoroutine("StraightRumble");

        gameObject.GetComponent<HitsparkController>().PlayStraightSpark();


        if (DORARA == true)
        {
            CrazyDSound.GetComponent<AudioSource>().Play();
            DORARA = false;
            gameObject.GetComponent<HitsparkController>().PlayComboFinishSpark();
        }
    }

    IEnumerator StraightRumble()
    {
        //rumble here
        GamePad.SetVibration(0, 0.1f, 1.0f);
        yield return new WaitForSeconds(0.18f);
        GamePad.SetVibration(0, 0f, 0f);
    }

    public void PlayLeftHook()
    {
        LeftHookSource.pitch = Random.Range(1.1f, 1.5f);
        StartCoroutine("LeftHookRumble");
        LeftHookSource.Play();
        gameObject.GetComponent<HitsparkController>().PlayLeftHookSpark();

        if (DORARA == true)
        {
            CrazyDSound.GetComponent<AudioSource>().Play();
            DORARA = false;
            gameObject.GetComponent<HitsparkController>().PlayComboFinishSpark();
        }
    }

    IEnumerator LeftHookRumble()
    {
        //rumble here
        GamePad.SetVibration(0, 1.0f, 0.0f);
        yield return new WaitForSeconds(0.2f);
        GamePad.SetVibration(0, 0f, 0f);
    }

    public void PlayRightHook()
    {
        RightHookSource.pitch = Random.Range(0.8f, 1.1f);
        StartCoroutine("RightHookRumble");
        RightHookSource.Play();
        gameObject.GetComponent<HitsparkController>().PlayRightHookSpark();

        if (DORARA == true)
        {
            CrazyDSound.GetComponent<AudioSource>().Play();
            DORARA = false;
            gameObject.GetComponent<HitsparkController>().PlayComboFinishSpark();
        }
    }

    IEnumerator RightHookRumble()
    {
        //rumble here
        GamePad.SetVibration(0, 0f, 1.0f);
        yield return new WaitForSeconds(0.25f);
        GamePad.SetVibration(0, 0f, 0f);
    }

    public void PlayLeftUpper()
    {
        LeftUpperSource.pitch = Random.Range(0.8f, 1.1f);
        StartCoroutine("LeftUpperRumble");
        LeftUpperSource.Play();
        gameObject.GetComponent<HitsparkController>().PlayLeftUpperSpark();

        if (DORARA == true)
        {
            CrazyDSound.GetComponent<AudioSource>().Play();
            DORARA = false;
            gameObject.GetComponent<HitsparkController>().PlayComboFinishSpark();
        }
    }
    IEnumerator LeftUpperRumble()
    {
        //rumble here
        GamePad.SetVibration(0, 1.0f, 0f);
        yield return new WaitForSeconds(0.5f);
        GamePad.SetVibration(0, 0f, 0f);
    }


    public void PlayRightUpper()
    {
        RightUpperSource.pitch = Random.Range(1.1f, 1.4f);
        StartCoroutine("RightUpperRumble");
        RightUpperSource.Play();
        gameObject.GetComponent<HitsparkController>().PlayRightUpperSpark();

        if (DORARA == true)
        {
            CrazyDSound.GetComponent<AudioSource>().Play();
            DORARA = false;
            gameObject.GetComponent<HitsparkController>().PlayComboFinishSpark();
        }
    }

    IEnumerator RightUpperRumble()
    {
        //rumble here
        GamePad.SetVibration(0, 0f, 1.0f);
        yield return new WaitForSeconds(0.5f);
        GamePad.SetVibration(0, 0f, 0f);
    }
}
