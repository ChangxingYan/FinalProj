using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdQTE : MonoBehaviour
{
    //this script is placed on interactive objects in scene

    
    public static int timesDone;
    
    SubCutStateController IDCon;
    QTESys QTESys;
    public int QTEID;


    public bool thirdQTEstart = false;
    public bool thirdQTEdone = false;
    public int talkID;


    void Start()
    {
           IDCon = GameObject.FindObjectOfType<SubCutStateController>();
        QTESys = GameObject.FindObjectOfType<QTESys>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            thirdQTEstart = true;
            ThirdTriggerQTE();

}

        //GetComponent<BoxCollider2D>().enabled = false;

    }

    public void ThirdTriggerQTE()
    {
        if(QTESys != null){
            QTESys.CreatePrompt(QTEID, this.transform);
            QTESys.QTEID = QTEID;
            QTESys.waitingForKey = true;
            thirdQTEdone = true;
        }
       
        
        
    }
    private void Update()
    {
        if (thirdQTEdone)
        {
            if (timesDone == 1)
            {
                IDCon.StartDialogue(talkID);
                //69

                thirdQTEdone = false;
                timesDone = 0;
            }


            if (timesDone <= -1)
            {
                if (thirdQTEdone)
                {
                    thirdQTEdone = false;
                    timesDone = 0;
                }
            }
        }
    }



}
