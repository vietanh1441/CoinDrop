using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Central : MonoBehaviour {
    private int score_p1, score_p2;
    private bool p1;
    private int check ;
    public GameObject coin_prefab;
    public GameObject switch_prefab;
    public GameObject goal_prefab;
    public Transform goal_parent;
	// Use this for initialization
	void Start () {
        p1 = true;
        score_p1 = 0;
        score_p2 = 0;
        check = 0;
        GenerateSwitch();
        GenerateGoal();
	}
	
    private void GenerateGoal()
    {
        int i;
        GameObject g;
        for(i = 0; i<14; i++)
        {
            g= Instantiate(goal_prefab, new Vector3(i -3.5f, -10, 0), Quaternion.identity);
            g.transform.parent = goal_parent;
            g.SendMessage("SetScore", Mathf.Abs((int)(i - 6.5f))+1);
        }
    }

    private void GenerateSwitch()
    {
        int i;
        GameObject g;
        for (i = 0; i < 4; i++)
        {
            g = Instantiate(switch_prefab, new Vector3(i*2, 1, 0), Quaternion.identity);
            g.transform.parent = transform;
        }
        for (i = 0; i < 5; i++)
        {
            g = Instantiate(switch_prefab, new Vector3(i * 2-1, -2, 0), Quaternion.identity);
            g.transform.parent = transform;
        }
        for (i = 0; i < 6; i++)
        {
            g = Instantiate(switch_prefab, new Vector3(i * 2-2, -5, 0), Quaternion.identity);
            g.transform.parent = transform;
        }
        for (i = 0; i < 7; i++)
        {
            g = Instantiate(switch_prefab, new Vector3(i * 2-3, -8, 0), Quaternion.identity);
            g.transform.parent = transform;
        }
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
