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
        if (triggered.LastHitObject == thisObject)
        {
            trigger = true;
            Debug.Log("Triggered by object: " + thisObject.name);
        }
        // You can add an else block or other conditions as needed.
    }
}
