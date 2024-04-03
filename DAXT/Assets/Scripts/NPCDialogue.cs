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
    public GameObject dialogueBox;
    public GameObject mailItem;

    // This is needed for computers pushing 120+ fps
    private bool wasPrimaryButtonPressedLastFrame = false;

    void Start() {
        dialogueBox.SetActive(false);
        mailItem.SetActive(false);
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

    void Update()
    {
        if (player_detection) {
            if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed))
            {
                // Check if the button was not pressed last frame and is pressed now
                if (!wasPrimaryButtonPressedLastFrame && primaryButtonPressed)
                {
                    Debug.Log("Button Pressed");
                    if (dialogueTextScript.getIndex() == 1) {
                        dialogueTextScript.UpdateDialogue();
                        mailItem.SetActive(true);
                    }
                    else {
                        dialogueTextScript.UpdateDialogue();
                        dialogueTextScript.NextText();
                    }
                }
                // Update the last frame state for the next frame
                wasPrimaryButtonPressedLastFrame = primaryButtonPressed;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.name == "Player") {
            player_detection = true;
            InitializeRightController();
            dialogueBox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        player_detection = false;
        dialogueBox.SetActive(false);
    }
}
