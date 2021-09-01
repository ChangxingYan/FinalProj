using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIswitch : MonoBehaviour
{
    public GameObject UIObj;
    public GameObject pauseFirstButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UIObj.SetActive(!UIObj.activeSelf);

            if (UIObj.activeSelf)
            {
                Pause();
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(pauseFirstButton);
            }
            else
            {
                Unpause();
            }

        }
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
    }

    public static void Unpause()
    {
        Time.timeScale = 1f;
    }
}
