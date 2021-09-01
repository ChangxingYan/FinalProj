using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SubCutStateController : MonoBehaviour
{

    public static int blackPuddleCounter = 0;
    public static int videoCounter;
    public bool isInEvent;
    public GameObject[] dialogueObj;
    public int[] EventNumber;
    public GameObject finalObj;
    public ThirdQTE sylvanQte;
    private DialogueSystem dialogueSys;
    private SubtitleController subCon;
    private LevelTrigger levelTrigger;
    private bool dialogueSwitch = false;
    private bool enableScript = false;
    public bool endBool =false;
    //holds the current (or the last event) that happened in game
     DialogueLine currentSub;
     DialogueLine currentCut;
    public DialogueLine currentEvent;
    public delegate void MyDelegate();
    public MyDelegate OnSUbCutFinish;

    public bool collide = false;

    void Start()
    {
        levelTrigger = GetComponent<LevelTrigger>();
        dialogueSys = GetComponent<DialogueSystem>();
        subCon = GetComponent<SubtitleController>();

    }




    public void Update()
    {//
     //   if (isInEvent)
     //   {if(currentEvent != null)
     //       {
     //           if (Input.GetKeyDown(KeyCode.X))
     //           {
     //               StartDialogue(currentEvent.nextEvent);
     //           }
     //       }
     //       
     //   }
        
        VideoAddOn();
    }
    public void StartSubtitle(int eventID)
    {

        currentSub = dialogueSys.GetSub(eventID);
        subCon.DisplaySubtitle(currentSub);
        StartCoroutine(ProceedSubtitle(eventID));
        if (eventID == 24 || eventID == 25 || eventID == 26 || eventID == 27)
        {
            subCon.cutNSub.gameObject.transform.SetAsLastSibling();
        }
        if (EventNumber != null)
        {
            for (int i = 0; i < EventNumber.Length; i++)
            {
                ChooseBranch(EventNumber[i]);
            }

        }


    }

    IEnumerator ProceedSubtitle(int subID)
    {


        yield return new WaitForSeconds(dialogueSys.GetEvent(subID).timeSub);

        MoveToNextSubtitle();
    }

   private void MoveToNextSubtitle()
   {
       
       if (currentSub.lastEventInSequence)
       {
            if (OnSUbCutFinish != null)
                OnSUbCutFinish();
        }
       else{

           StartSubtitle(currentSub.nextEvent);
       }
   }

  
    public void VideoAddOn() // black puddle and video trigger
    {
        if(collide)
        {
            if (blackPuddleCounter == 1)
            {
                StartSubtitle(24);
                collide = false;
                subCon.cutNSub.gameObject.transform.SetAsFirstSibling();
            }
            if (blackPuddleCounter == 2)
            {
                StartSubtitle(24);
                currentSub.nextEvent = 26;
           
                collide = false;
                subCon.cutNSub.gameObject.transform.SetAsFirstSibling();
            }
            if (blackPuddleCounter == 3)
            {
                StartSubtitle(24);
                currentSub.nextEvent = 27;
                collide = false;
                subCon.cutNSub.gameObject.transform.SetAsFirstSibling();
            }
            if(blackPuddleCounter >= 4)
            {
                levelTrigger.NextLevel();
                subCon.cutNSub.gameObject.transform.SetAsFirstSibling();
                collide = false;
                blackPuddleCounter = 0;
            }
        }
        
    }




    public void StartCutscene(int eventID)
    {
        currentCut = dialogueSys.GetEvent(eventID);
        subCon.DisplayCutscene(currentCut);
        StartCoroutine(ProceedCutscene(eventID));
    }

    IEnumerator ProceedCutscene(int subID)
    {

        yield return new WaitForSeconds(dialogueSys.GetCut(subID).timeCut);
        MoveToNextCutscene();
    }

   private void MoveToNextCutscene()
   {
  
       if (currentCut.lastEventInSequence)
       {
           // if(currentCut.id == 14)
           // {
           //     subCon.cutNSub.gameObject.transform.SetAsFirstSibling();
           // }
       }
       else
       {
           StartCutscene(currentCut.nextEvent);
       }
   }

    public void StartDialogue(int eventID)
    {
        currentEvent = dialogueSys.GetEvent(eventID);
        subCon.DisplayEvent(currentEvent);
        subCon.DisplayCutscene(currentEvent);
        for (int i = 0; i< EventNumber.Length; i++)
        {
            ChooseBranch(EventNumber[i]);
        }
     
        //hard code warning:(
        if (eventID == 49)
        {
            PlayDialogue(50);
        }
        if(eventID == 53)
        {
            PlayDialogue(52);
        }
        
        if(eventID == 55)
        {
            PlayDialogue(110);
        }
        if(eventID == 57)
        {
            PlayDialogue(111);
        }
        if(eventID == 65)
        {
            PlayDialogue(52);
        }
        if (eventID == 66)
        {
            PlayDialogue(67);
        }
        if (eventID == 73)
        {
            PlayDialogue(115);

        }
        if (eventID == 75)
        {
            PlayDialogue(118);

        }
        if (eventID == 77)
        {
            PlayDialogue(116);

        }
        if (eventID == 84)
        {
            PlayDialogue(123);

        }
        isInEvent = true;
    }

    void PlayDialogue(int nextId)
    { 
            subCon.DisplaySubtitle(dialogueSys.GetEvent(nextId));


    }

    public void MoveToNextEvent()
    {
        if (currentEvent.lastEventInSequence)
        {
            foreach (Transform child in subCon.playerTransform[currentEvent.textBoxPosition - 1])
            Destroy(child.gameObject);
            SwitchBetween();
            //  if (subCon.textWriterSingle != null && subCon.textWriterSingle.IsActive())
            // 
            //  {
            // 
            //      //currently active TextWriter
            // 
            //      subCon.textWriterSingle.WriteAllAndDestroy();
            // 
            //  }
            // 
            //  //Destroy(subCon.playerTransform[currentEvent.textBoxPosition - 1].gameObject.transform.GetChild(0).gameObject);
            // 
            //  // Destroy(subCon.textMeshPro.gameObject.transform.parent.gameObject);
            isInEvent = false;

        }
        else
        {
          //  if (subCon.textWriterSingle != null && subCon.textWriterSingle.IsActive())
          //  {
          //      //currently active TextWriter
          //      subCon.textWriterSingle.WriteAllAndDestroy();
          //  }
          //  else
          //  {
                Destroy(subCon.playerTransform[currentEvent.textBoxPosition - 1].gameObject.transform.GetChild(0).gameObject);

                StartDialogue(currentEvent.nextEvent);

          //  }


        }


    }
    void SwitchBetween()
    {
        if (dialogueObj != null)
        {
            if (dialogueSwitch)
            {
                if (dialogueObj[1]!= null)
                dialogueObj[1].SetActive(true); // in case the item is not obtained
                dialogueSwitch = false;
            }
            else
            {
                if (dialogueObj[0] != null)
                    dialogueObj[0].SetActive(true); // in case the item is obtained
                dialogueSwitch = false;
            }


        }
    }

    public void ChooseBranch(int objectNumber) // 0-Nina's note; 1-flowerbunch; 2-winderkey; 3-crossing; 4-page 
    {
        if (EventManager.eventRecorder != null)
        {
            if (!EventManager.eventRecorder.Contains(objectNumber))//if the number does not exist in the list, change event
            {
                switch (objectNumber)
                {
                    case 1:
                        //sylvan's dialogue change   49-51 - 49-64
                        if (currentEvent.id == 49)
                        {
                            currentEvent.nextEvent = 64;
                            dialogueSwitch = true;
                            sylvanQte.talkID = 69;
                    
                        }

                        break;

                    case 2:
                        //end carriage qte change
                        if(finalObj != null)
                        {
                            finalObj.SetActive(false);
                            endBool = true;
                        }
                        break;
                 //   case 3:
                 //       //end carriage end change
                 //       if (currentSub.id == 97)
                 //       {
                 //           currentSub.nextEvent = 98;
                 //           currentCut.nextEvent = 98;
                 //           dialogueSwitch = true;
                 //           endBool = true;
                 //
                 //
                 //       }
                 //       break;
                    case 4:
                        //Elden's dialogue 73-74 - 73-78
                        if (currentEvent.id == 73)
                        {
                            currentEvent.nextEvent = 78;
                            dialogueSwitch = true;



                        }
                        break;

                }
            }

        }
        else
        {

        }
    }

}
