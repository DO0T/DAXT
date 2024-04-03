using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class journal : MonoBehaviour
{
   public GameObject currentJournalPage;
    public GameObject completedJournalPage;
    //public GameObject vocabJournalPage;

    public int obj1_task1 = 0;
    public int obj1_task2 = 0;

    public int obj2_task1 = 0;
    public int obj2_task2 = 0;

    public TMP_Text Current_titleText;
    public TextMeshProUGUI Current_body1Text;
    public TextMeshProUGUI Current_body2Text;
    public TMP_Text Completed_titleText;
    public TextMeshProUGUI Completed_body1Text;
    public TextMeshProUGUI Completed_body2Text;
    //public TextMeshProUGUI bodyText;
    private bool isSpanish = false;

    private Dictionary<string, string> englishToSpanishTranslations = new Dictionary<string, string>();

    void Start(){
        HideAllPages();

        // Populate the English to Spanish translations dictionary
        englishToSpanishTranslations.Add("Current Objectives", "Objetivos Actuales");
        englishToSpanishTranslations.Add("Completed Objectives", "Objetivos Completados");
        englishToSpanishTranslations.Add("Oh No! Luis has lost his dog. He needs your help finding it!:\nFind and pick up the dog (" + obj1_task1 + "/1)\nBring the dog to Luis (" + obj1_task2 + "/1)", "¡Oh, no! Luis ha perdido a su perro. ¡Necesita tu ayuda para encontrarlo!:\nEncuentra y recoge al perro (0/1)\nLlévale el perro a Luis (0/1)");
        englishToSpanishTranslations.Add("Maria can't find her letter, but she doesn't need to send it anymore. Please throw it away for her.:" + "\nFind and pick up the letter (" + obj2_task1 + "/1)\nBring the letter to the trash (" + obj2_task2 + "/1)", "María no encuentra su carta, pero ya no necesita enviarla. Por favor, tírela a la basura.:" + "\nEncuentra y recoge la carta (0/1)\nLleva la carta a la papelera (0/1)");
    }

    void HideAllPages(){
        currentJournalPage.SetActive(false);
        completedJournalPage.SetActive(false);
        //vocabJournalPage.SetActive(false);
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowCurrentPage();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowCompletedPage();   
        }
       /* else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowVocabPage();
        }*/
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            HideAllPages();
        }
        else if (Input.GetKeyDown(KeyCode.R)){
            Translate();
        }

        else if (Input.GetKeyDown(KeyCode.T)){
            obj1_task1 = 1;
            obj1_task2 = 1;
        }
    }

    public void Translate(){
        if(!isSpanish){
            Spanish();
            isSpanish = true;
        }

        else if(isSpanish){
            English();
            isSpanish = false;
        }

        if(obj1_task1 == 1 && obj1_task2 == 1){
            Completed_body1Text.text = Current_body1Text.text;

            Current_body1Text.text = " ";
        }

        if(obj2_task1 == 1 && obj2_task2 == 1){
            Completed_body2Text.text = Current_body2Text.text;

            Current_body2Text.text = " ";
        }
    }

    public void ShowCurrentPage()
    {
        currentJournalPage.SetActive(true);
        completedJournalPage.SetActive(false);
        //vocabJournalPage.SetActive(false);
    }

    public void ShowCompletedPage()
    {
        currentJournalPage.SetActive(false);
        completedJournalPage.SetActive(true);
        //vocabJournalPage.SetActive(false);
    }

    public void ShowVocabPage()
    {
        currentJournalPage.SetActive(false);
        completedJournalPage.SetActive(false);
        //vocabJournalPage.SetActive(true);
    }

    public void Spanish(){
        string titleEnglishText = Current_titleText.text;
        string body1EnglishText = Current_body1Text.text;
        string body2EnglishText = Current_body2Text.text;
        if (englishToSpanishTranslations.ContainsKey(titleEnglishText))
        {
            Current_titleText.text = englishToSpanishTranslations[titleEnglishText];
        }

        if (englishToSpanishTranslations.ContainsKey(body1EnglishText))
        {
            Current_body1Text.text = englishToSpanishTranslations[body1EnglishText];
        }

        if (englishToSpanishTranslations.ContainsKey(body2EnglishText))
        {
            Current_body2Text.text = englishToSpanishTranslations[body2EnglishText];
        }




        titleEnglishText = Completed_titleText.text;
        if (englishToSpanishTranslations.ContainsKey(titleEnglishText))
        {
            Completed_titleText.text = englishToSpanishTranslations[titleEnglishText];
        }
        
        
    }

    public void English(){
        Current_titleText.text = "Current Objectives";
        Completed_titleText.text = "Completed Objectives";

        Current_body1Text.text = "Oh No! Luis has lost his dog. He needs your help finding it!:\nFind and pick up the dog (" + obj1_task1 + "/1)\nBring the dog to Luis (" + obj1_task2 + "/1)";
        Current_body2Text.text = "Maria can't find her letter, but she doesn't need to send it anymore. Please throw it away for her.:" + "\nFind and pick up the letter (" + obj2_task1 + "/1)\nBring the letter to the trash (" + obj2_task2 + "/1)";
    }
}
