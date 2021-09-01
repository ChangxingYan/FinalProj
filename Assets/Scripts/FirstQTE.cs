using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstQTE : MonoBehaviour
{

    //this script is placed on interactive objects in scene

    
    public static int timesDone;
    public GameObject QTEUIobj;//this is the object to be added into backpack
    SubCutStateController IDCon;
    QTESys QTESys;
    public int QTEID;
    public int eventIDy;
    public int eventIDn;

    public GameObject[] triggersY;
    public GameObject[] triggersN;
    bool QTEdone = false;


    void Start()
    {
        IDCon = GameObject.FindObjectOfType<SubCutStateController>();
        QTESys = GameObject.FindObjectOfType<QTESys>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            triggerQTE();


        }

        //GetComponent<BoxCollider2D>().enabled = false;

    }

    public void triggerQTE()
    {
        if(QTESys != null)
        {

            QTESys.CreatePrompt(QTEID, this.transform);
            QTESys.QTEID = QTEID;
            QTESys.waitingForKey = true;
            QTEdone = true;
            timesDone = 0;
        }
      
    }
    private void Update()
    {
        if (timesDone >= 1)
        {
            if (QTEdone)
            {
                this.gameObject.SetActive(false);
                QTEUIobj.SetActive(true);
                IDCon.StartSubtitle(eventIDy);
                IDCon.StartCutscene(eventIDy);
                foreach (GameObject gameObject in triggersY)
                {
                    gameObject.SetActive(true);
                }
                foreach (GameObject gameObject in triggersN)
                {
                    gameObject.SetActive(false);
                }
                QTEdone = false;
                timesDone = 0;
            }
           

        }
        if(timesDone <= -1)
        {
            if (QTEdone)
            {
                this.gameObject.SetActive(false);
                IDCon.StartSubtitle(eventIDn);
                IDCon.StartCutscene(eventIDn);
                foreach (GameObject gameObject in triggersN)
                {
                    gameObject.SetActive(true);
                }
                foreach (GameObject gameObject in triggersY)
                {
                    gameObject.SetActive(false);
                }
                QTEdone = false;
                timesDone = 0;
            }
        }
    }



}
