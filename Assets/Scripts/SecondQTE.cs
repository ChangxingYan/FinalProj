using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondQTE : MonoBehaviour
{
    //this script is placed on interactive objects in scene

    
    public static int timesDone;
    
    SubCutStateController IDCon;
    QTESys QTESys;
    public int QTEID;
    public int eventIDy;
    public int eventIDn;
    public GameObject QTEUIobj;
    public GameObject[] triggersY;
    public GameObject[] triggersN;
    public bool secondQTEstart = false;
    public bool secondQTEdone = false;


    void Start()
    {
           IDCon = GameObject.FindObjectOfType<SubCutStateController>();
        QTESys = GameObject.FindObjectOfType<QTESys>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            secondQTEstart = true;
            SecondTriggerQTE();


        }

        //GetComponent<BoxCollider2D>().enabled = false;

    }

    public void SecondTriggerQTE()
    {
        if(QTESys != null){
            QTESys.CreatePrompt(QTEID, this.transform);
            QTESys.QTEID = QTEID;
            QTESys.waitingForKey = true;
            secondQTEdone = true;
        }
       
        
        
    }
    private void Update()
    {
        if (secondQTEdone)
        {
            if (timesDone == 1)
            {
            
                QTEID = 39;
                SecondTriggerQTE();
                //IDCon.StartSubtitle(eventIDy);
                //IDCon.StartCutscene(eventIDy);
                //foreach (GameObject gameObject in triggersY)
                //{
                //    gameObject.SetActive(true);
                //}
                //foreach (GameObject gameObject in triggersN)
                //{
                //    gameObject.SetActive(false);
                //}
                secondQTEdone = false;
            }



            if (timesDone == 2)
            {
                if (secondQTEdone)
                {
                    QTEID = 41;
                    SecondTriggerQTE();
                    secondQTEdone = false;
                }
            }


            if (timesDone == 3)
            {
                QTEID = 44;
                SecondTriggerQTE();
                //firstQTE.gameObject.SetActive(true);
                //firstQTE.triggerQTE();
                secondQTEdone = false;
            }

            if(timesDone == 4)
            {
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
                secondQTEdone = false;
                //this.enabled = false;
                timesDone = 0;
            }
            if (timesDone <= -1)
            {
                if (secondQTEdone)
                {
                    IDCon.StartSubtitle(eventIDn);
                    IDCon.StartCutscene(eventIDn);
                    //foreach (GameObject gameObject in triggersN)
                    //{
                    //    gameObject.SetActive(true);
                    //}
                    //foreach (GameObject gameObject in triggersY)
                    //{
                    //    gameObject.SetActive(false);
                    //}
                    secondQTEdone = false;
                    timesDone = 0;
                }
            }
        }
    }



}
