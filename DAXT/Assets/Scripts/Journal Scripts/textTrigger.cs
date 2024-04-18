using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textTrigger : MonoBehaviour
{
    public GameObject triggered;
    public bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered.activeInHierarchy)
        {
            trigger = true;
            Debug.Log("Triggered by dialog");
        }
    }

}
