using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class objectiveTracker : MonoBehaviour
{
    public TextMeshProUGUI objectiveList;
    public string mailObjective = "Letter Objective";

    // States
    public bool mailAdded = false;

    void Start() {
        objectiveList.text = "Current Objectives: ";
    }

    public void AddMailToTracker() {
        objectiveList.text += "\n" + mailObjective;
        mailAdded = true;
    }

    // Call this method to update the last added objective text with a strikethrough
    public void StrikeThroughMailObjective()
    {
            // Remove the last added objective text
            objectiveList.text = objectiveList.text.Replace("\n" + mailObjective, "");
            
            // Add it back with strikethrough tags
            objectiveList.text += "\n<s>" + mailObjective + "</s>";
    }

}
