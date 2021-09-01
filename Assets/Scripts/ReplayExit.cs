using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayExit : MonoBehaviour
{
    // Start is called before the first frame update
    public void PLayTheGame()
    {

        SceneManager.LoadScene("One");
        Time.timeScale = 1f;
        if (EventManager.eventRecorder!= null)
        {
            EventManager.eventRecorder.Clear();
        }
            

            Debug.Log("eventRecorderClear");
    }
    public void QuitTheGame()
    {

        Application.Quit();
        Debug.Log("does this work");
    }
}
