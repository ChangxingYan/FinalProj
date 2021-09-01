using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIobjShowUp : MonoBehaviour
{
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
      
        
      
        if (this.gameObject == EventSystem.current.currentSelectedGameObject)
        {
            go.SetActive(true);
        }
        else
        {
            go.SetActive(false);
        }
    }
}
