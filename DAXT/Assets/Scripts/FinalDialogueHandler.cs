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
    public GameObject Player;
    public GameObject EndScreen;

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
        dialogueBox.SetActive(false);
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
            if (!question1 && !question2 && !question3 && !question4 && !fitb1 && !fitb2 && !fitb3 && !fitb4) {
                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed))
                {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasPrimaryButtonPressedLastFrame && primaryButtonPressed)
                    {
                        // Check if on Question 1
                        if (dialogueTextScript.getIndex() == 1) {
                            dialogueTextScript.UpdateDialogue();
                            question1 = true;
                        }
                        else if (dialogueTextScript.getIndex() == 2) {
                            dialogueTextScript.UpdateDialogue();
                            question2 = true;
                        }
                        else if (dialogueTextScript.getIndex() == 3) {
                            dialogueTextScript.UpdateDialogue();
                            question3 = true;
                        }
                        else if (dialogueTextScript.getIndex() == 4) {
                            dialogueTextScript.UpdateDialogue();
                            question4 = true;
                        }
                        else if (dialogueTextScript.getIndex() == 5) {
                            dialogueTextScript.UpdateDialogue();
                            fitb1 = true;
                        }
                        else if (dialogueTextScript.getIndex() == 6) {
                            dialogueTextScript.UpdateDialogue();
                            fitb2 = true;
                        }
                        else if (dialogueTextScript.getIndex() == 7) {
                            dialogueTextScript.UpdateDialogue();
                            fitb3 = true;
                        }
                        else if (dialogueTextScript.getIndex() == 8) {
                            dialogueTextScript.UpdateDialogue();
                            fitb4 = true;
                        }
                        else if (dialogueTextScript.getIndex() == 9) {
                            Player.SetActive(false);
                            EndScreen.SetActive(true);
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
                        dialogueTextScript.FirstDialogue1();
                        dialogueTextScript.NextText();
                        question1 = false;
                    }

                    wasPrimaryButtonPressedLastFrame = primaryButtonPressed;
                }

                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool secondaryButtonPressed)) {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasSecondaryButtonPressedLastFrame && secondaryButtonPressed)
                    {
                        dialogueTextScript.SecondDialogue1();
                        dialogueTextScript.NextText();
                        question1 = false;
                    }

                    wasSecondaryButtonPressedLastFrame = secondaryButtonPressed;
                }
            }
            else if (question2) {
                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed))
                {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasPrimaryButtonPressedLastFrame && primaryButtonPressed)
                    {
                        dialogueTextScript.FirstDialogue2();
                        dialogueTextScript.NextText();
                        question2 = false;
                    }

                    wasPrimaryButtonPressedLastFrame = primaryButtonPressed;
                }

                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool secondaryButtonPressed)) {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasSecondaryButtonPressedLastFrame && secondaryButtonPressed)
                    {
                        dialogueTextScript.SecondDialogue2();
                        dialogueTextScript.NextText();
                        question2 = false;
                    }

                    wasSecondaryButtonPressedLastFrame = secondaryButtonPressed;
                }
            }
            else if (question3) {
                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed))
                {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasPrimaryButtonPressedLastFrame && primaryButtonPressed)
                    {
                        dialogueTextScript.FirstDialogue3();
                        dialogueTextScript.NextText();
                        question3 = false;
                    }

                    wasPrimaryButtonPressedLastFrame = primaryButtonPressed;
                }

                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool secondaryButtonPressed)) {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasSecondaryButtonPressedLastFrame && secondaryButtonPressed)
                    {
                        dialogueTextScript.SecondDialogue3();
                        dialogueTextScript.NextText();
                        question3 = false;
                    }

                    wasSecondaryButtonPressedLastFrame = secondaryButtonPressed;
                }
            }
            else if (question4) {
                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed))
                {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasPrimaryButtonPressedLastFrame && primaryButtonPressed)
                    {
                        dialogueTextScript.FirstDialogue4();
                        dialogueTextScript.NextText();
                        question4 = false;
                    }

                    wasPrimaryButtonPressedLastFrame = primaryButtonPressed;
                }

                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool secondaryButtonPressed)) {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasSecondaryButtonPressedLastFrame && secondaryButtonPressed)
                    {
                        dialogueTextScript.SecondDialogue4();
                        dialogueTextScript.NextText();
                        question4 = false;
                    }

                    wasSecondaryButtonPressedLastFrame = secondaryButtonPressed;
                }
            }
            else if (fitb1) {
                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed))
                {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasPrimaryButtonPressedLastFrame && primaryButtonPressed)
                    {
                        dialogueTextScript.FitFirstChoice1();
                    }

                    wasPrimaryButtonPressedLastFrame = primaryButtonPressed;
                }

                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool secondaryButtonPressed)) {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasSecondaryButtonPressedLastFrame && secondaryButtonPressed)
                    {
                        dialogueTextScript.FitSecondChoice1();
                        dialogueTextScript.NextText();
                        fitb1 = false;
                    }

                    wasSecondaryButtonPressedLastFrame = secondaryButtonPressed;
                }
            }
            else if (fitb2) {
                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed))
                {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasPrimaryButtonPressedLastFrame && primaryButtonPressed)
                    {
                        dialogueTextScript.FitFirstChoice2();
                        dialogueTextScript.NextText();
                        fitb2 = false;
                    }

                    wasPrimaryButtonPressedLastFrame = primaryButtonPressed;
                }

                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool secondaryButtonPressed)) {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasSecondaryButtonPressedLastFrame && secondaryButtonPressed)
                    {
                        dialogueTextScript.FitSecondChoice2();
                    }

                    wasSecondaryButtonPressedLastFrame = secondaryButtonPressed;
                }
            }
            else if (fitb3) {
                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed))
                {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasPrimaryButtonPressedLastFrame && primaryButtonPressed)
                    {
                        dialogueTextScript.FitFirstChoice3();
                        dialogueTextScript.NextText();
                        fitb3 = false;
                    }

                    wasPrimaryButtonPressedLastFrame = primaryButtonPressed;
                }

                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool secondaryButtonPressed)) {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasSecondaryButtonPressedLastFrame && secondaryButtonPressed)
                    {
                        dialogueTextScript.FitSecondChoice3();
                    }

                    wasSecondaryButtonPressedLastFrame = secondaryButtonPressed;
                }
            }
            else if (fitb4) {
                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool primaryButtonPressed))
                {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasPrimaryButtonPressedLastFrame && primaryButtonPressed)
                    {
                        dialogueTextScript.FitFirstChoice4();
                    }

                    wasPrimaryButtonPressedLastFrame = primaryButtonPressed;
                }

                if (rightHandController.isValid && rightHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool secondaryButtonPressed)) {
                    // Check if the button was not pressed last frame and is pressed now
                    if (!wasSecondaryButtonPressedLastFrame && secondaryButtonPressed)
                    {
                        dialogueTextScript.FitSecondChoice4();
                        dialogueTextScript.NextText();
                        fitb4 = false;
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
