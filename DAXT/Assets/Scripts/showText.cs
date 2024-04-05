using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showText : MonoBehaviour
{
    public string textValue;
    public TextMeshProUGUI textElement;
    public string[] messageArray = new string[2];
    
    // Start is called before the first frame update
    void Start()
    {
        textElement.text = textValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void messages()
    {
        messageArray[0] = "el supermercado: supermarket a noun.\n";
        messageArray[1] = "la pastelería: bakery a noun";
        messageArray[2] = "";

    }
}
