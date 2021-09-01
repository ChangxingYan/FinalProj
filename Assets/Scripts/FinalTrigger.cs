using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinalTrigger : MonoBehaviour
{
    public GameObject UIobj;
    public GameObject notice;
    public GameObject restart;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OpenMenu();
    }
    void OpenMenu()
    {

        UIobj.SetActive(true);
        notice.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(restart);

    }
}