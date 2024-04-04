using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class objectiveTracker : MonoBehaviour
{
    public TextMeshProUGUI objectiveList;
    public string mailObjective = "Letter Objective";

    void Start() {
        objectiveList.text = "Current Objectives: ";
    }

    public void AddMailToTracker() {
        objectiveList.text += "\n" + mailObjective;
    }
}
