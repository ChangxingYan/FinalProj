using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTrigger : MonoBehaviour
{
    public string nextLevelName;
    public CanvasGroupAlpha canvasAlpha;
    private EventManager eventManager;


    private void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        NextLevel();
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        //eventManager.RecordEvents();
        StartCoroutine(LoadNextScene());
    }
    IEnumerator LoadNextScene()
    {
        canvasAlpha.gameObject.SetActive(true);
        canvasAlpha.Fade();
            AsyncOperation asyncLoadOperation = SceneManager.LoadSceneAsync(nextLevelName);
            asyncLoadOperation.allowSceneActivation = false;
            yield return new WaitForSeconds(8);
        if(nextLevelName == "One")
        {
            if(EventManager.eventRecorder != null)
            {
                EventManager.eventRecorder.Clear();

                Debug.Log("eventRecorderClear");
            }

            Time.timeScale = 1f;
        }
        eventManager.RecordEvents();
        if (asyncLoadOperation.progress >= 0.9f && canvasAlpha.m_fadeComplete)
            {
                asyncLoadOperation.allowSceneActivation = true;

            }

            yield return null;


        
    }
}
