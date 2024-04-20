using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class NPCDialogue : MonoBehaviour
{
    // VR Controller
    private UnityEngine.XR.InputDevice rightHandController;

    // Reference to the dialogueText script
    public dialogueText dialogueTextScript;

    // Reference to objectiveTracker script
    public objectiveTracker objTrack;

    // Game Objects
    public GameObject dialogueBox;
    public GameObject mailItem;

    // State bools
    bool player_detection = false;
    bool mailAdded = false;

    public journal j;

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
                    // Check if on final dialogue
                    if (dialogueTextScript.getIndex() == 1) {
                        dialogueTextScript.UpdateDialogue();
                        
                        // make sure mail exists
                        if (mailItem != null) {
                            mailItem.SetActive(true);

                            j.obj2SpanishText.text = "María no encuentra su carta, pero ya no necesita enviarla. Por favor, tírela a la basura.:\n\nEncuentra y recoge la carta (0/1)\nLleva la carta a la papelera (0/1)";
                            j.obj2EnglishText.text = "Maria can't find her letter, but she doesn't need to send it anymore. Please throw it away for her.:\n\nFind and pick up the letter (0/1)\nBring the letter to the trash (0/1)";
                        }

                        // Add mail to task list
                        if (!mailAdded) {
                            objTrack.AddMailToTracker();
                            mailAdded = true;
                        }
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
