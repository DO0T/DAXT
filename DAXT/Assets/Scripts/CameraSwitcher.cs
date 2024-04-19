using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // Array to hold cameras
    
    private int activeCameraIndex = 0;

    public GameObject playerPrefab; 

    private bool playerEnabled = false;

    public Canvas[] canvases; 

    void start() 
    {
        // Ensure taht only the first camera is active at startup
        for (int i = 0; i < cameras.Length; i++) 
        {
            cameras[i].gameObject.SetActive(i == activeCameraIndex);
        }

        playerPrefab.SetActive(false);
    }

    void Update()
    {
        if (!playerEnabled) 
        {
            if(Input.GetKeyDown(KeyCode.JoystickButton0)) 
            {
                SwitchCamera();
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton1) && activeCameraIndex == cameras.Length - 1) 
            {
                playerPrefab.SetActive(true);
                DisableCanvases();
                playerEnabled = true;
            }
        }
    }

    void SwitchCamera() 
    {
        //Disable the current camera
        cameras[activeCameraIndex].gameObject.SetActive(false);

        // Move to the next camera in the array
        activeCameraIndex = (activeCameraIndex + 1) % cameras.Length;

        // Enable the next camera
        cameras[activeCameraIndex].gameObject.SetActive(true);

        if (activeCameraIndex != cameras.Length - 1) 
        {
            playerPrefab.SetActive(false);
        }
    }

    void DisableCanvases() 
    {
        foreach (var canvas in canvases) 
        {
            canvas.gameObject.SetActive(false);
        }
    }
}

