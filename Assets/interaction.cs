using UnityEngine;

public class Interaction : MonoBehaviour
{
    private GameObject item;
    private RaycastHit hit;
    public int pickedUpCount = 0;
    public int maxItems = 15;

    public journal j;

    //a gameObject in a specific spot in the scene
    public Transform designatedSpot; 

    //radius to check for each item drop
    public float dropRadius = 2.0f; 

    void Start()
    {
        UpdateInstructions(); 

        j = FindObjectOfType<journal>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (item == null)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
                {
                    if (hit.collider.CompareTag("Cube"))
                    {
                        PickUpObject(hit.collider.gameObject);
                    }
                }
            }
            else
            {
                DropObject();
            }
        }

        if (item != null)
        {
            item.transform.position = transform.position + transform.forward * 2f;
        }
    }

    void PickUpObject(GameObject obj)
    {
        item = obj;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.parent = transform;

        AudioSource audioSource = item.GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        
            pickedUpCount++;

        
        UpdateInstructions();

        // Set obj1_task1 to 1 when object is picked up
        j.obj1_task1 = 1; 
        //j.UpdateInstructions(); // Call the method to update UI
    }

    void DropObject()
    {
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item = null;

        // Check if the item is dropped within a certain radius of the designated spot
        if (Vector3.Distance(item.transform.position, designatedSpot.position) <= dropRadius)
        {
            // if the tem is dropped within the radius, set both variables to 1
            j.obj1_task1 = 1;
            j.obj1_task2 = 1;
        }
        else
        {
            // if the item is dropped outside the radius, set only obj1_task1 to 1
            j.obj1_task1 = 0;
        }

        //j.obj1_task1 = 0; 

        // Call the method to update the page
        //j.UpdateInstructions(); 
    }



    void UpdateInstructions()
    {
         updateText updater = FindObjectOfType<updateText>();
    if (updater != null)
    {
        updater.pickedUpCount = pickedUpCount;
        updater.UpdateInstructions();
    }

    
    }
}
