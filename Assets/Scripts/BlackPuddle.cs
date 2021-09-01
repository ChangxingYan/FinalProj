using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPuddle : MonoBehaviour
{
    public SubCutStateController subCutStateController;
    public static int blackPuddleCounter = 0;
    List<GameObject> obstacles;
    GameObject[] obastacleArray;
    bool collide =false;

    void Start()
    {
        obstacles = new List<GameObject>();
        foreach (Transform go in this.transform)
        {
            obstacles.Add(go.gameObject);
        }
        obastacleArray = obstacles.ToArray();

    }



}
