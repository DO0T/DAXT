using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerNewEntry : MonoBehaviour
{
    public RaycastInteraction triggered;
    public GameObject thisObject;
    public bool trigger;

    void Start()
    {
        trigger = false;
    }

    void Update()
    {
        trigger = false;
        if (triggered.hitObject == thisObject) {
            trigger = true;
            Debug.Log("Triggered by object");
            Debug.Log(thisObject);
        }
    }
}
