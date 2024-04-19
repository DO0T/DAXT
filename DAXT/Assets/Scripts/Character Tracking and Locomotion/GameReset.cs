using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class GameReset : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Assign in the inspector
    public GameObject[] objectsToDisable; // Assign in the inspector, length should be 2
    public GameObject playerPrefab; // Assign the player prefab to re-enable

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        // Reset the counter to 0 and update the text display
        counterText.text = "0";

        // Disable the specified game objects
        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        // Re-enable the player prefab
        if (playerPrefab != null)
            playerPrefab.SetActive(true);
    }
}

