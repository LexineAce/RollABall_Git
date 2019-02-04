using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseSlider : MonoBehaviour
{
    public float speed = 1.0f;
    Vector3 pointA;
    Vector3 pointB;


    // Start is called before the first frame update
    void Start()
    {
        pointA = new Vector3(39, 1, 4);
        pointB = new Vector3(30, 1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);

    }
}
