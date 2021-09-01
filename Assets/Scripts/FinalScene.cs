using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FinalScene : MonoBehaviour
{
    public GameObject UIobj;
    public GameObject notice;
    public GameObject block;
    public GameObject restart;
    public SubCutStateController SCController;
    public SpriteRenderer carriageImage;
    public GameObject triggerN;

    private void OnEnable()
    {
        this.transform.position = this.transform.position + new Vector3(0, -.15f, 0);
        Debug.Log(SCController.endBool);
        if (!SCController.endBool)
        {
            Debug.Log(SCController.endBool);
            SCController.OnSUbCutFinish += TurnOffBlock;

        }
        else
        {
            triggerN.SetActive(true);
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UIswitch.Pause();
            UIobj.SetActive(true);
            notice.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(restart);
        }
    }

    public void TurnOffBlock()
    {
        block.SetActive(false);
        carriageImage.sprite = Resources.Load<Sprite>("Art/carriageOpen");

    }
}
