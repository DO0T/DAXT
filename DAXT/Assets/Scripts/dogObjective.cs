using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogObjective : MonoBehaviour
{
    // Objs
    public GameObject dog;
    public GameObject guy;

    public journal j;

    public objectiveTracker objTrack;
    public dogDialogueText done;

    private void OnTriggerEnter(Collider other)
    {
        // Determine which object the mailItem collided with
        if (other.gameObject == guy)
        {
            // Run failTask if it collides with mailBox
            completeTask();
        }
    }

    public void completeTask()
    {
        j.obj1SpanishText.text = " ";
       j.obj1EnglishText.text = " ";


       j.compObj1SpanishText.text = "¡Oh, no! Luis ha perdido a su perro. ¡Necesita tu ayuda para encontrarlo!:\n\nEncuentra y recoge al perro (1/1)\nLlévale el perro a Luis (1/1)";
       j.compObj1EnglishText.text = "Oh No! Luis has lost his dog. He needs your help finding it!:\n\nFind and pick up the dog (1/1)\nBring the dog to Luis (1/1)";


        objTrack.StrikeThroughDogObjective();
        done.DoneDialogue();
        Destroy(dog);
    }
}
