using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] steps;


    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return steps[UnityEngine.Random.Range(0, steps.Length)];        
    }
}