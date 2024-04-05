using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showText : MonoBehaviour
{
    public TextMeshProUGUI textBox;

    public List<string> entries = new List<string>
    {
        "el supermercado: supermarket; a noun.\n",
        "la pastelería: bakery; a noun\n"
    };

    //reference all game objects being checked for unique text
    //should correspond to list above
    public triggerNewEntry supermarket;
    public triggerNewEntry bakery;
    

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < entries.Count; i++)
        {
            Debug.Log($"Element {i}: {entries[i]}");
        }
    
    }

    // Update is called once per frame
    void Update()
    {

        //figures out which entry to write
        if (supermarket.trigger == true)
        {
            addMoreText(entries[0]);
        }
        else if (bakery.trigger == true)
        {
            addMoreText(entries[1]);
        }

    }

    //adds the new entry to the journal text
    public void addMoreText(string newEntry)
    {
        string currentText = textBox.text;
        string newText = currentText + newEntry;
        textBox.text = newText;
    }
}
