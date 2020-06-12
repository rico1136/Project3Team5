using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableScreen : MonoBehaviour
{
    public GameObject screen;
    public void onClick() 
    {
        screen.SetActive(false);
    }
}
