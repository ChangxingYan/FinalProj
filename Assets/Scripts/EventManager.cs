using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public GameObject UIobj;
    public static List<int> eventRecorder;
    private static EventManager instance;
    SubCutStateController SCController;
    List<string> hiddenEvents;
 void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.transform.gameObject);

        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (UIobj == null)
        {
            UIobj = GameObject.FindWithTag("UI").transform.Find("UIobj").gameObject;

            if (eventRecorder != null)
            {
                foreach (int i in eventRecorder)
                {
                    UIobj.transform.GetChild(i + 2).gameObject.SetActive(true);
                }
            }
            //else{
            //    foreach (int i in eventRecorder)
            //    {
            //        UIobj.transform.GetChild(i + 2).gameObject.SetActive(false);
            //    }
            //}
                if(hiddenEvents != null)
                {
                    foreach (string n in hiddenEvents)
                    {
                    if(UIobj.transform.Find(n) != null)
                        UIobj.transform.Find(n).gameObject.SetActive(true);
                    }
                }
                
            
          
        }
        SCController = FindObjectOfType<SubCutStateController>();
    }
    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    public void RecordEvents()
    {
        Transform[] allItems = UIobj.GetComponentsInChildren<Transform>();
        eventRecorder = new List<int>();
        hiddenEvents = new List<string>();
        foreach(Transform item in allItems)
        {
           int num = GetNumOrder(item.name);
            if(num >= 0)
            {
                eventRecorder.Add(num);
            }
            else
            {
                hiddenEvents.Add(item.name);
            }
        }
    }

    public int GetNumOrder(string objName)
    {
        int num;
        try
        {
            num = Int32.Parse(objName.Substring(0,1));
            return num;
        }
        catch (FormatException)
        {
            return -1;
        }
        
    }
    
    public bool ObjectExists(int objectNumber)
    {
        bool isExist = eventRecorder.Contains(objectNumber);
        return isExist;
    }
}
