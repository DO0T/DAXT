using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dogDialogueText : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextObj;
    private int currentIndex = 0;
    private string[] texts = { "Hola, me llamo Juan.", "¿Como estas?" };
    private string completedText = "¡Gracias!";

    public void UpdateDialogue()
    {
        dialogueTextObj.text = texts[currentIndex];
    }

    public void DoneDialogue() {
        dialogueTextObj.text = completedText;
    }

    // Method to be called by the button to increment currentIndex
    public void NextText()
    {
        currentIndex++;
    }

    // Index getter
    public int getIndex() {
        return currentIndex;
    }
}
