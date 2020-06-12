using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform player;
    public bool hasInteracted;
    Renderer renderer;
    public Material outlineMaterial;
    public Material defaultMaterial;

    public GameObject tutorial;
    public CountDownTimer countDownTimer;

    public float timeLeft = 2f;


    private void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultMaterial = GetComponent<Renderer>().material;
    }
    public virtual void Interact()
    {
        //This method is meant to be overwritten
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= radius && !hasInteracted)
        {
            if (PlayerPrefs.GetInt("tutorialNeeded") == 1 ? true : false)
            {
                if (!countDownTimer.paused)
                {
                    player.GetComponent<ThirdPersonMovement>().canWalk = false;
                    countDownTimer.paused = true;
                    tutorial.SetActive(true);
                    PlayerPrefs.SetInt("tutorialNeeded", 0);
                }       
            }
            hasInteracted = true;
            renderer.material = outlineMaterial;

                Renderer[] children;
                children = GetComponentsInChildren<Renderer>();
                foreach (Renderer rend in children)
                {
                    var mats = new Material[rend.materials.Length];
                    for (var j = 0; j < rend.materials.Length; j++)
                    {
                        mats[j] = outlineMaterial;
                    }
                    rend.materials = mats;
                }
            

        }
        if (distance >= radius && hasInteracted)
        {
            renderer.material = defaultMaterial;
            hasInteracted = false;
        }
    }
}
