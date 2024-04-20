using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class finalDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextObj;
    private int currentIndex = 0;
    
    private string[] texts = { "¡Hola!", "¿Como estas hoy?\n\nA:Estoy bien, gracias.\nB:No estoy muy bien.", "¿Qué planes tienes para esta noche?\n\nA:Voy a ir al museo.\nB:Prefiero quedarme en casa.", "¿Dónde me recomiendas comer?\n\nA:El café en la esquina es excelente.\nB:Hay un restaurante muy bueno por aquí", "¿Sabes cómo llegar al museo?\n\nA:Sí, cruce la calle y gire a la izquierda.\nB:No, no estoy seguro.", "¿Dónde puedo comprar un café?\n\nFill in the blank to respond:\n'Puedes comprar un café en el _____.'\nA: banco\tB: café", "Necesito comida.\n\nFill in the blank to respond:\n'El _____ está cerca de aquí.'\nA: supermercado\tB: museo", "¿Dónde puedo ver arte?\n\nFill in the blank to respond:\n'Puedes ver arte en el _____.'\nA: museo\tB: farola", "Necesito dinero.\n\nFill in the blank to respond:\n'Puedes conseguir dinero en el _____.'\nA: buzon\tB: banco", "¡Adios!\n\nPress A to finish." };
    private string completedText = "¡Adios!";


    // General Text Handling Functions

    public void UpdateDialogue()
    {
        dialogueTextObj.text = texts[currentIndex];
    }


    // Multiple Choice Functions

    public void SecondDialogue1() {
        dialogueTextObj.text = "Lo siento oír eso.";
    }

    public void FirstDialogue1() {
        dialogueTextObj.text = "¡Qué bueno!";
    }

    public void SecondDialogue2() {
        dialogueTextObj.text = "A veces es bueno relajarse en casa.";
    }

    public void FirstDialogue2() {
        dialogueTextObj.text = "¡Divertido!";
    }

    public void SecondDialogue3() {
        dialogueTextObj.text = "Perfecto, adoro la comida.";
    }

    public void FirstDialogue3() {
        dialogueTextObj.text = "¡Gracias, me encanta el café!";
    }

    public void SecondDialogue4() {
        dialogueTextObj.text = "Entiendo, buscaré un mapa entonces.";
    }

    public void FirstDialogue4() {
        dialogueTextObj.text = "¡Gracias, eso es muy útil!";
    }


    // Fill in the blank response options

    public void FitFirstChoice1() {
        dialogueTextObj.text = "¿Dónde puedo comprar un café?\n\nTRY AGAIN:\n'Puedes comprar un café en el <color=#FF0000>banco</color>.'\nA: banco\tB: café";
    }

    public void FitSecondChoice1() {
        dialogueTextObj.text = "Well Done!\n\nPuedes comprar un café en el <color=#00FF00>café</color>.\n\nPress A to continue.";
    }

    public void FitFirstChoice2() {
        dialogueTextObj.text = "Well Done!\nEl <color=#00FF00>supermercado</color> está cerca de aquí.\n\nPress A to continue.";
    }

    public void FitSecondChoice2() {
        dialogueTextObj.text = "Necesito comida.\n\nTRY AGAIN:\n'El <color=#FF0000>museo</color> está cerca de aquí.'\nA: supermercado\tB: museo";
    }

    public void FitFirstChoice3() {
        dialogueTextObj.text = "Well Done!\nPuedes ver arte en el <color=#00FF00>museo</color>.\n\nPress A to continue.";
    }

    public void FitSecondChoice3() {
        dialogueTextObj.text = "¿Dónde puedo ver arte?\n\nTRY AGAIN:\n'Puedes ver arte en el <color=#FF0000>farola</color>.'\nA: museo\tB: farola";
    }

    public void FitFirstChoice4() {
        dialogueTextObj.text = "Necesito dinero.\n\nTRY AGAIN:\n'Puedes conseguir dinero en el <color=#FF0000>buzon</color>.'\nA: buzon\tB: banco";
    }

    public void FitSecondChoice4() {
        dialogueTextObj.text = "Well Done!\n'Puedes conseguir dinero en el <color=#00FF00>banco</color>.\n\nPress A to continue.";
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