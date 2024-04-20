using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mailObjective : MonoBehaviour
{
    // Game Objects
    public GameObject mailItem;
    public GameObject trash1;
    public GameObject trash2;
    public GameObject mailBox;
    public GameObject player;
    private GameObject mailItemTemplate;
    public GameObject tryAgain;

    public journal j;

    public objectiveTracker objTrack;
    public dialogueText done;

    private Transform initialParent;
    private Vector3 initialPosition;

    void Start()
    {
        mailItemTemplate = Instantiate(mailItem, mailItem.transform.position, mailItem.transform.rotation);
        mailItemTemplate.SetActive(false);
        initialParent = mailItem.transform.parent;
        initialPosition = mailItem.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        // Determine which object the mailItem collided with
        if (other.gameObject == mailBox)
        {
            // Run failTask if it collides with mailBox
            failTask();
        }
        else if (other.gameObject == trash1 || other.gameObject == trash2)
        {
            // Run completeTask if it collides with either trash1 or trash2
            completeTask();
        }
    }

    public void failTask()
    {
        // Ensure there's a template to create a copy from
        if (mailItemTemplate != null)
        {
            tryAgain.SetActive(true);
            // Create a new copy from the template
            GameObject newMailItem = Instantiate(mailItemTemplate, initialPosition, Quaternion.identity, initialParent);
            newMailItem.SetActive(true); // Make sure the new object is active
            
            // If you need to replace the existing reference to mailItem with the new object
            if (mailItem != null)
            {
                Destroy(mailItem); // Remove the old mailItem
            }
            mailItem = newMailItem; // Update the reference to point to the new object
        }
        else
        {
            Debug.LogError("MailItem template is missing!");
        }
    }

    public void completeTask()
    {
        j.obj2SpanishText.text = " ";
       j.obj2EnglishText.text = " ";


       j.compObj2SpanishText.text = "María no encuentra su carta, pero ya no necesita enviarla. Por favor, tírela a la basura.:\n\nEncuentra y recoge la carta (1/1)\nLleva la carta a la papelera (1/1)";
       j.compObj2EnglishText.text = "Maria can't find her letter, but she doesn't need to send it anymore. Please throw it away for her.:\n\nFind and pick up the letter (1/1)\nBring the letter to the trash (1/1)";

        objTrack.StrikeThroughMailObjective();
        done.DoneDialogue();
        Destroy(mailItem);
        if (tryAgain != null)
        {
            Destroy(tryAgain);
        }
    }
}
