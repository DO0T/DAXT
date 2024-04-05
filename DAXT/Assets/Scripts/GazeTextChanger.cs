using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTextChanger : MonoBehaviour
{
    public CubeTextData textdata;
    public TextMesh textMesh;

    private void Update() 
    {
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, forward, out hit)) 
        {
            if(hit.collider.gameObject == this.gameObject) 
            {
                textMesh.text = textdata.textToShow;
            }
        }
    }
}
