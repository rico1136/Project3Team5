using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepSoundSwitcher : MonoBehaviour
{
    public GameObject step;
    private AudioClip[] steps;
    public AudioClip grassSound;
    public AudioClip stoneSound;

    private void Start()
    {
        steps = step.GetComponent<FootSteps>().steps;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Vector3 dir = (collision.gameObject.transform.position - gameObject.transform.position).normalized;

            if (Mathf.Abs(dir.z) < 0.05f)
            {
                if (dir.x > 0)
                {
                    print("RIGHT");
                }
                else if (dir.x < 0)
                {
                    print("LEFT");
                }
            }
            else
            {
                if (dir.z > 0)
                {
                    steps[0] = stoneSound;
                }
                else if (dir.z < 0)
                {
                    steps[0] = grassSound;
                }
            }
        }    
    }
}
