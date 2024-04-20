using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pickUp : MonoBehaviour
{
    private GameObject item;
    private RaycastHit hit;
    public int pickedUpCount = 0;
    public int maxItems = 2;

    public journal j;

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
            // ...if there is no item in hand...
            if (item == null)
            {
                // check if item in area can be picked up
                if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f))
                {
                    if (hit.collider.CompareTag("dog"))
                    {
                        // pick up the item
                        PickUpObject(hit.collider.gameObject);
                        Debug.Log("Picked up dog!");
                        j.obj1SpanishText.text = "¡Oh, no! Luis ha perdido a su perro. ¡Necesita tu ayuda para encontrarlo!:\n\nEncuentra y recoge al perro (1/1)\nLlévale el perro a Luis (0/1)";
                        j.obj1EnglishText.text = "Oh No! Luis has lost his dog. He needs your help finding it!:\n\nFind and pick up the dog (1/1)\nBring the dog to Luis (0/1)";
                    }

                    else if (hit.collider.CompareTag("letter"))
                    {
                        // pick up the item
                        PickUpObject(hit.collider.gameObject);
                        Debug.Log("Picked up letter!");
                        j.obj2SpanishText.text = "María no encuentra su carta, pero ya no necesita enviarla. Por favor, tírela a la basura.:\n\nEncuentra y recoge la carta (1/1)\nLleva la carta a la papelera (0/1)";
                        j.obj2EnglishText.text = "Maria can't find her letter, but she doesn't need to send it anymore. Please throw it away for her.:\n\nFind and pick up the letter (1/1)\nBring the letter to the trash (0/1)";
                    }
                }
            }
            else
            {
                // if an item is in hand, drop it
                DropObject();
                if(j.obj1SpanishText.text == "¡Oh, no! Luis ha perdido a su perro. ¡Necesita tu ayuda para encontrarlo!:\n\nEncuentra y recoge al perro (1/1)\nLlévale el perro a Luis (0/1)"){
                    j.obj1SpanishText.text = "¡Oh, no! Luis ha perdido a su perro. ¡Necesita tu ayuda para encontrarlo!:\n\nEncuentra y recoge al perro (0/1)\nLlévale el perro a Luis (0/1)";
                    j.obj1EnglishText.text = "Oh No! Luis has lost his dog. He needs your help finding it!:\n\nFind and pick up the dog (0/1)\nBring the dog to Luis (0/1)";
                }
                
                if(j.obj2SpanishText.text == "María no encuentra su carta, pero ya no necesita enviarla. Por favor, tírela a la basura.:\n\nEncuentra y recoge la carta (1/1)\nLleva la carta a la papelera (0/1)"){
                    j.obj2SpanishText.text = "María no encuentra su carta, pero ya no necesita enviarla. Por favor, tírela a la basura.:\n\nEncuentra y recoge la carta (0/1)\nLleva la carta a la papelera (0/1)";
                    j.obj2EnglishText.text = "Maria can't find her letter, but she doesn't need to send it anymore. Please throw it away for her.:\n\nFind and pick up the letter (0/1)\nBring the letter to the trash (0/1)";
                }
               
            }
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
