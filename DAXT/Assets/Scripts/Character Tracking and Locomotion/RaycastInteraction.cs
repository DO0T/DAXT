using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaycastInteraction : MonoBehaviour
{
    public float raycastDistance = 10.0f;
    public GameObject playerPrefab;
    private GameObject _lastHitObject; // Store the last hit object
    private TextMeshProUGUI uiText;

    public GameObject LastHitObject // Public property to access the last hit object
    {
        get { return _lastHitObject; }
    }

    void Start()
    {
        uiText = GetComponentInChildren<TextMeshProUGUI>();
        if (uiText == null)
        {
            Debug.LogError("No TextMeshProUGUI component found on the child of " + gameObject.name);
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
        if (audioSource != null)
        {
            audioSource.Play();
            Debug.Log("Playing audio on: " + obj.name);
        }
        else
        {
            Debug.LogWarning("Object does not have an Audiosource Component attached!");
        }
    }

    void DisplayText(GameObject obj)
    {
        if (uiText != null)
        {
            uiText.text = obj.name;
        }
    }
}


