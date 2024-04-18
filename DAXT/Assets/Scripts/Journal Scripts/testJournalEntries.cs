using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testJournalEntries : MonoBehaviour
{
    public showText myTest;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(DelayedAction(2.0f)); // Start the coroutine with a delay of 3 seconds
        StartCoroutine(DelayedAction2(4.0f));
        StartCoroutine(DelayedAction3(6.0f));
        StartCoroutine(DelayedAction4(8.0f));
        StartCoroutine(DelayedAction5(10.0f));
        StartCoroutine(DelayedAction6(10.0f));
        StartCoroutine(DelayedAction7(10.0f));
        StartCoroutine(DelayedAction8(10.0f));
        StartCoroutine(DelayedAction9(10.0f));
        StartCoroutine(DelayedAction10(10.0f));
    }

    private IEnumerator DelayedAction(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Perform the action after the delay
        Debug.Log("Delayed action performed after " + delay + " seconds.");
        myTest.supermarketScript.trigger = true;
    }

    private IEnumerator DelayedAction2(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Perform the second action after the delay
        Debug.Log("Second action performed after " + delay + " seconds.");
        myTest.bakeryScript.trigger = true;
    }
    
    private IEnumerator DelayedAction3(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        // Perform the second action after the delay
        Debug.Log("Next action performed after " + delay + " seconds.");
        myTest.taxiScript.trigger = true;
    }
    
    private IEnumerator DelayedAction4(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Perform the second action after the delay
        Debug.Log("Next action performed after " + delay + " seconds.");
        myTest.bankScript.trigger = true;
    }
    private IEnumerator DelayedAction5(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Perform the second action after the delay
        Debug.Log("Next action performed after " + delay + " seconds.");
        myTest.skyScript.trigger = true;
    }
    
    private IEnumerator DelayedAction6(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Perform the second action after the delay
        myTest.tutorial1Script.trigger = true;
        Debug.Log("Next action performed after " + delay + " seconds.");
    }
    private IEnumerator DelayedAction7(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Perform the second action after the delay
        myTest.tutorial2Script.trigger = true;
        Debug.Log("Next action performed after " + delay + " seconds.");
    }
    private IEnumerator DelayedAction8(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Perform the second action after the delay
        myTest.tutorial3Script.trigger = true;
        Debug.Log("Next action performed after " + delay + " seconds.");
    }
    private IEnumerator DelayedAction9(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Perform the second action after the delay
        myTest.tutorial4Script.trigger = true;
        Debug.Log("Next action performed after " + delay + " seconds.");
    }
    private IEnumerator DelayedAction10(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Perform the second action after the delay
        myTest.tutorial5Script.trigger = true;
        Debug.Log("Next action performed after " + delay + " seconds.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
