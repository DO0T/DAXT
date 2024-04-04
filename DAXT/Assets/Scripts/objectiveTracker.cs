using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class objectiveTracker : MonoBehaviour
{
    public TextMeshProUGUI objectiveList;
    public string mailObjective = "Letter Objective";
    public string dogObjective = "Dog Objective";

    // States
    public bool mailAdded = false;
    public int dogAdded = 0;

    void Start() {
        objectiveList.text = "Current Objectives: ";
    }

    public void AddMailToTracker() {
        objectiveList.text += "\n" + mailObjective;
        mailAdded = true;
    }

    public void AddDogToTracker() {
        objectiveList.text += "\n" + dogObjective;
        if (mailAdded) {
            dogAdded = 2;
        }
        else {
            dogAdded = 1;
        }
    }

    // Call this method to update the last added objective text with a strikethrough
    public void StrikeThroughMailObjective()
    {
        if (dogAdded == 0) {
            // Remove the last added objective text
            objectiveList.text = objectiveList.text.Replace("\n" + mailObjective, "");
            
            // Add it back with strikethrough tags
            objectiveList.text += "\n<s>" + mailObjective + "</s>";
        }

        if (dogAdded == 2) {
            // Remove the last added objective text
            objectiveList.text = objectiveList.text.Replace("\n" + mailObjective, "");
            
            // Add it back with strikethrough tags
            objectiveList.text += "\n<s>" + mailObjective + "</s>";
        }

        if (dogAdded == 1) {
            // Remove the last added objective text
            objectiveList.text = objectiveList.text.Replace("\n" + mailObjective, "");
            
            // Add it back with strikethrough tags
            objectiveList.text += "\n<s>" + mailObjective + "</s>";
        }
    }

     public void StrikeThroughDogObjective()
    {
        if (dogAdded == 1) {
            // Remove the last added objective text
            objectiveList.text = objectiveList.text.Replace("\n" + dogObjective, "");
            
            // Add it back with strikethrough tags
            objectiveList.text += "\n<s>" + dogObjective + "</s>";
        }

        if (dogAdded == 2) {
            // Remove the last added objective text
            objectiveList.text = objectiveList.text.Replace("\n" + dogObjective, "");
            
            // Add it back with strikethrough tags
            objectiveList.text += "\n<s>" + dogObjective + "</s>";
        }
    }

}
