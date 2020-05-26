using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // create ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                Debug.Log(hit); 
                Debug.Log(interactable);
                if (interactable != null)
                {
                    if (interactable.hasInteracted)
                    {
                        interactable.Interact();
                    }
                }
            }
        }
    }
}
