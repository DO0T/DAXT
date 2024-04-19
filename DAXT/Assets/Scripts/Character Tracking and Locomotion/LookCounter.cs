using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LookCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText; // Assign in the inspector
    public GameObject objectToEnable; // Assign in the inspector
    public int maxCounter = 5;
    private int currentCounter = 0;
    private HashSet<GameObject> interactedObjects = new HashSet<GameObject>();

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Interactable") && !interactedObjects.Contains(hitObject))
            {
                IncrementCounter();
                interactedObjects.Add(hitObject);
            }
        }
    }

    private void IncrementCounter()
    {
        currentCounter++;
        counterText.text = currentCounter.ToString();

        if (currentCounter >= maxCounter)
        {
            objectToEnable.SetActive(true);
        }
    }
}
