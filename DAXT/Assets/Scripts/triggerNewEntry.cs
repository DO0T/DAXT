using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerNewEntry : MonoBehaviour
{
    public RaycastInteraction triggered;
    public GameObject thisObject;
    public bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        trigger = false;
        if (triggered.hitObject == thisObject) {
            trigger = true;
            Debug.Log("Triggered by object");
            Debug.Log(thisObject);
        }
        /*
        else if ()
        {
            trigger = true;
            Debug.Log("Triggered by dialog");
            Debug.Log(thisObject);
        }
        */
    }
}
