using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public int score;
    GameObject central;
    Central central_scr;
    public GameObject hud_obj;
    public HUDText hd;
	// Use this for initialization
	void Start () {
        central = GameObject.FindGameObjectWithTag("Central");
        central_scr = central.GetComponent<Central>();
        GameObject g = Instantiate(hud_obj, new Vector3(0, 0, 0), Quaternion.identity);
        g.transform.parent = GameObject.FindGameObjectWithTag("UIRoot").transform;
        hd = g.GetComponent<HUDText>();
        g.GetComponent<UIFollowTarget>().target = transform;
        g.GetComponent<UIFollowTarget>().uiCamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddScore()
    {
        central_scr.AddScore(score);
        hd.Add(" " + score, Color.yellow, 0f);
    }

    void SetScore(int i)
    {
        score = i;
    }

    public void SetHudText()
    {

    }
}
