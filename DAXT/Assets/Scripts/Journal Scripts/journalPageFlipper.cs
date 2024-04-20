using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class journalPageFlipper : MonoBehaviour
{
    public GameObject[] pages;
    private int currentPageIndex = 0;
    private bool journalOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton2))
       {
            if(journalOpen)
            {
                journalOpen = false;
                pages[currentPageIndex].SetActive(false);
                //currentPageIndex = 0;
            }
            else
            {
                journalOpen = true;
                pages[currentPageIndex].SetActive(true);
            }

       }
       if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.JoystickButton4)) &&journalOpen)
       {
            flipPageLeft();
       }
       if((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.JoystickButton5)) &&journalOpen)
       {
            flipPageRight();
       }
    }

    public void flipPageRight()
    {
        pages[currentPageIndex].SetActive(false);

        currentPageIndex = (currentPageIndex + 1) % pages.Length;

        pages[currentPageIndex].SetActive(true);
    }

    public void flipPageLeft()
    {
        pages[currentPageIndex].SetActive(false);

        currentPageIndex = (currentPageIndex + -1 + pages.Length) % pages.Length;

        pages[currentPageIndex].SetActive(true);
    }
}
