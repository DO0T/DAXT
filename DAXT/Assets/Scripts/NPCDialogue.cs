using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class NPCDialogue : MonoBehaviour
{
    bool player_detection = false;
    private UnityEngine.XR.InputDevice rightHandController;

    // Reference to the dialogueText script
    public dialogueText dialogueTextScript;

    void Start() {
        InitializeRightController();
    }
    
    void InitializeRightController() {
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            rightHandController = devices[0]; // Assuming the first device is the one we want
            Debug.Log("Right-hand controller found: " + rightHandController.name);
        }
        else
        {
            Debug.LogWarning("Right-hand controller not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player_detection) {
            if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed) && primaryButtonPressed)
            {
                dialogueTextScript.UpdateDialogue();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player") {
            player_detection = true;
            InitializeRightController();
        }
    }

    private void OnTriggerExit(Collider other) {
        player_detection = false;
    }
}
