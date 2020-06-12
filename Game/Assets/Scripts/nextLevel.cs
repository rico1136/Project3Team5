using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextLevel : MonoBehaviour
{
    Inventory inventory;
    public Transform parent;
    public CountDownTimer CountDownTimer;
    int maxItems;
    bool puntenAdded = false;
    public AudioSource pickUpSound;

    private void Start()
    {
        maxItems = parent.GetComponentsInChildren<ItemPickup>().Length;
        Debug.Log(maxItems);
        inventory = Inventory.instance;
    }
    private void Update()
    {
        if (inventory.items.Count == maxItems && puntenAdded == false)
        {
            puntenAdded = true;
            int points = PlayerPrefs.GetInt("playerPoints");
            PlayerPrefs.SetInt("playerPoints", points + Mathf.FloorToInt(CountDownTimer.timeLeft));
            
        }
        if (inventory.items.Count == maxItems && !pickUpSound.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
