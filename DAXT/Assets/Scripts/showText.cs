using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showText : MonoBehaviour
{
    public TextMeshProUGUI page1;
    public TextMeshProUGUI page2;

    //reference all game objects being checked for unique text
    //should correspond to list above
    public triggerNewEntry supermarketScript;
    public triggerNewEntry bakeryScript;
    public textTrigger tutorial1Script;
    //public textTrigger tutorial2;
    //public textTrigger tutorial3;
    //public textTrigger tutorial4;
    
    public class Vocabulary
    {
        private int entryNum;
        private string entryText;
        private bool entered;

        public Vocabulary(string text)
        {
            entryText = text;
            entered = false;
        }

        public void enterThis()
        {
            entered = true;
        } 

        public bool hasBeenEntered()
        {
            return entered;
        }

        public string returnText()
        {
            return entryText;
        }
    }

    //track current values
    private int currentEntries = 0;
    private TextMeshProUGUI currentPage;
    private Vocabulary currentObj;

    //holds vocab entry strings
    private Vocabulary supermarket;
    private Vocabulary bakery;
    private Vocabulary tutorial1;

    
    // Start is called before the first frame update
    void Start()
    {
        currentPage = page1;
        //holds an instance of Vocabulary that can be ovewritten
        currentObj = new Vocabulary("");
        
        //initialize the vocabulary entries
        supermarket = new Vocabulary("el supermercado: supermarket; a masculine noun\n");
        bakery = new Vocabulary("la pastelería: bakery; a feminine noun\n");
        tutorial1 = new Vocabulary("aprender: to learn; an -er verb; already in infinitive form\n");

    }

    // Update is called once per frame
    void Update()
    {
        //figures out which entry to write
        if (supermarketScript.trigger)
        {
            currentObj = supermarket;
        }
        else if (bakeryScript.trigger)
        {
            currentObj = bakery;
        }
        
        else if (tutorial1Script.trigger)
        {
            currentObj = tutorial1;
        }
        
        //add the current triggered object if it hasn't been triggered before
        if (currentObj.hasBeenEntered())
        {
            //update so it can't be added again
            currentObj.enterThis();
            //add the string to the journal
            addEntry(currentObj.returnText());
        }
    }

    //adds the new entry to the journal
    public void addEntry(string newEntry)
    {
        //changes journal pages to write to when they run out of room
        if(currentEntries >= 5)
        {
            currentPage = page2;
        }
        else
        {
            Debug.Log("Ran out of page space in the journal.");
        }

        //adds text to the right journal page
        string currentText = currentPage.text;
        string newText = currentText + newEntry;
        currentPage.text = newText;

        //update the current # of entries
        currentEntries++;
    }
}
