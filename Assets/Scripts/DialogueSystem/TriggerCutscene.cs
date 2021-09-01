using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCutscene : MonoBehaviour
{
    public int initialCutID;
    private SubCutStateController SCController;
    // Start is called before the first frame update
    void Start()
    {
        SCController = GameObject.FindObjectOfType<SubCutStateController>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {

       if (col.tag == "Player")
       {
           SCController.StartCutscene(initialCutID);
       }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            SCController.StartCutscene(this.initialCutID);


        }
    }

}
