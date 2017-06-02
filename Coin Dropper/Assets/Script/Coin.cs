using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    bool down, right, left, stop;
    float speed = 0.05f;
    // Use this for initialization
    void Start()
    {
        down = true;
        right = false;
        left = false;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            return;
        }
        if (left)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y - speed, 0);
        }
        if (right)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y - speed, 0);
        }
        if (down)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);
        }
    }


    void TurnLeft()
    {
        down = false;
        left = true;
    }

    void TurnRight()
    {
        down = false;
        right = true;
    }

    void CancelTurn()
    {
        down = true;
        left = false;
        right = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if collide with the spoon
        // First, get the coord of the top of the spoon,
        //set the position at the top of the spoon and stop
        // register itself to the spoon
        if (other.tag == "Bottom")
        {
            //Hit switch
            other.gameObject.SendMessage("ActivateSwitch");
        }
        if (other.tag == "Spoon")
        {
            Spoon_scr scr = other.gameObject.GetComponent<Spoon_scr>();
            if (scr.coin == null)
            {
                stop = true;
                down = false;
                scr.coin = gameObject;
            }
            else
            {
                bool dir = other.transform.GetComponentInParent<Switch>().getDir();
                if (right)
                {
                    right = true;
                    down = false;
                }
                else
                {
                    left = true;
                    down = false;
                }
            }
        }
    }
}
