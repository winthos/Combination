using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboCounter : MonoBehaviour 
{

    //Ok here are the combos//

    //Combo 1:  1 - 2
    //Combo 2:  1 - 1 - 2
    //Combo 3:  1 - 2 - 3
    //Combo 4:  1 - 2 - 3 - 2
    //Combo 5:  1 - 2 - 5 - 2
    //Combo 6:  1 - 6 - 3 - 2
    //Combo 7:  2 - 3 - 2
    //Combo 8:  1 - 4 - 3 - 2

    public GameObject BellSound = null;
    public GameObject ComboClearSound = null;
    public AudioSource FailedCombo = null;

    public GameObject ComboCard_1 = null;
    public GameObject Combo_1_1 = null;

    public GameObject ComboCard_2 = null;
    public GameObject Combo_2_1 = null;
    public GameObject Combo_2_2 = null;

    public GameObject ComboCard_3 = null;
    public GameObject Combo_3_1 = null;
    public GameObject Combo_3_2 = null;

    public GameObject ComboCard_4 = null;
    public GameObject Combo_4_1 = null;
    public GameObject Combo_4_2 = null;
    public GameObject Combo_4_3 = null;

    public GameObject ComboCard_5 = null;
    public GameObject Combo_5_1 = null;
    public GameObject Combo_5_2 = null;
    public GameObject Combo_5_3 = null;

    public GameObject ComboCard_6 = null;
    public GameObject Combo_6_1 = null;
    public GameObject Combo_6_2 = null;
    public GameObject Combo_6_3 = null;

    public GameObject ComboCard_7 = null;
    public GameObject Combo_7_1 = null;
    public GameObject Combo_7_2 = null;

    public GameObject ComboCard_8 = null;
    public GameObject Combo_8_1 = null;
    public GameObject Combo_8_2 = null;
    public GameObject Combo_8_3 = null;

    public PunchSoundController PunchSoundCon = null;

    public int WhichComboAmICounting = 0;

    public List<int> Combo1 = new List<int>()
    {
        1, 2
    };

    public List<int> Combo2 = new List<int>()
    {
        1, 1, 2
    };

    public List<int> Combo3 = new List<int>()
    {
        1, 2, 3
    };

    public List<int> Combo4 = new List<int>()
    {
        1, 2, 3, 2
    };

    public List<int> Combo5 = new List<int>()
    {
        1, 2, 5, 2
    };

    public List<int> Combo6 = new List<int>()
    {
        1, 6, 3, 2
    };

    public List<int> Combo7 = new List<int>()
    {
        2, 3, 2
    };

    public List<int> Combo8 = new List<int>()
    {
        1, 4, 3, 2
    };

    public List<int> PunchesThrown = new List<int>();

    public bool Combo1_Visible = true;
    public bool Combo2_Visible = true;
    public bool Combo3_Visible = true;
    public bool Combo4_Visible = true;
    public bool Combo5_Visible = true;
    public bool Combo6_Visible = true;
    public bool Combo7_Visible = true;
    public bool Combo8_Visible = true;

    public GameObject ClearText = null;

    // Use this for initialization
    void Start () 
    {
        //foreach (int yes in Combo1)
        //{
        //    print(yes);
        //}

        PunchSoundCon = gameObject.GetComponent<PunchSoundController>();
	}

    public void AddToPunchesThrown(int punch)
    {
        if(this.enabled == false)
        {
            return;
        }
        PunchesThrown.Add(punch);
    }

    public void RemovePunchesFromList()
    {
        PunchesThrown.Clear();
       

    }

    IEnumerator WaitThenChange(int yes)
    {
        yield return new WaitForSeconds(0.3f);
        ClearText.SetActive(true);
       // ComboClearSound.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.1f);

        //play bell here?
        BellSound.GetComponent<AudioSource>().Play();

        ClearText.SetActive(false);
        WhichComboAmICounting = yes;

        if(yes == 1)
        {
            Combo1_Visible = true;
        }

        if (yes == 2)
        {
            Combo2_Visible = true;
        }

        if (yes == 3)
        {
            Combo3_Visible = true;
        }

        if (yes == 4)
        {
            Combo4_Visible = true;
        }

        if (yes == 5)
        {
            Combo5_Visible = true;
        }

        if (yes == 6)
        {
            Combo6_Visible = true;
        }

        if (yes == 7)
        {
            Combo7_Visible = true;
        }

        if (yes == 8)
        {
            Combo8_Visible = true;
        }
    }

	
	// Update is called once per frame
	void Update () 
    {
      

        //print(PunchesThrown.Count);
        ////CHECK FOR COMBO 1/////////////////////////////
		if (WhichComboAmICounting == 1)
        {
            if(Combo1_Visible == true)
            {
                ComboCard_1.SetActive(true);
            }

            if(Combo1_Visible == false)
            {
                ComboCard_1.SetActive(false);
            }


            //are there things in the list?
            if(PunchesThrown.Count != 0)
            {
                ///check if first item in list is same as in combo 1
                if (PunchesThrown[0] == Combo1[0])
                {

                    Combo_1_1.GetComponent<Image>().color = Color.green;

                    if(PunchesThrown.Count == 2)
                    {
                        //neat! check if the second one is the same
                        if (PunchesThrown[1] == Combo1[1])
                        {
                            Combo_1_1.GetComponent<Image>().color = Color.white;
                            StartCoroutine("WaitThenChange", 2);
                            //ComboCard_1.SetActive(false);
                            Combo1_Visible = false;
                            //cool! all punches in current list match up with Combo 1
                            //print("Combo 1 done! DORA!");

                            //switch sound with CRAZY D
                            PunchSoundCon.DORARA = true;
                          
                            RemovePunchesFromList();
                        }

                        else
                        {
                            Combo_1_1.GetComponent<Image>().color = Color.white;
                            FailedCombo.Play();
                            RemovePunchesFromList();
                        }
                    }

                }

                //if first one is wrong, clear the list to start over
                else
                {
                    Combo_1_1.GetComponent<Image>().color = Color.white;
                    FailedCombo.Play();
                    RemovePunchesFromList();
                }
            }
        }
        //////////////////////////////////////////////////////////
        ////COMBO 2: 1 1 2
        ///////////////////////////////////////////////////////////

        if (WhichComboAmICounting == 2)
        {
            if (Combo2_Visible == true)
            {
                ComboCard_2.SetActive(true);
            }

            if (Combo2_Visible == false)
            {
                ComboCard_2.SetActive(false);
            }


            if (PunchesThrown.Count != 0)
            {
                if (PunchesThrown[0] == Combo2[0])
                {
                    //first number should be green
                    Combo_2_1.GetComponent<Image>().color = Color.green;
                    
                    if(PunchesThrown.Count >= 2)
                    {
                        //print("there are 2 items in list");
                        if(PunchesThrown[1] == Combo2[1])
                        {
                            //second number should be green
                            Combo_2_2.GetComponent<Image>().color = Color.green;

                            if(PunchesThrown.Count >= 3)
                            {
                                //NewComboCard Here


                                if (PunchesThrown[2] == Combo2[2])
                                {
                                    //cool! all punches in current list match up with Combo 1
                                    //print("Combo 2 done! DORA RA!");
                                    Combo_2_1.GetComponent<Image>().color = Color.white;
                                    Combo_2_2.GetComponent<Image>().color = Color.white;
                                    StartCoroutine("WaitThenChange", 3);
                                    //ComboCard_1.SetActive(false);
                                    Combo2_Visible = false;
                                    //switch sound with CRAZY D
                                    PunchSoundCon.DORARA = true;
                                    
                                    RemovePunchesFromList();
                                }

                                else
                                {
                                    FailedCombo.Play();
                                    Combo_2_1.GetComponent<Image>().color = Color.white;
                                    Combo_2_2.GetComponent<Image>().color = Color.white;
                                    RemovePunchesFromList();
                                }
                            }

                        }

                        else
                        {
                            FailedCombo.Play();
                            Combo_2_1.GetComponent<Image>().color = Color.white;
                            Combo_2_2.GetComponent<Image>().color = Color.white;
                            RemovePunchesFromList();
                        }
                    }
                }

                else
                {
                    FailedCombo.Play();
                    Combo_2_1.GetComponent<Image>().color = Color.white;
                    Combo_2_2.GetComponent<Image>().color = Color.white;
                    RemovePunchesFromList();
                }
            }

        }

        //////////////////////////////////////////////////////////////////////////
        //COMBO 3:  1, 2, 3
        //////////////////////////////////////////////////////////////////////////

        if (WhichComboAmICounting == 3)
        {
            if (Combo3_Visible == true)
            {
                ComboCard_3.SetActive(true);
            }

            if (Combo3_Visible == false)
            {
                ComboCard_3.SetActive(false);
            }

            if (PunchesThrown.Count != 0)
            {
                if (PunchesThrown[0] == Combo3[0])
                {
                    Combo_3_1.GetComponent<Image>().color = Color.green;

                    if (PunchesThrown.Count >= 2)
                    {
                        //print("there are 2 items in list");
                        if (PunchesThrown[1] == Combo3[1])
                        {
                            //print("Second element matches");
                            Combo_3_2.GetComponent<Image>().color = Color.green;
                            if (PunchesThrown.Count >= 3)
                            {
                                //print("there are 3 in the list now");

                                Combo_3_1.GetComponent<Image>().color = Color.white;
                                Combo_3_2.GetComponent<Image>().color = Color.white;
                                StartCoroutine("WaitThenChange", 4);
                                //ComboCard_1.SetActive(false);
                                Combo3_Visible = false;

                                if (PunchesThrown[2] == Combo3[2])
                                {
                                    //cool! all punches in current list match up with Combo 1
                                    //print("Combo 3 done! DORA RA RA!");

                                    //switch sound with CRAZY D
                                    PunchSoundCon.DORARA = true;
                                   
                                    RemovePunchesFromList();
                                }

                                else
                                {
                                    FailedCombo.Play();
                                    Combo_3_1.GetComponent<Image>().color = Color.white;
                                    Combo_3_2.GetComponent<Image>().color = Color.white;
                                    RemovePunchesFromList();
                                }
                            }

                        }

                        else
                        {
                            FailedCombo.Play();
                            Combo_3_1.GetComponent<Image>().color = Color.white;
                            Combo_3_2.GetComponent<Image>().color = Color.white;
                            RemovePunchesFromList();
                        }
                    }
                }

                else
                {
                    FailedCombo.Play();
                    Combo_3_1.GetComponent<Image>().color = Color.white;
                    Combo_3_2.GetComponent<Image>().color = Color.white;
                    RemovePunchesFromList();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////
        //COMBO 4: 1 2 3 2
        ///////////////////////////////////////////////////////////////////
        if (WhichComboAmICounting == 4)
        {
            if (Combo4_Visible == true)
            {
                ComboCard_4.SetActive(true);
            }

            if (Combo4_Visible == false)
            {
                ComboCard_4.SetActive(false);
            }


            if (PunchesThrown.Count != 0)
            {
                if (PunchesThrown[0] == Combo4[0])
                {
                    Combo_4_1.GetComponent<Image>().color = Color.green;

                    if (PunchesThrown.Count >= 2)
                    {
                        //print("there are 2 items in list");
                        if (PunchesThrown[1] == Combo4[1])
                        {
                            Combo_4_2.GetComponent<Image>().color = Color.green;
                            //print("Second element matches");

                            if (PunchesThrown.Count >= 3)
                            {
                                //print("there are 3 in the list now");

                                if (PunchesThrown[2] == Combo4[2])
                                {
                                    Combo_4_3.GetComponent<Image>().color = Color.green;

                                    if (PunchesThrown.Count >= 4)
                                    {
                                        if(PunchesThrown[3] == Combo4[3])
                                        {
                                            Combo_4_1.GetComponent<Image>().color = Color.white;
                                            Combo_4_2.GetComponent<Image>().color = Color.white;
                                            Combo_4_3.GetComponent<Image>().color = Color.white;
                                            StartCoroutine("WaitThenChange", 5);
                                            //ComboCard_1.SetActive(false);
                                            Combo4_Visible = false;

                                            //cool! all punches in current list match up with Combo 1
                                            //print("Combo 3 done! DORA RA RA!");

                                            //switch sound with CRAZY D
                                            PunchSoundCon.DORARA = true;
                                           
                                            RemovePunchesFromList();
                                        }

                                        else
                                        {
                                            FailedCombo.Play();
                                            Combo_4_1.GetComponent<Image>().color = Color.white;
                                            Combo_4_2.GetComponent<Image>().color = Color.white;
                                            Combo_4_3.GetComponent<Image>().color = Color.white;
                                            RemovePunchesFromList();
                                        }
                                    }
                                }

                                else
                                {
                                    FailedCombo.Play();
                                    Combo_4_1.GetComponent<Image>().color = Color.white;
                                    Combo_4_2.GetComponent<Image>().color = Color.white;
                                    Combo_4_3.GetComponent<Image>().color = Color.white;
                                    RemovePunchesFromList();
                                }
                            }

                        }

                        else
                        {
                            FailedCombo.Play();
                            Combo_4_1.GetComponent<Image>().color = Color.white;
                            Combo_4_2.GetComponent<Image>().color = Color.white;
                            Combo_4_3.GetComponent<Image>().color = Color.white;
                            RemovePunchesFromList();
                        }
                    }
                }

                else
                {
                    FailedCombo.Play();
                    Combo_4_1.GetComponent<Image>().color = Color.white;
                    Combo_4_2.GetComponent<Image>().color = Color.white;
                    Combo_4_3.GetComponent<Image>().color = Color.white;
                    RemovePunchesFromList();
                }
            }
        }


        ////////////////////////////////////////////////////////////////////
        //COMBO 5: 1 2 5 2
        //////////////////////////////////////////////////////////////////////
        if (WhichComboAmICounting == 5)
        {
            if (Combo5_Visible == true)
            {
                ComboCard_5.SetActive(true);
            }

            if (Combo5_Visible == false)
            {
                ComboCard_5.SetActive(false);
            }


            if (PunchesThrown.Count != 0)
            {
                if (PunchesThrown[0] == Combo5[0])
                {
                    Combo_5_1.GetComponent<Image>().color = Color.green;

                    if (PunchesThrown.Count >= 2)
                    {
                        //print("there are 2 items in list");
                        if (PunchesThrown[1] == Combo5[1])
                        {
                            Combo_5_2.GetComponent<Image>().color = Color.green;
                            //print("Second element matches");

                            if (PunchesThrown.Count >= 3)
                            {
                                //print("there are 3 in the list now");

                                if (PunchesThrown[2] == Combo5[2])
                                {
                                    Combo_5_3.GetComponent<Image>().color = Color.green;
                                    if (PunchesThrown.Count >= 4)
                                    {
                                        if (PunchesThrown[3] == Combo5[3])
                                        {

                                            Combo_5_1.GetComponent<Image>().color = Color.white;
                                            Combo_5_2.GetComponent<Image>().color = Color.white;
                                            Combo_5_3.GetComponent<Image>().color = Color.white;
                                            StartCoroutine("WaitThenChange", 6);
                                            //ComboCard_1.SetActive(false);
                                            Combo5_Visible = false;

                                            //cool! all punches in current list match up with Combo 1
                                            // print("Combo 3 done! DORA RA RA!");

                                            //switch sound with CRAZY D
                                            PunchSoundCon.DORARA = true;
                                           
                                            RemovePunchesFromList();
                                        }

                                        else
                                        {
                                            FailedCombo.Play();
                                            Combo_5_1.GetComponent<Image>().color = Color.white;
                                            Combo_5_2.GetComponent<Image>().color = Color.white;
                                            Combo_5_3.GetComponent<Image>().color = Color.white;
                                            RemovePunchesFromList();
                                        }
                                    }
                                }

                                else
                                {
                                    FailedCombo.Play();
                                    Combo_5_1.GetComponent<Image>().color = Color.white;
                                    Combo_5_2.GetComponent<Image>().color = Color.white;
                                    Combo_5_3.GetComponent<Image>().color = Color.white;
                                    RemovePunchesFromList();
                                }
                            }

                        }

                        else
                        {
                            FailedCombo.Play();
                            Combo_5_1.GetComponent<Image>().color = Color.white;
                            Combo_5_2.GetComponent<Image>().color = Color.white;
                            Combo_5_3.GetComponent<Image>().color = Color.white;
                            RemovePunchesFromList();
                        }
                    }
                }

                else
                {
                    FailedCombo.Play();
                    Combo_5_1.GetComponent<Image>().color = Color.white;
                    Combo_5_2.GetComponent<Image>().color = Color.white;
                    Combo_5_3.GetComponent<Image>().color = Color.white;
                    RemovePunchesFromList();
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////
        //COMBO 6: 1 6 3 2
        ////////////////////////////////////////////////////////////////////////
        if (WhichComboAmICounting == 6)
        {
            if (Combo6_Visible == true)
            {
                ComboCard_6.SetActive(true);
            }

            if (Combo6_Visible == false)
            {
                ComboCard_6.SetActive(false);
            }


            if (PunchesThrown.Count != 0)
            {
                if (PunchesThrown[0] == Combo6[0])
                {
                    Combo_6_1.GetComponent<Image>().color = Color.green;
                    if (PunchesThrown.Count >= 2)
                    {
                        //print("there are 2 items in list");
                        if (PunchesThrown[1] == Combo6[1])
                        {
                            Combo_6_2.GetComponent<Image>().color = Color.green;
                            //print("Second element matches");

                            if (PunchesThrown.Count >= 3)
                            {
                                //print("there are 3 in the list now");

                                if (PunchesThrown[2] == Combo6[2])
                                {
                                    Combo_6_3.GetComponent<Image>().color = Color.green;
                                    if (PunchesThrown.Count >= 4)
                                    {
                                        if (PunchesThrown[3] == Combo6[3])
                                        {
                                            Combo_6_1.GetComponent<Image>().color = Color.white;
                                            Combo_6_2.GetComponent<Image>().color = Color.white;
                                            Combo_6_3.GetComponent<Image>().color = Color.white;
                                            StartCoroutine("WaitThenChange", 7);
                                            //ComboCard_1.SetActive(false);
                                            Combo6_Visible = false;

                                            //cool! all punches in current list match up with Combo 1
                                            //print("Combo 3 done! DORA RA RA!");

                                            //switch sound with CRAZY D
                                            PunchSoundCon.DORARA = true;
                                           
                                            RemovePunchesFromList();
                                        }

                                        else
                                        {
                                            FailedCombo.Play();
                                            Combo_6_1.GetComponent<Image>().color = Color.white;
                                            Combo_6_2.GetComponent<Image>().color = Color.white;
                                            Combo_6_3.GetComponent<Image>().color = Color.white;
                                            RemovePunchesFromList();
                                        }
                                    }
                                }

                                else
                                {
                                    FailedCombo.Play();
                                    Combo_6_1.GetComponent<Image>().color = Color.white;
                                    Combo_6_2.GetComponent<Image>().color = Color.white;
                                    Combo_6_3.GetComponent<Image>().color = Color.white;
                                    RemovePunchesFromList();
                                }
                            }

                        }

                        else
                        {
                            FailedCombo.Play();
                            Combo_6_1.GetComponent<Image>().color = Color.white;
                            Combo_6_2.GetComponent<Image>().color = Color.white;
                            Combo_6_3.GetComponent<Image>().color = Color.white;
                            RemovePunchesFromList();
                        }
                    }
                }

                else
                {
                    FailedCombo.Play();
                    Combo_6_1.GetComponent<Image>().color = Color.white;
                    Combo_6_2.GetComponent<Image>().color = Color.white;
                    Combo_6_3.GetComponent<Image>().color = Color.white;
                    RemovePunchesFromList();
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////
        //COMBO 7: 2 3 2
        ///////////////////////////////////////////////////////////////////
        if (WhichComboAmICounting == 7)
        {
            if (Combo7_Visible == true)
            {
                ComboCard_7.SetActive(true);
            }

            if (Combo7_Visible == false)
            {
                ComboCard_7.SetActive(false);
            }


            if (PunchesThrown.Count != 0)
            {
                if (PunchesThrown[0] == Combo7[0])
                {
                    Combo_7_1.GetComponent<Image>().color = Color.green;
                    if (PunchesThrown.Count >= 2)
                    {
                        //print("there are 2 items in list");
                        if (PunchesThrown[1] == Combo7[1])
                        {
                            //print("Second element matches");
                            Combo_7_2.GetComponent<Image>().color = Color.green;
                            if (PunchesThrown.Count >= 3)
                            {
                                //print("there are 3 in the list now");

                                if (PunchesThrown[2] == Combo7[2])
                                {
                                    Combo_7_1.GetComponent<Image>().color = Color.white;
                                    Combo_7_2.GetComponent<Image>().color = Color.white;
                                    StartCoroutine("WaitThenChange", 8);
                                    //ComboCard_1.SetActive(false);
                                    Combo7_Visible = false;
                                    //cool! all punches in current list match up with Combo 1
                                    //print("Combo 3 done! DORA RA RA!");

                                    //switch sound with CRAZY D
                                    PunchSoundCon.DORARA = true;
                                  
                                    RemovePunchesFromList();
                                }

                                else
                                {
                                    FailedCombo.Play();
                                    Combo_7_1.GetComponent<Image>().color = Color.white;
                                    Combo_7_2.GetComponent<Image>().color = Color.white;
                                    RemovePunchesFromList();
                                }
                            }

                        }

                        else
                        {
                            FailedCombo.Play();
                            Combo_7_1.GetComponent<Image>().color = Color.white;
                            Combo_7_2.GetComponent<Image>().color = Color.white;
                            RemovePunchesFromList();
                        }
                    }
                }

                else
                {
                    FailedCombo.Play();
                    Combo_7_1.GetComponent<Image>().color = Color.white;
                    Combo_7_2.GetComponent<Image>().color = Color.white;
                    RemovePunchesFromList();
                }
            }
        }


        //////////////////////////////////////////////////////////////////
        //COMBO 8: 1 4 3 2
        //////////////////////////////////////////////////////////////////////
        if (WhichComboAmICounting == 8)
        {
            if (Combo8_Visible == true)
            {
                ComboCard_8.SetActive(true);
            }

            if (Combo8_Visible == false)
            {
                ComboCard_8.SetActive(false);
            }


            if (PunchesThrown.Count != 0)
            {
                if (PunchesThrown[0] == Combo8[0])
                {
                    Combo_8_1.GetComponent<Image>().color = Color.green;

                    if (PunchesThrown.Count >= 2)
                    {
                        //print("there are 2 items in list");
                        if (PunchesThrown[1] == Combo8[1])
                        {
                            Combo_8_2.GetComponent<Image>().color = Color.green;
                            //print("Second element matches");

                            if (PunchesThrown.Count >= 3)
                            {
                                //print("there are 3 in the list now");

                                if (PunchesThrown[2] == Combo8[2])
                                {
                                    Combo_8_3.GetComponent<Image>().color = Color.green;

                                    if (PunchesThrown.Count >= 4)
                                    {
                                        if (PunchesThrown[3] == Combo8[3])
                                        {
                                            Combo_8_1.GetComponent<Image>().color = Color.white;
                                            Combo_8_2.GetComponent<Image>().color = Color.white;
                                            Combo_8_3.GetComponent<Image>().color = Color.white;
                                            StartCoroutine("WaitThenChange", 1);
                                            //ComboCard_1.SetActive(false);
                                            Combo8_Visible = false;
                                            //cool! all punches in current list match up with Combo 1
                                            //print("Combo 3 done! DORA RA RA!");

                                            //switch sound with CRAZY D
                                            PunchSoundCon.DORARA = true;
                                          
                                            RemovePunchesFromList();
                                        }

                                        else
                                        {
                                            FailedCombo.Play();
                                            Combo_8_1.GetComponent<Image>().color = Color.white;
                                            Combo_8_2.GetComponent<Image>().color = Color.white;
                                            Combo_8_3.GetComponent<Image>().color = Color.white;
                                            RemovePunchesFromList();
                                        }
                                    }
                                }

                                else
                                {
                                    FailedCombo.Play();
                                    Combo_8_1.GetComponent<Image>().color = Color.white;
                                    Combo_8_2.GetComponent<Image>().color = Color.white;
                                    Combo_8_3.GetComponent<Image>().color = Color.white;
                                    RemovePunchesFromList();
                                }
                            }

                        }

                        else
                        {
                            FailedCombo.Play();
                            Combo_8_1.GetComponent<Image>().color = Color.white;
                            Combo_8_2.GetComponent<Image>().color = Color.white;
                            Combo_8_3.GetComponent<Image>().color = Color.white;
                            RemovePunchesFromList();
                        }
                    }
                }

                else
                {
                    FailedCombo.Play();
                    Combo_8_1.GetComponent<Image>().color = Color.white;
                    Combo_8_2.GetComponent<Image>().color = Color.white;
                    Combo_8_3.GetComponent<Image>().color = Color.white;
                    RemovePunchesFromList();
                }
            }
        }


    }
}
