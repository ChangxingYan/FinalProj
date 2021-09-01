using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogueEvent : MonoBehaviour
{
    public int initialEventID;

    public ThirdQTE thirdQte;
    private SubCutStateController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindObjectOfType<SubCutStateController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            thirdQte.ThirdTriggerQTE();
            thirdQte.thirdQTEstart = true;
            this.gameObject.SetActive(false);

        }

    }
}
