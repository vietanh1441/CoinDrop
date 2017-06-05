using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public int score;
    GameObject central;
    Central central_scr;
	// Use this for initialization
	void Start () {
        central = GameObject.FindGameObjectWithTag("Central");
        central_scr = central.GetComponent<Central>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddScore()
    {
        central_scr.AddScore(score);
    }
}
