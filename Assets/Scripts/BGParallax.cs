using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGParallax : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector3 startPosition;
    private float length;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translation: Vector3.right* speed * Time.deltaTime  * parallaxEffect);

        if(transform.position.x > 19.2f)
        {
            transform.position = startPosition;
        }



        
    }
}
