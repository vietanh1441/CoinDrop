using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    bool down, right, left, stop, follow;
    float speed = 0.1f;
    Vector3 target = new Vector3(0, 0, 0);
    // Use this for initialization
    void Start()
    {
        //At start, the coin needs to follow the mouse position but stay at starting point
        //everything needs to be false at the coin has yet to roll
        //once player click, the coin drop 
        transform.parent = GameObject.FindGameObjectWithTag("Central").transform;

        follow = true;
        down = true;
        right = false;
        left = false;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            Follow();
            if (Input.GetMouseButtonDown(0))
            {
                Drop();
            }


            return;
        }
        if (stop)
        {
            if (Vector3.Distance(transform.position, target) < 0.3f)
            {
                stop = false; 
                return;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);
            }
        }
        if (left)
        {
            if (Vector3.Distance(transform.position, target) < 0.15f)
            {
                transform.position = target;
                left = false;
                down = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x - speed, transform.position.y - speed, 0);
            }
        }
        if (right)
        {
            if (Vector3.Distance(transform.position, target) < 0.15f)
            {
                transform.position = target;
                right = false;
                down = true;
            }
            else
            {
                transform.position = new Vector3(transform.position.x + speed, transform.position.y - speed, 0);
            }
            
        }
        if (down)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, 0);
        }
    }

    void Follow()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector2(Mathf.RoundToInt(mousePosition.x+0.5f)-0.5f, 3);
        if(transform.position.x < -0.5f)
        {
            transform.position = new Vector2( -0.5f, 3);
        }
        if (transform.position.x > 6.5f)
        {
            transform.position = new Vector2(6.5f, 3);
        }
    }

    void Drop()
    {
        follow = false;
        transform.parent.SendMessage("AddMoving");
    }

    void TurnLeft()
    {
        down = false;
        left = true;
        target = new Vector3(transform.position.x - 1f, transform.position.y - 1f, transform.position.z);
    }

    void TurnRight()
    {
        down = false;
        right = true;
        target = new Vector3(transform.position.x + 1f, transform.position.y - 1f, transform.position.z);
    }

    void CancelTurn()
    {
        down = true;
        left = false;
        right = false;
    }

    void BeFree()
    {
        stop = false;
        down = true;
        transform.parent.gameObject.SendMessage("AddMoving");
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
        if(other.tag == "Goal")
        {
            other.gameObject.SendMessage("AddScore");
           // StopOrder(other.transform.position);
            //Play Reach goal animation;
            Invoke("Finish", 1);
        }
        if (other.tag == "Spoon")
        {
            Spoon_scr scr = other.gameObject.GetComponent<Spoon_scr>();
            if (scr.coin == null)
            {
                StopOrder(other.transform.position);
                scr.coin = gameObject;
            }
            else
            {
                bool dir = other.transform.GetComponentInParent<Switch>().getDir();
                if (dir)
                {
                    TurnRight();
                }
                else
                {
                    TurnLeft();
                }
            }
        }
    }

    void Finish()
    {
        transform.parent.gameObject.SendMessage("MinusMoving");
        Destroy(gameObject);
    }

    private void StopOrder(Vector3 t)
    {
        target = t;
        stop = true;
        down = false;
        transform.parent.gameObject.SendMessage("MinusMoving");
    }
}
