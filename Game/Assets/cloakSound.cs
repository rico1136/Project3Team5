using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloakSound : MonoBehaviour
{
    public GameObject step;
    private AudioClip[] steps;
    public AudioClip cloak;
    public AudioClip stoneSound;

    private void Start()
    {
        steps = step.GetComponent<FootSteps>().steps;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        { 
            steps[0] = cloak;
    }
    }

private void OnTriggerExit(Collider other)
{
    if (other.transform.CompareTag("Player"))
    { 
        steps[0] = stoneSound;
}
    }

}
