using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class englishToggle : MonoBehaviour
{
    public GameObject[] englishText;
    private bool englIsOn;
    // Start is called before the first frame update
    void Start()
    {
        englIsOn = false;
        for(int i=0; i < englishText.Length; i++)
        {
            englishText[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(englIsOn)
            {
                englIsOn = false;
                for(int i=0; i < englishText.Length; i++)
                {
                    englishText[i].SetActive(false);
                }
            }
            else
            {
                englIsOn = true;
                for(int i=0; i < englishText.Length; i++)
                {
                    englishText[i].SetActive(true);
                }
            }
        }
    }
}
