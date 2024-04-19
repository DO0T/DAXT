using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaycastInteraction : MonoBehaviour
{
    public float raycastDistance = 10.0f;
    public GameObject playerPrefab;
    private GameObject _lastHitObject; // Store the last hit object
    private TextMeshProUGUI uiText;
    private Dictionary<GameObject, DateTime> lastAudioPlayTime = new Dictionary<GameObject, DateTime>(); // Dictionary to track audio play timestamps

    public GameObject LastHitObject // Public property to access the last hit object
    {
        get { return _lastHitObject; }
    }

    void Start()
    {
        uiText = GetComponentInChildren<TextMeshProUGUI>();
        if (uiText == null)
        {
           // Debug.LogError("No TextMeshProUGUI component found on the child of " + gameObject.name);
        }
    }

    void Update()
    {
        if (playerPrefab == null || !playerPrefab.activeInHierarchy) return;

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, raycastDistance))
        {
            if (hitInfo.collider.CompareTag("Interactable"))
            {
                _lastHitObject = hitInfo.collider.gameObject; // Update the last hit object
                PlayAudio(_lastHitObject);
                if (_lastHitObject == gameObject)
                {
                    DisplayText(_lastHitObject);
                }
            }
        }
    }

    void PlayAudio(GameObject obj)
    {
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        if (audioSource != null && CanPlayAudio(obj))
        {
            audioSource.Play();
            Debug.Log("Playing audio on: " + obj.name);
            lastAudioPlayTime[obj] = DateTime.Now; // Update the last played time
        }
        else
        {
            Debug.LogWarning("Object does not have an Audiosource Component attached!");
        }
    }

    bool CanPlayAudio(GameObject obj)
    {
        if (lastAudioPlayTime.TryGetValue(obj, out DateTime lastPlayed))
        {
            return (DateTime.Now - lastPlayed).TotalSeconds > 60; // Check if more than 60 seconds have passed
        }
        return true; // If no record, play audio
    }

    void DisplayText(GameObject obj)
    {
        if (uiText != null)
        {
            uiText.text = obj.name;
        }
    }
}


