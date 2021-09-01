using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleController : MonoBehaviour
{

    public Transform[] playerTransform;
    //public GameHandler_chatBubble dialogueBox;
    public CutsceneSubtitle cutNSub;
    private AudioSource sound;

    [HideInInspector] public TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    //public TextWriter.TextWriterSingle ShowChatBubble(int transform, string text)
    //{
    //
    //
    //    //string inputString = parent.transform.Find("ChatBubble").Find("Text").GetComponent<TextMeshPro>().text;
    //    textMeshPro = ChatBubble.Create(playerTransform[transform], new Vector3(3, 3), text);
    //    //textWriterSingle.textToWrite = textMeshPro.text;
    //    //textWriterSingle.textBox = textMeshPro;
    //    return TextWriter.AddWriter_static(textMeshPro, 0.05f, true, true);
    //}

    public void Update()
    {

    }
    public void DisplaySubtitle(DialogueLine d)
    {
        cutNSub.gameObject.SetActive(true);
    
        //updates the text according to the DialogueLine
        cutNSub.currentText.text = d.text;

        //loads the imageAsset and displays it
        if ( d.id == 24 || d.id == 25 || d.id == 26 || d.id == 27)
        {
            Debug.Log(d.id);
            cutNSub.gameObject.transform.SetAsLastSibling();
            cutNSub.gameObject.transform.Find("Cutscene").gameObject.SetActive(false);
        }
        //loads the audioClip
        AudioClip c = Resources.Load<AudioClip>("Audio/" + d.audioAsset);

        //if there is an actual audioClip, it is played using the audiosource found at this gameObject.
        if (c)
        {
            sound.PlayOneShot(c);
        }

    }

    public void DisplayCutscene(DialogueLine d)
    {
        cutNSub.gameObject.SetActive(true);

        cutNSub.cutsceneImg.sprite = Resources.Load<Sprite>("Art/DialogueImages/" + d.imgAsset);
        //if(d.id == 24 || d.id == 25 || d.id == 26 || d.id == 27)
        //{
        //    cutNSub.gameObject.transform.SetAsLastSibling();
        //}

        AudioClip c = Resources.Load<AudioClip>("Audio/" + d.audioAsset);
        if (c)
        {
            sound.PlayOneShot(c);
        }

    }

    public void HideSubtitle()
    {
        cutNSub.gameObject.SetActive(false);
    }

    public void HideCutscene()
    {
        cutNSub.gameObject.SetActive(false);
    }
    public void HideCutNSub()
    {
        cutNSub.gameObject.SetActive(false);
    }


    public void DisplayEvent(DialogueLine d)
    {

         ChatBubble.Create(playerTransform[d.textBoxPosition - 1], new Vector3(0, 2.5f), d.text);
        

        //shows the UI Dialogue Space

        //updates the text according to the DialogueLine
        //dialogueBox.textMeshPro.text = d.text;
        //lastDialogue = dialogueBox.textMeshPro.gameObject.transform.parent.gameObject;
        //loads the imageAsset and displays it
        //     dialogueBox.speakerImg.sprite = Resources.Load<Sprite>("Art/DialogueImages/" + d.imgAsset);

        //loads the audioClip
        AudioClip c = Resources.Load<AudioClip>("Audio/" + d.audioAsset);

        //if there is an actual audioClip, it is played using the audiosource found at this gameObject.
        if (c)
        {
            sound.PlayOneShot(c);
        }


        ////OBS: Resources.Load is ok for this level of project (it is still a basic prototype/proof of concept)
        ////In a "proper" build (e.g. a finalised product) you will probably be better off with another loading system
        ////probably an async file loader in the beginning of the level.


    }
}
