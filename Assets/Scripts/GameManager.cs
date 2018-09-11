using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool canPush;
    private bool didPush;
    float timer = 0.0f;

    [SerializeField]
    GameObject g;

    [SerializeField]
    Vector3 startPos;

	// Use this for initialization
	void Start () {
        canPush = false;
        didPush = false;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (Input.GetKeyDown("r"))
        {
            g.transform.position = startPos;
        }
    }

    public void setCanPush(bool b)
    {
        canPush = b;
    }
    public bool getCanPush()
    {
        return canPush;
    }
    public void setDidPush(bool b)
    {
        didPush = b;
    }
    public bool getDidPush()
    {
        return didPush;
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 50, 20), "" + timer.ToString("0"));

        //GUI.Box(new Rect(10, 40, 50, 20), "" + GUIAppear.getNC());
    }

}
