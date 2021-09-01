using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    public GameObject UI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        UI.SetActive(true);
    
    }


    }
