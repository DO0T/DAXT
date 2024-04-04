using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogObjective : MonoBehaviour
{
    // Objs
    public GameObject dog;
    public GameObject guy;

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
        objTrack.StrikeThroughDogObjective();
        done.DoneDialogue();
        Destroy(dog);
    }
}
