using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Camera cam;
    private Vector2 startPos;

    private Vector2 camPrevPos;
    
    void Start()
    {
        startPos = transform.position;
        cam = GameManager.Instance.Cam;
        camPrevPos = cam.transform.position;
    }

    void Update()
    {
    

        float multiplier =  GameManager.Instance.ParallaxStrength * transform.position.z * -1f;
        float para = (camPrevPos.x - cam.transform.position.x) * multiplier;

        transform.position = new Vector3(transform.position.x + para, transform.position.y, transform.position.z);
        //Debug.Log(para);

        camPrevPos = cam.transform.position;
    }
}
