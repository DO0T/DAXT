using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaycastInteraction : MonoBehaviour
{
    public float raycastDistance = 10.0f;
    public TextMeshProUGUI uiText;

    // Update is called once per frame
    void Update()
    {
        // Create a ray from the camera's position and direction
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        //Store information about what the raycast hits
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, raycastDistance)) 
        {
            //Check if the object has the Interactable tag
            if (hitInfo.collider.CompareTag("Interactable")) 
            {
                GameObject hitObject = hitInfo.collider.gameObject;
                PlayAudio(hitObject);
                DisplayText(hitObject);
            }
        }
    }

    void PlayAudio(GameObject obj) 
    {
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        if (audioSource != null) 
        {
            audioSource.clip.Play();
            Debug.Log("Playing audio on: " + obj.name); 
        }
        else 
        {
            Debug.LogWarning("Object does not have an Audiosource Component attached!");
        }
    }

    void DisplayText(GameObject obj) 
    {
        uiText.text = obj.name;
    }
}
