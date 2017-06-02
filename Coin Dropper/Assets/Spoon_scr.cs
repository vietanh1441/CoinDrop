using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon_scr : MonoBehaviour {
    private GameObject switch_obj;
    bool change;
    public GameObject coin;
    // Use this for initialization
    void Start() {
        change = false;
        switch_obj = transform.parent.gameObject;
    }

   

    // Update is called once per frame
    void Update() {
      
            
        
    }

    public void Change()
    {
        transform.rotation = Quaternion.Euler(0, 0, -transform.parent.rotation.z);
    }

 

}
