using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTESys : MonoBehaviour
{

    public SubCutStateController IDCon;
    public Camera mainCam;


    private Image pancake;// basically child 1 of QTEPrefab
    private Image fill;//child 2
    private float indicatorTimer = 0f;
    public GameObject qtePrefab = null;//this is the dialogue box
    public GameObject canvas;
    public SecondQTE secondQte;
    public ThirdQTE thirdQte;
    [Header("No Touching")]
    public int QTEID;
    public int correctKey;
    public bool waitingForKey = false;
   
    public bool countingDown = false;
    private void Start()
    {

        IDCon = GameObject.FindObjectOfType<SubCutStateController>();
    }



    public void CreatePrompt(int QTEID, Transform QTEobj)
    {
        DialogueLine line = IDCon.GetComponent<DialogueSystem>().GetEvent(QTEID);
            qtePrefab = Instantiate(GameAssets.i.QTEPrefab);
            qtePrefab.SetActive(true);
            qtePrefab.transform.SetParent(canvas.transform, false);
            pancake = qtePrefab.transform.GetChild(1).GetComponent<Image>();
            fill = qtePrefab.transform.GetChild(2).GetComponent<Image>();
            fill.enabled = false;
            string text = line.text;
            qtePrefab.transform.GetChild(0).GetComponent<Text>().text = text;
            Vector3 tempSize = QTEobj.GetComponent<SpriteRenderer>().size;
            float padding = 50f;
            Vector3 screenPos = mainCam.WorldToScreenPoint(QTEobj.position);
            qtePrefab.transform.position = screenPos + new Vector3(0, tempSize.y + padding, 0);
            //---------and montage
            ControlSubtitle(QTEID);
            ControlCutscene(QTEID);

    }
    private void Update()
    {
        if (waitingForKey == true)
        {
            waitingForKey = false;

            //start coroutine
            string tempText = IDCon.GetComponent<DialogueSystem>().GetEvent(QTEID).text;
            qtePrefab.transform.GetChild(0).GetComponent<Text>().text = tempText;
            countingDown = true;
            StartCoroutine(CountDown());
                


        }



 if (Input.anyKeyDown)
        {
            if (Input.GetButtonDown("Ekey"))
            {
                correctKey = 1;
                StartCoroutine(KeyPressing());
            }
           else if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.X ) )
           {
                //|| Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)
            }
            else
            {
                if(fill != null && pancake != null)
                {
                    correctKey = 2;
                    StartCoroutine(KeyPressing());
            
                }
            }
        }
        
       
           
        



    }

    IEnumerator KeyPressing()
    {
        if (correctKey == 1)
        {
            countingDown = false;
            if(fill != null)
            {
                fill.enabled = true;
                fill.color = Color.green; //new Color(51, 197, 89);//green
            }
 
            //Correct
            yield return new WaitForSeconds(1.0f);
            correctKey = 0;
            FirstQTE.timesDone += 1;//UI object is set to true
            
            qtePrefab.SetActive(false);
            //waitingForKey = true;
            indicatorTimer = 0f;
            pancake.fillAmount = 0;
            if (secondQte != null)
            {
                if (secondQte.secondQTEstart)
                {
                    SecondQTE.timesDone += 1;
                    secondQte.secondQTEdone = true;
                }
            }
            if (thirdQte != null)
            {
                if (thirdQte.thirdQTEstart)
                {
                    ThirdQTE.timesDone += 1;
                    thirdQte.thirdQTEdone = true;
                }
            }
           



        }
        if (correctKey == 2)
        {
            countingDown = false;
            if (fill != null)
            {
                fill.enabled = true;
                fill.color = Color.red;//new Color(232, 133, 114);//red
            }
              
         
            //Incorrect
            yield return new WaitForSeconds(1.0f);
            correctKey = 0;
            FirstQTE.timesDone -= 1;
            SecondQTE.timesDone = -1;
            ThirdQTE.timesDone = -1;
            qtePrefab.SetActive(false);
            //waitingForKey = true;
            indicatorTimer = 0f;
            pancake.fillAmount = 0;
            if (secondQte)
            {
                secondQte.secondQTEdone = true;

            }
            if(thirdQte)
            thirdQte.thirdQTEdone = true;
        }
    }

    IEnumerator CountDown()
    {
        bool breakBool = false;
        if (countingDown == true)
        {
            while (indicatorTimer < 10.0f)
            {
                pancake.gameObject.SetActive(true);
                pancake.fillAmount = indicatorTimer / Mathf.Max(10.0f, Single.Epsilon);
                if (fill.enabled)
                {
                    breakBool = true;
                    break;

                }
                indicatorTimer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            countingDown = false;
            indicatorTimer = 0f;
            pancake.fillAmount = 0;
        }
        if(!breakBool)
        {
            //fail
            fill.enabled = true;
            fill.color = Color.red;//new Color(232, 133, 114);//red
            yield return new WaitForSeconds(1.0f);
            correctKey = 0;

            FirstQTE.timesDone -= 1;
            SecondQTE.timesDone = -1;
            qtePrefab.SetActive(false);
            indicatorTimer = 0f;
            pancake.fillAmount = 0;
            if(secondQte != null)
            {
                secondQte.secondQTEdone = true;

            }
            //Destroy(qtePrefab);
        }


    }
    

   

    public void ControlSubtitle(int QTEID)
    {
        DialogueLine line = IDCon.GetComponent<DialogueSystem>().GetEvent(QTEID);
        //if (line.nextEvent != 0 && line.lastEventInSequence)// this means this line is a qte prompt line that controls cutscene or subtitle, and know that next event is used for getting SubCut events.
        //{
            if (IDCon.GetComponent<DialogueSystem>().GetEvent(line.nextEvent).textBoxPosition == 0)
            {
                if (IDCon.GetComponent<DialogueSystem>().GetEvent(line.nextEvent).text != null)
                {
                    IDCon.StartSubtitle(line.nextEvent);
                }
            }
        //}
    }

    public void ControlCutscene(int QTEID)
    {
        DialogueLine line = IDCon.GetComponent<DialogueSystem>().GetEvent(QTEID);
        //if (line.nextEvent != 0 && line.lastEventInSequence)// this means this line is a qte prompt line that controls cutscene or subtitle, and know that next event is used for getting SubCut events.
        //{
            if (IDCon.GetComponent<DialogueSystem>().GetEvent(line.nextEvent).textBoxPosition == 0) // in the "next event" of a QtE prompt should goes its simultanious changed cutscene and subtitle
            {
                if (IDCon.GetComponent<DialogueSystem>().GetEvent(line.nextEvent).imgAsset != null)// so it means the next event of QTE ID should control either the text or the image or both, when doing so leave others blank
                {
                    IDCon.StartCutscene(line.nextEvent);
                }
            }

        //}
    }
}
