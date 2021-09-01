using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEAddOn : MonoBehaviour
{
    public bool QTEsp = false;
    private SecondQTE qte;
    SubCutStateController IDCon;

    // Start is called before the first frame update
    void Start()
    {
        qte = GetComponent<SecondQTE>();
        IDCon = GameObject.FindObjectOfType<SubCutStateController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            QTEsp = true;



        }
    }
}
