using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {

        cam = FindObjectOfType<Camera>();
        cam.aspect = 1080f / 2160f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 camera = transform.position;

        if (GameObject.Find("Player").transform.position.y> camera.y + cam.orthographicSize)
        {

            camera.y += cam.orthographicSize*2f;

        } else if (GameObject.Find("Player").transform.position.y< camera.y - cam.orthographicSize)
        {

            camera.y -= cam.orthographicSize * 2f;

        }

        //- GameObject.Find("Canvas").transform.position.y

        //Debug.Log(GameObject.Find("Player").transform.position.y );
        //Debug.Log(camera.y + cam.orthographicSize);
        transform.position = camera;

    }
}
