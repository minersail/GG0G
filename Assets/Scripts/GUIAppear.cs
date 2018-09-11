using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIAppear : MonoBehaviour {

    //private bool guiShow = false;
    Texture riddle;
    public static int numCompleted;
    private bool check1, check2, check3, done = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    public static int getNC()
    {
        return numCompleted;
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");

        if (collision.gameObject.tag == "Player" && !done)
        {
            if (!(check1 && check2 && check3) && this.tag == "check1")
            {
                numCompleted++;
                check1 = true;
            }
            else if (check1 && !(check2 && check3) && this.tag == "check2")
            {
                numCompleted++;
                check2 = true;
            }
            else if (check1 && check2 && !check3 && this.tag == "check3")
            {
                numCompleted++;
                check3 = true;
                done = true;
                

            }
        }
            
    }
}
