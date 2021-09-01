using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLine : ScriptableObject // this is a ScriptableObject because we are using this class
    //as a "structure" only - we do not need it as a behaviour within a particular GameObject
{

    public int id;                    
    public string speaker;            
    public string text;               
    public int nextEvent;             
    public bool lastEventInSequence;  
    public int textBoxPosition; //0-subtitle; 1-Aster; 2-Sylvan; 3-Elden; 4 - QTE
    public float timeSub;
    public float timeCut;
    public string imgAsset;           
    public string audioAsset;         


}
