using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GazeChangeText : MonoBehaviour
{
    public string newText; // Text to change to
    public GameObject playerPrefab; // Reference to the player prefab
    
    private TextMeshPro textMesh;
    public Camera mainCamera;

    void Start()
    {
        textMesh = GetComponentInChildren<TextMeshPro>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check if the player prefab is active in the hierarchy
        if (playerPrefab == null || !playerPrefab.activeInHierarchy) return;

        RaycastHit hit;
        Vector3 forward = mainCamera.transform.TransformDirection(Vector3.forward) * 10;
        if (Physics.Raycast(mainCamera.transform.position, forward, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                // The cube is being looked at
                textMesh.text = newText;
            }
        }
    }
}

