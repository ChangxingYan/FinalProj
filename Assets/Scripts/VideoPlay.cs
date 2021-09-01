using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlay : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public SubCutStateController SubCutStateController;
    public CutsceneSubtitle cutNSub;
    BlackPuddle blackPuddle;
    bool videoPlaying;
    int counter = SubCutStateController.blackPuddleCounter;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.gameObject.transform.parent.gameObject.SetActive(false);
        blackPuddle = GetComponentInParent<BlackPuddle>();
    }

    // Update is called once per frame
    void Update()
    {
  
        if (videoPlaying)
        {
            StartCoroutine(CheckVideoPlaying());

            
                
        //    Debug.Log("videoPlaying");
        //    if (videoPlayer.isPlaying)
        //{
        //        Debug.Log("videoPlayingStop");
        //        videoPlayer.gameObject.transform.parent.gameObject.SetActive(false);
        //        videoPlaying = !videoPlaying;
        //}
        }

    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            videoPlayer.gameObject.transform.parent.gameObject.SetActive(true);
            videoPlayer.Play();
            SubCutStateController.blackPuddleCounter++;


            SubCutStateController.collide = true;

            videoPlaying = true;
            CharacterController2D.moveSpeed = 0f;
            StartCoroutine(CheckVideoPlaying());
            //CharacterController2D.moveSpeed /= 2;

        }
    }

    public void DisableVideo()
    {

        videoPlayer.gameObject.transform.parent.gameObject.SetActive(false);
    }
   

    IEnumerator CheckVideoPlaying()
    {
        yield return new WaitForSeconds(1);
        if (!videoPlayer.isPlaying)
        {
            
                DisableVideo();
                CharacterController2D.moveSpeed = 3f;
                cutNSub.gameObject.transform.Find("Cutscene").gameObject.SetActive(true);
                videoPlaying = false;
            
        }
           

    }
}
