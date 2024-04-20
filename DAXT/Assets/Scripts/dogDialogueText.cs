using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dogDialogueText : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextObj;
    private int currentIndex = 0;
    
    private string[] texts = { "Hola, me llamo Juan.", "¿Como estas?\n\nA:Bien\tB:Mal", "¿Puedes ayudarme encontrar mi perro?" };
    private string completedText = "¡Gracias!";

    public void UpdateDialogue()
    {
        dialogueTextObj.text = texts[currentIndex];
    }

    public void DoneDialogue() {
        dialogueTextObj.text = completedText;
    }

    public void BadDialogue() {
        dialogueTextObj.text = "¡Ay no!";
    }

    public void GoodDialogue() {
        dialogueTextObj.text = "Eso es bueno.";
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
