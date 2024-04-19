using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class FinalDialogueHandler : MonoBehaviour
{
    // VR Controller
    private UnityEngine.XR.InputDevice rightHandController;

    // Reference to the finalDialogue script
    public finalDialogue dialogueTextScript;

    // Reference to objectiveTracker script
    //public objectiveTracker objTrack;

    // Game Objects
    public GameObject dialogueBox;

    // State bools
    bool player_detection = false;
    bool question1 = false;
    bool question2 = false;
    bool question3 = false;
    bool question4 = false;
    bool fitb1 = false;
    bool fitb2 = false;
    bool fitb3 = false;
    bool fitb4 = false;

    // This is needed for computers pushing 120+ fps
    private bool wasSecondaryButtonPressedLastFrame = false;
    private bool wasPrimaryButtonPressedLastFrame = false;

    void Start() {
        //dialogueBox.SetActive(false);
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
            if (!question1) {
                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed))
                {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasPrimaryButtonPressedLastFrame && primaryButtonPressed)
                    {
                        // Check if on final dialogue
                        if (dialogueTextScript.getIndex() == 1) {
                            dialogueTextScript.UpdateDialogue();
                            question1 = true;
                        }
                        else if (dialogueTextScript.getIndex() == 2) {
                            dialogueTextScript.UpdateDialogue();
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
            else if (question1) {
                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed))
                {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasPrimaryButtonPressedLastFrame && primaryButtonPressed)
                    {
                        dialogueTextScript.GoodDialogue();
                        dialogueTextScript.NextText();
                        question1 = false;
                    }

                    wasPrimaryButtonPressedLastFrame = primaryButtonPressed;
                }

                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool secondaryButtonPressed)) {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasSecondaryButtonPressedLastFrame && secondaryButtonPressed)
                    {
                        dialogueTextScript.BadDialogue();
                        dialogueTextScript.NextText();
                        question1 = false;
                    }

                    wasSecondaryButtonPressedLastFrame = secondaryButtonPressed;
                }
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
