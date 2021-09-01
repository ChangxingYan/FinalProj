using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlackTide : MonoBehaviour
{

    public GameObject blackVeil;
    public FirstQTE qte;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        blackVeil.SetActive(true);
        qte.enabled = true;
        //start whatever animation here
    }
}
