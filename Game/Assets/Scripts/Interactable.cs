using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform player;
    public bool hasInteracted;
    Renderer renderer;
    public Material outlineMaterial;
    public Material defaultMaterial;


    private void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultMaterial = GetComponent<Renderer>().material;
    }
    public virtual void Interact()
    {
        //This method is meant to be overwritten
        Debug.Log("I have been interacted");
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
            Debug.Log("In range of: " + transform.name);
            hasInteracted = true;
            renderer.material = outlineMaterial;
        }
        if (distance >= radius && hasInteracted)
        {
            renderer.material = defaultMaterial;
            hasInteracted = false;
        }
    }
}
