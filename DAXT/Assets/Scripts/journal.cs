using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class journal : MonoBehaviour
{
   public GameObject currentJournalPage;
    public GameObject completedJournalPage;
    public GameObject objective1English;
    public GameObject objective2English;
    public GameObject objective1Spanish;
    public GameObject objective2Spanish;
    public GameObject currentTitleEnglish;
    public GameObject completedTitleEnglish;


    public TextMeshProUGUI current_titleTextEnglish;
    public TextMeshProUGUI obj1EnglishText;
    public TextMeshProUGUI obj1SpanishText;
    public TextMeshProUGUI obj2EnglishText;
    public TextMeshProUGUI obj2SpanishText;

    public TextMeshProUGUI compObj1EnglishText;
    public TextMeshProUGUI compObj1SpanishText;
    public TextMeshProUGUI compObj2EnglishText;
    public TextMeshProUGUI compObj2SpanishText;
    public TMP_Text Completed_titleTextEnglish;

    public bool isSpanish = true;
    //public TextMeshProUGUI bodyText;  


    
/*
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
    public bool isSpanish = false;
    //public AudioSource[] audioSources;
    public Button[] buttons; // Array of Buttons with assigned AudioSource components

    private Dictionary<string, string> englishToSpanishTranslations = new Dictionary<string, string>();
    */

    void Start(){
        HideAllPages();

        obj1SpanishText.text = " ";
        obj2SpanishText.text = " ";
        obj1EnglishText.text = " ";
        obj2EnglishText.text = " ";

        compObj1SpanishText.text = " ";
        compObj2SpanishText.text = " ";
        compObj1EnglishText.text = " ";
        compObj2EnglishText.text = " ";

/*
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PlayAudio(button.GetComponent<AudioSource>()));
        }
*/

    }

    void HideAllPages(){
        currentJournalPage.SetActive(false);
        completedJournalPage.SetActive(false);
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
    }

    public void Translate(){
        if(isSpanish == true){
            currentTitleEnglish.SetActive(true);
            completedTitleEnglish.SetActive(true);

            if(obj1SpanishText.text == " "){
                objective1English.SetActive(false);
            }

            else if(obj1SpanishText.text != " "){
                objective1English.SetActive(true);
            }

            if(obj2SpanishText.text == " "){
                objective2English.SetActive(false);
            }

            else if(obj2SpanishText.text != " "){
                objective2English.SetActive(true);
            }

            isSpanish = false;
        }

        else if(isSpanish == false){
            currentTitleEnglish.SetActive(false);
            completedTitleEnglish.SetActive(false);

            objective1English.SetActive(false);
            objective2English.SetActive(false);

            isSpanish = true;
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



    void PlayAudio(AudioSource audioSource)
    {
        // Check if AudioSource is assigned
        if (audioSource != null)
        {
            // Play the audio using the assigned AudioSource component
            audioSource.Play();
        }
    }
}
