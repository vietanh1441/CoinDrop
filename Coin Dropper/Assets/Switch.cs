using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private bool right;

    private GameObject spoon;

    // Use this for initialization
    void Start()
    {
        //testing
        right = SetSide();
        spoon = transform.GetChild(0).gameObject;
        SetAngle();

    }

    bool SetSide()
    {
        int i = Random.Range(0, 2);
        if (i == 1)
            return true;
        return false;
    }

    void SetAngle()
    {
        if (!right)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
            spoon.SendMessage("Change");

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
            spoon.SendMessage("Change");
        }
    }

    public bool getDir()
    {
        return right;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActivateSwitch()
    {
        if (right)
        {
            right = false;

        }
        else
        {
            right = true;

        }
        SetAngle();

        spoon.SendMessage("Release");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            ActivateSwitch();
        }
    }
}