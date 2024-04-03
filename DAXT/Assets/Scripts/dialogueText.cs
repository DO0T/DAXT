using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueText : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextObj;
    private int currentIndex = 0;
    private string[] texts = { "hi", "Second text", "Third text", "Fourth text", "Fifth text", "Sixth text" };

    public void UpdateDialogue()
    {
        dialogueTextObj.text = texts[currentIndex];
    }
}
