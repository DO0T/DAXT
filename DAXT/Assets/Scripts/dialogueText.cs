using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueText : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextObj;
    private int currentIndex = 0;
    private string[] texts = { "¡Hola Amigo!", "¿Pon eso en el bote de basura por favor?" };
    private string completedText = "¡Gracias!"

    public void UpdateDialogue()
    {
        dialogueTextObj.text = texts[currentIndex];
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
