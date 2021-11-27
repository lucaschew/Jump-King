using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] public float speed= 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= -10.8f)
            transform.position = new Vector2(transform.position.x, 10.8f);

        transform.position = new Vector2(transform.position.x, transform.position.y - (speed * Time.deltaTime));

    }
}
