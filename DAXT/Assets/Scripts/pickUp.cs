using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pickUp : MonoBehaviour
{
    private GameObject item;
    private RaycastHit hit;
    public int pickedUpCount = 0;
    public int maxItems = 2;

    void Start()
    {
        // calls function to display instructions to users
        UpdateInstructions(); 
    }

    void Update()
    {   
        // when the player presses "E"...
        if (Input.GetKeyDown(KeyCode.E));
        {
            //Debug.Log("Key Pressed!");
            // ...if there is no item in hand...
           // if (item == null)
           // {
                // check if item in area can be picked up
                if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f))
                {
                    if (hit.collider.CompareTag("pickUp"))
                    {
                        // pick up the item
                        PickUpObject(hit.collider.gameObject);
                        Debug.Log("Picked up object!");
                    }
                }
           // }
           // else
           // {
                // if an item is in hand, drop it
             //   DropObject();
           // }
        }

        // places item in front of the player
        if (item != null)
        {
            item.transform.position = transform.position + transform.forward;
        }
    }

    void PickUpObject(GameObject obj)
    {
        // makes item able to be moved while picked up
        item = obj;
        item.GetComponent<Rigidbody>().isKinematic = true;

        // the player becomes the parent
        item.transform.parent = transform;

        // play sound on object
        AudioSource audioSource = item.GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

            // increment count
            pickedUpCount++;

        // update text
        UpdateInstructions();
    }

    void DropObject()
    {
        item.GetComponent<Rigidbody>().isKinematic = false;

        // player is no longer parent of item
        item.transform.parent = null;
        item = null;
    }

    void UpdateInstructions()
    {
        // finds the updateText object to use function
        updateText updater = FindObjectOfType<updateText>();
        
        if (updater != null)
        {
            //update text
            updater.pickedUpCount = pickedUpCount;
            updater.UpdateInstructions();
        }
    }
}
