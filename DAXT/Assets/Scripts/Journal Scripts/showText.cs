using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showText : MonoBehaviour
{
    public TextMeshProUGUI page1;
    public TextMeshProUGUI page2;
    public TextMeshProUGUI page3;
    public TextMeshProUGUI page4;
    public TextMeshProUGUI page5;

    // Gameobject Audio Source Component
    public GameObject supermarketAudio;
    public GameObject skyAudio;
    public GameObject bakeryAudio;
    public GameObject busAudio;
    public GameObject taxiAudio;
    public GameObject bankAudio;
    public GameObject carAudio;
    public GameObject museumAudio;
    public GameObject streetAudio;
    public GameObject restaurantAudio;
    public GameObject skyscraperAudio;
    public GameObject departmentStoreAudio;
    public GameObject benchAudio;
    public GameObject sidewalkAudio;
    public GameObject firehydrantAudio;
    public GameObject trashcanAudio;
    public GameObject treeAudio;
    public GameObject stoplightAudio;
    public GameObject streetlightAudio;
    public GameObject busstopAudio;
    public GameObject emptyAudio;


    //reference all game objects to be added
    public triggerNewEntry busScript;
    public triggerNewEntry supermarketScript;
    public triggerNewEntry bakeryScript;
    public triggerNewEntry taxiScript;
    public triggerNewEntry bankScript;
    public triggerNewEntry skyScript;
    public triggerNewEntry departmentStoreScript;
    public triggerNewEntry carScript;
    public triggerNewEntry museumScript;
    public triggerNewEntry streetScript;
    public triggerNewEntry restaurantScript;
    public triggerNewEntry skyscraperScript;
    public triggerNewEntry benchScript;
    public triggerNewEntry sidewalkScript;
    public triggerNewEntry fireHydrantScript;
    public triggerNewEntry trashcanScript;
    public triggerNewEntry treeScript;
    public triggerNewEntry stoplightScript;
    public triggerNewEntry streetlightScript;
    public triggerNewEntry busStopScript;

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

        public GameObject audioSource;

        public Vocabulary(string text, GameObject audioSource)
        {
            entryText = text;
            entered = false;
            this.audioSource = audioSource;
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

    //journal values
    //track number of entries added
    private int currentEntries = 0;
    //set max entries for a given page
    private static int pageLimit = 6;
    //track journal page
    private TextMeshProUGUI currentPage;

    //holds vocab entry strings
    //item vocab strings
    private Vocabulary bus;
    private Vocabulary supermarket;
    private Vocabulary bakery;
    private Vocabulary taxi;
    private Vocabulary bank;
    private Vocabulary sky;
    private Vocabulary departmentStore;
    private Vocabulary car;
    private Vocabulary museum;
    private Vocabulary street;
    private Vocabulary restaurant;
    private Vocabulary skyscraper;
    private Vocabulary bench;
    private Vocabulary sidewalk;
    private Vocabulary fireHydrant;
    private Vocabulary trashcan;
    private Vocabulary tree;
    private Vocabulary stoplight;
    private Vocabulary streetlight;
    private Vocabulary busStop;

    //dialog vocab
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
        //item vocab
        bus = new Vocabulary("el autobús: bus;\n\n", busAudio);
        supermarket = new Vocabulary("el supermercado: supermarket; a masculine noun\n\n", supermarketAudio);
        bakery = new Vocabulary("la pastelería: bakery; a feminine noun\n\n", bakeryAudio);
        taxi = new Vocabulary("el taxí: taxi; a masculine noun\n\n", taxiAudio);
        bank = new Vocabulary("el banco: bank (also bench); a masculine noun\n\n", bankAudio);
        sky = new Vocabulary("el cielo: sky; a masculine noun\n\n", skyAudio);
        departmentStore = new Vocabulary("los grandes almacenes: department store; a masculine noun\n\n", departmentStoreAudio);
        car = new Vocabulary("el carro: car; a masculine noun\n\n", carAudio);
        museum = new Vocabulary("el museo: museum; a masculine noun\n\n", museumAudio);
        street = new Vocabulary("la calle: street; a feminine noun\n\n", streetAudio);
        restaurant = new Vocabulary("el resaurante: restaurant; a masculine noun\n\n", restaurantAudio);
        skyscraper = new Vocabulary("el rascacielo: skyscraper; a masculine noun\n\n", skyscraperAudio);
        bench = new Vocabulary("el banco: bench (also bank); a masculine noun\n\n", benchAudio);
        sidewalk = new Vocabulary("la acera: sidewalk; a feminine noun\n\n", sidewalkAudio);
        fireHydrant = new Vocabulary("el buzón: fire hydrant; a masculine noun\n\n", firehydrantAudio);
        trashcan = new Vocabulary("el bote de basura: trash can; a masculine noun\n\n", trashcanAudio);
        tree = new Vocabulary("el árbol: tree; a masculine noun\n\n", treeAudio);
        stoplight = new Vocabulary("el semáforo: stoplight; a masculine noun\n\n", stoplightAudio);
        streetlight = new Vocabulary("la farola: streetlight; a feminine noun\n\n", streetlightAudio);
        busStop = new Vocabulary("la parada de autobús: bus stop; a feminine noun\n\n", busstopAudio);
            
        
        //dialog vocab
        //tutorial 1
        learn = new Vocabulary("aprender: to learn; an -er verb; already in infinitive form\n\n", emptyAudio);
        //tutorial 2
        speak = new Vocabulary("hablar: to speak; -ar verb; you saw it conjugated as hablan\n\n", emptyAudio);
        have = new Vocabulary("tener: to have; -er verb; you saw it conjugated as tienen\n\n", emptyAudio);
        //tutorial 3
        walk = new Vocabulary("dar un paseo: to take a walk; common phrase; you saw it conjugated as da un paseo\n\n", emptyAudio);
        //tutorial 4
        find = new Vocabulary("encontrar: to find; -ar verb; already in infinitive form\n\n", emptyAudio);
        //tutorial 5
        relax = new Vocabulary("relajarse: to relax; reflexive -ar verb; you saw it conjugated as relajate\n\n", emptyAudio);
        want = new Vocabulary("querer: to want; irregular -er verb; you saw it conjugated as quieres\n\n", emptyAudio);
        look = new Vocabulary("mirar: to look; -ar verb; you saw it conjugated as mira\n\n", emptyAudio);
        go = new Vocabulary("ir: to go; irregular verb; you saw it conjugated as van\n\n", emptyAudio);
    }

    // Update is called once per frame
    void Update()
    {
        
        //figures out which entry to write
        //object vocab triggers
        if(busScript.trigger)
        {
            checkValid(bus);
            busScript.trigger = false;
        }
        if(supermarketScript.trigger)
        {
            checkValid(supermarket);
            supermarketScript.trigger = false;
        }
        if(bakeryScript.trigger)
        {
            checkValid(bakery);
            bakeryScript.trigger = false;
        }
        if(taxiScript.trigger)
        {
            checkValid(taxi);
            taxiScript.trigger = false;
        }
        if(bankScript.trigger)
        {
            checkValid(bank);
            bankScript.trigger = false;
        }
        if(skyScript.trigger)
        {
            checkValid(sky);
            skyScript.trigger = false;
        }
        if(departmentStoreScript.trigger)
        {
            checkValid(departmentStore);
            departmentStoreScript.trigger = false;
        }
        if(carScript.trigger)
        {
            checkValid(car);
            carScript.trigger = false;
        }
        if(museumScript.trigger)
        {
            checkValid(museum);
            museumScript.trigger = false;
        }
        if(streetScript.trigger)
        {
            checkValid(street);
            streetScript.trigger = false;
        }
        if(restaurantScript.trigger)
        {
            checkValid(restaurant);
            restaurantScript.trigger = false;
        }
        if(skyscraperScript.trigger)
        {
            checkValid(skyscraper);
            skyscraperScript.trigger = false;
        }
        if(benchScript.trigger)
        {
            checkValid(bench);
            benchScript.trigger = false;
        }
        if(sidewalkScript.trigger)
        {
            checkValid(sidewalk);
            sidewalkScript.trigger = false;
        }
        if(fireHydrantScript.trigger)
        {
            checkValid(fireHydrant);
            fireHydrantScript.trigger = false;
        }
        if(trashcanScript.trigger)
        {
            checkValid(trashcan);
            trashcanScript.trigger = false;
        }
        if(treeScript.trigger)
        {
            checkValid(tree);
            treeScript.trigger = false;
        }
        if(stoplightScript.trigger)
        {
            checkValid(stoplight);
            stoplightScript.trigger = false;
        }
        if(streetlightScript.trigger)
        {
            checkValid(streetlight);
            streetlightScript.trigger = false;
        }
        if(busStopScript.trigger)
        {
            checkValid(busStop);
            busStopScript.trigger = false;
        }
        //tutorial vocab triggers
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
            tutorial3Script.trigger = false;
        }
        if(tutorial4Script.trigger)
        {
            checkValid(find);
            tutorial4Script.trigger = false;
        }
        if(tutorial5Script.trigger)
        {
            checkValid(relax);
            checkValid(want);
            checkValid(look);
            checkValid(go);
            tutorial5Script.trigger = false;
        }
    }

    public void checkValid(Vocabulary currentObj)
    {
        //if the current object has NOT been entered
        if(!currentObj.hasBeenEntered())
        {
            //update so it can't be added again
            currentObj.enterThis();
            PlayAudio(currentObj.audioSource.GetComponent<AudioSource>());

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
        else if ((currentEntries >= pageLimit)&&(currentEntries < pageLimit+pageLimit))
        {
            Debug.Log("Added to page 2");
            currentPage = page2;
        }
        else if ((currentEntries >= pageLimit+pageLimit)&&(currentEntries < pageLimit+pageLimit+pageLimit))
        {
            Debug.Log("Added to page 3");
            currentPage = page3;
        }
        else if ((currentEntries >= pageLimit+pageLimit+pageLimit)&&(currentEntries < pageLimit+pageLimit+pageLimit+pageLimit))
        {
            Debug.Log("Added to page 4");
            currentPage = page4;
        }
        else if ((currentEntries >= pageLimit+pageLimit+pageLimit+pageLimit)&&(currentEntries < pageLimit+pageLimit+pageLimit+pageLimit+pageLimit))
        {
            Debug.Log("Added to page 5");
            currentPage = page5;
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
    void PlayAudio(AudioSource obj)
    {
        if (obj != null)
        {
            obj.Play();
            //Debug.Log("Playing audio on: " + obj.name);
        }
        else
        {
            Debug.LogWarning("Object does not have an Audiosource Component attached!");
        }
    }
}
