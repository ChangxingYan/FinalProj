using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : MonoBehaviour
{
    public SubCutStateController SCController;
    private static TextWriter instance;
    private List<TextWriterSingle> textWriterSingleList;


    public void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
        SCController = GameObject.FindObjectOfType<SubCutStateController>();
    }
  
    public static void RemoveWriter_Static(TextMeshPro textBox)
    {
        instance.RemoveWriter(textBox);
    }
    private void RemoveWriter(TextMeshPro textBox)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].GetText() == textBox)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        
        for (int i = 0; i< textWriterSingleList.Count; i++)
        {
           bool destroyInstance = textWriterSingleList[i].UpdateText();
            if (destroyInstance)
            {
                StartCoroutine(BubbleStay(SCController.currentEvent.timeCut));

                textWriterSingleList.RemoveAt(i);
                i--;
               
               

            }
        }

   
    }
    public static void AddWriter_static(TextMeshPro textBox, float timePerCharacter, bool invisibleCharacters, bool removeWriterBeforeAdd)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(textBox);
        }
         instance.AddWriter(textBox, timePerCharacter, invisibleCharacters);

    }


    public void AddWriter(TextMeshPro textBox, float timePerCharacter, bool invisibleCharacters)
        {
        TextWriterSingle textWriterSingle = new TextWriterSingle(textBox, timePerCharacter, invisibleCharacters);
        instance.textWriterSingleList.Add (textWriterSingle);


        }

    

    IEnumerator BubbleStay(float timeBubbleStay)
    {
        yield return new WaitForSeconds(SCController.currentEvent.timeCut);

        SCController.MoveToNextEvent();

    }

    public class TextWriterSingle
    {
        public TextMeshPro textBox;
        public string textToWrite;
        public float timeBubbleStay;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacters;
        public bool TextBool = false;

       
        public TextWriterSingle(TextMeshPro textBox, float timePerCharacter, bool invisibleCharacters)
        { this.textBox = textBox;
            this.textToWrite = textBox.text;
            this.invisibleCharacters = invisibleCharacters;
            this.timePerCharacter = timePerCharacter;
            characterIndex = 0;
            textBox.renderer.enabled = true;
        TextBool = false;}

                   
       public bool UpdateText()
       {


                timer -= Time.deltaTime;
                while (timer <= 0f)
                {
                     if (characterIndex < textToWrite.Length) {
                         
                         timer += timePerCharacter;
                         characterIndex++;
                         string text = textToWrite.Substring(0, characterIndex);
                             if (invisibleCharacters)
                             {
                             text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                             }
                              textBox.text = text;
                     }
                     else
                    
                     {
                        return true;
                     }
                }
                return false;
            
       }



        public TextMeshPro GetText()
        {
            return textBox;
        }

        public bool IsActive()
        {
            return characterIndex < textToWrite.Length;
        }
        public void WriteAllAndDestroy()
        {
            textBox.text = textToWrite;
            characterIndex = textToWrite.Length;
            TextWriter.RemoveWriter_Static(textBox);
        }

            
    }
}
