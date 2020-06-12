using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    bool click = false;
    public GameObject tutorial;
    private AudioSource pickupSound;
    public CountDownTimer countDownTimer;
    private void Start()
    {
        pickupSound = gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click = true;
            
        }
    }
    private void FixedUpdate()
    {
        Ray biem = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(biem.origin, biem.direction * 50000000, Color.red);
        if (click)
        {
            click = false;
            // create ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Debug.Log("picked up");
                    if (interactable.hasInteracted)
                    {
                        if (countDownTimer.paused)
                        {
                            gameObject.GetComponent<ThirdPersonMovement>().canWalk = true;
                            countDownTimer.paused = false;
                            tutorial.SetActive(false);
                        }
                        pickupSound.Play();
                        interactable.Interact();
                    }
                }
            }
        }
    }
}
