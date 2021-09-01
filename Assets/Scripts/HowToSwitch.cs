using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToSwitch : MonoBehaviour
{
    // Start is called before the first frame update
public void HowTo()
    {
        this.gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
