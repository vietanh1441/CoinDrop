using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Central : MonoBehaviour {
    private int score_p1, score_p2;
    private bool p1;
    private int check ;
    public GameObject coin_prefab;
	// Use this for initialization
	void Start () {
        p1 = true;
        score_p1 = 0;
        score_p2 = 0;
        check = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddMoving()
    {
        
        check++;
        Debug.Log("Add" + check);
    }

    void MinusMoving()
    {
        check--;
        Debug.Log("Minus" + check);
        if(check <= 0)
        {
            check = 0;
            NewTurn();
        }
    }

    void NewTurn()
    {
        Debug.Log("New Turn");
        Instantiate(coin_prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void AddScore(int i)
    {
        if(p1)
        {
            score_p1 += i;
            Debug.Log(score_p1);
        }
    }
}
