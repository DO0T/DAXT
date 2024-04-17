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
    public textTrigger tutorial2Script;
    public textTrigger tutorial3Script;
    public textTrigger tutorial4Script;
    public textTrigger tutorial5Script;
    
    //object to control individual journal entry info
    public class Vocabulary
    {
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
    private static int pageLimit = 6;
    private TextMeshProUGUI currentPage;

    //holds vocab entry strings
    private Vocabulary supermarket;
    private Vocabulary bakery;
    private Vocabulary learn;
    private Vocabulary speak;
    private Vocabulary have;
    private Vocabulary walk;
    private Vocabulary find;
    private Vocabulary relax;
    private Vocabulary want;
    private Vocabulary look;
    private Vocabulary go;

    
    // Start is called before the first frame update
    void Start()
    {
        currentPage = page1;
        //holds an instance of Vocabulary that can be ovewritten
        
        //initialize the vocabulary entries
        supermarket = new Vocabulary("el supermercado: supermarket; a masculine noun\n\n");
        bakery = new Vocabulary("la pastelería: bakery; a feminine noun\n\n");
        learn = new Vocabulary("aprender: to learn; an -er verb; already in infinitive form\n\n");
        speak = new Vocabulary("hablar: to speak; -ar verb; you saw it conjugated as hablan\n\n");
        have = new Vocabulary("tener: to have; -er verb; you saw it conjugated as tienen\n\n");
        walk = new Vocabulary("dar un paseo: to take a walk; common phrase; you saw it conjugated as da un paseo\n\n");
        find = new Vocabulary("encontrar: to find; -ar verb; already in infinitive form\n\n");
        relax = new Vocabulary("relajarse: to relax; reflexive -ar verb; you saw it conjugated as relajate\n\n");
        want = new Vocabulary("querer: to want; irregular -er verb; you saw it conjugated as quieres\n\n");
        look = new Vocabulary("mirar: to look; -ar verb; you saw it conjugated as mira\n\n");
        go = new Vocabulary("ir: to go; irregular verb; you saw it conjugated as van\n\n");
    }

    // Update is called once per frame
    void Update()
    {
        
        //figures out which entry to write
        if(supermarketScript.trigger)
        {
            checkValid(supermarket);
        }
        if(bakeryScript.trigger)
        {
            checkValid(bakery);
        }
        if(tutorial1Script.trigger)
        {
            checkValid(learn);
            tutorial1Script.trigger = false;
        }
        if(tutorial2Script.trigger)
        {
            checkValid(speak);
            checkValid(have);
            tutorial2Script.trigger = false;
        }
        if(tutorial3Script.trigger)
        {
            checkValid(walk);
        }
        if(tutorial4Script.trigger)
        {
            checkValid(find);
        }
        if(tutorial5Script.trigger)
        {
            checkValid(relax);
            checkValid(want);
            checkValid(look);
            checkValid(go);
        }
    }

    public void checkValid(Vocabulary currentObj)
    {
        //if the current object has NOT been entered
        if(!currentObj.hasBeenEntered())
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
        if(currentEntries < pageLimit)
        {
            Debug.Log("Added to page 1");
        }
        else if (currentEntries >= pageLimit)
        {
            Debug.Log("Added to page 1");
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