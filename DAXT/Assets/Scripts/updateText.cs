using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class updateText : MonoBehaviour
{
    public TextMeshProUGUI instructionsText;
    public int pickedUpCount;
    public int maxItems = 2;

    public void UpdateInstructions()
    {
        // makes sure the text doesnt go past the maxItems variable
        pickedUpCount = Mathf.Clamp(pickedUpCount, 0, maxItems);

        instructionsText.text = "Pick up " + maxItems + " items: (" + pickedUpCount + "/" + maxItems + ")";
    }
}
