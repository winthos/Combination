using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour 
{
    Animator MyAnimator = null;

    public bool isAxisInUse = false;
    public bool isAxisInUse_Straight = false;

    public bool isAxisInUse_LeftHook = false;
    public bool LeftHookAct1 = false;

    public bool isAxisInUse_RightHook = false;
    public bool RightHookAct1 = false;

    public bool isAxisInUse_LeftUpper = false;
    public bool LeftUpperAct1 = false;

    public bool isAxisInUse_RightUpper = false;
    public bool RightUpperAct1 = false;

    public bool ReadyForInput = true;

    public bool SpaceToggle = false;

    public GameObject FreeMode = null;

    public GameObject Card1 = null;
    public GameObject Card2 = null;
    public GameObject Card3 = null;
    public GameObject Card4 = null;
    public GameObject Card5 = null;
    public GameObject Card6 = null;
    public GameObject Card7 = null;
    public GameObject Card8 = null;

    public GameObject BellSound = null;
    // Use this for initialization
    void Start () 
    {
        MyAnimator = gameObject.GetComponent<Animator>();
		
	}

    public void YesReadyForInput()
    {
        ReadyForInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();   
        }
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("A"))
        {
            if(SpaceToggle == false)
            {
                FreeMode.SetActive(false);
                gameObject.GetComponent<ComboCounter>().enabled = true;
                BellSound.GetComponent<AudioSource>().Play();

               SpaceToggle = true;
              
            }

             else if(SpaceToggle == true)
            {
                //toggle free mode on
                gameObject.GetComponent<ComboCounter>().enabled = false;
                Card1.SetActive(false);
                Card2.SetActive(false);
                Card3.SetActive(false);
                Card4.SetActive(false);
                Card5.SetActive(false);
                Card6.SetActive(false);
                Card7.SetActive(false);
                Card8.SetActive(false);
                BellSound.GetComponent<AudioSource>().Play();
                FreeMode.SetActive(true);

                SpaceToggle = false;
            }
        }
        //print(Input.GetAxisRaw("RightStickHorizontal"));

        //if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.F))
        //{
        //    MyAnimator.SetTrigger("Jab");
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.J))
        //{
        //    MyAnimator.SetTrigger("Straight");

        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.D))
        //{
        //    MyAnimator.SetTrigger("LeftHook");

        //}


        //if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.K))
        //{
        //    MyAnimator.SetTrigger("RightHook");

        //}

        //if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.S))
        //{
        //    MyAnimator.SetTrigger("LeftUpper");

        //}

        //if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.L))
        //{
        //    MyAnimator.SetTrigger("RightUpper");

        //}

        //////////////CONTROLLER NONSENSE//////////////////

        //JAB!///////////////////////////////////////////////////////////////////////
        if (Input.GetAxis("LeftStickVertical") <= -0.5 && ReadyForInput == true )
        {
            if (isAxisInUse == false)
            {
                ReadyForInput = false;
                MyAnimator.SetTrigger("Jab");
                isAxisInUse = true;

                gameObject.GetComponent<ComboCounter>().AddToPunchesThrown(1);
            }
        }

        if (Input.GetAxis("LeftStickVertical") >= -0.5)
        {
            isAxisInUse = false;

        }

        ////STRAIGHTO/////////////////////////////////////////////////////////////////
        if (Input.GetAxis("RightStickVertical") <= -0.5 && ReadyForInput == true)
        {
            if (isAxisInUse_Straight == false)
            {
                ReadyForInput = false;
                isAxisInUse_Straight = true;
                MyAnimator.SetTrigger("Straight");

                gameObject.GetComponent<ComboCounter>().AddToPunchesThrown(2);

            }
        }

        if (Input.GetAxis("RightStickVertical") >= -0.5)
        {
            isAxisInUse_Straight = false;
        }

        //LEFT HOOK/////-1 on left to 1 on right//////////////////////////////////////////
        if (Input.GetAxis("LeftStickHorizontal") >= 0.5 && ReadyForInput == true)
        {
            if(isAxisInUse_LeftHook == false)
            {
                ReadyForInput = false;
                // print("buh");
                isAxisInUse_LeftHook = true;
               // LeftHookAct1 = true;
                //StartCoroutine("LeftHookCountDown");
                MyAnimator.SetTrigger("LeftHook");

                gameObject.GetComponent<ComboCounter>().AddToPunchesThrown(3);
            }
        }

        if(Input.GetAxis("LeftStickHorizontal") < 0.5)
        {
            isAxisInUse_LeftHook = false;
        }


        //RIGHT HOOOOK///////////////////////////////////////////////////////////////////////
        if (Input.GetAxis("RightStickHorizontal") <= -0.5 && ReadyForInput == true)
        {
            if (isAxisInUse_RightHook == false)
            {
                ReadyForInput = false;
                // print("buh");
                isAxisInUse_RightHook = true;
                // RightHookAct1 = true;
                // StartCoroutine("RightHookCountDown");
                MyAnimator.SetTrigger("RightHook");

                gameObject.GetComponent<ComboCounter>().AddToPunchesThrown(4);
            }
        }


        if (Input.GetAxis("RightStickHorizontal") > -0.5)
        {
            isAxisInUse_RightHook = false;
        }


        ////LEFT UPPPAAAAAA/////////////////////////////////////////////////////////////
        if (Input.GetAxis("LeftStickVertical") >= 0.5 && ReadyForInput == true)
        {
            if (isAxisInUse_LeftUpper == false)
            {
                ReadyForInput = false;
                isAxisInUse_LeftUpper = true;
                // LeftUpperAct1 = true;
                // StartCoroutine("LeftUpperCountDown");
                MyAnimator.SetTrigger("LeftUpper");

                gameObject.GetComponent<ComboCounter>().AddToPunchesThrown(5);
            }
        }

        if(Input.GetAxis("LeftStickVertical") < 0.5)
        {
            isAxisInUse_LeftUpper = false;
        }

        ////RIGHT UPPPAAAAA////////////////////////////////////////////////////////////////////

        if (Input.GetAxis("RightStickVertical") >= 0.5 && ReadyForInput == true)
        {
            if (isAxisInUse_RightUpper == false)
            {
                ReadyForInput = false;
                isAxisInUse_RightUpper = true;
                //RightUpperAct1 = true;
                //StartCoroutine("RightUpperCountDown");
                MyAnimator.SetTrigger("RightUpper");

                gameObject.GetComponent<ComboCounter>().AddToPunchesThrown(6);
            }
        }

        if (Input.GetAxis("RightStickVertical") < 0.5)
        {
            isAxisInUse_RightUpper = false;
        }



    }

    IEnumerator LeftHookCountDown()
    {
        yield return new WaitForSeconds(0.05f);

        LeftHookAct1 = false;
        isAxisInUse_LeftHook = false;
    }

    IEnumerator RightHookCountDown()
    {
        yield return new WaitForSeconds(0.05f);

        RightHookAct1 = false;
        isAxisInUse_RightHook = false;
    }

    IEnumerator LeftUpperCountDown()
    {
        yield return new WaitForSeconds(0.15f);

        LeftUpperAct1 = false;
        isAxisInUse_LeftUpper = false;
    }

    IEnumerator RightUpperCountDown()
    {
        yield return new WaitForSeconds(0.15f);

        RightUpperAct1 = false;
        isAxisInUse_RightUpper = false;
    }
}
