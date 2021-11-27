using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{

    [SerializeField] public GameObject[] gui_controls = new GameObject[5]; 
    [SerializeField] public GameObject[] gui_pause = new GameObject[7];

    // Start is called before the first frame update
    void Start()
    {

        //controls();
        controls();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void controls()
    {
        reset();
        foreach (GameObject g in gui_controls)
            g.SetActive(true);

    }

    public void pause()
    {
        reset();
        foreach (GameObject g in gui_pause)
            g.SetActive(true);

    }

    private void reset()
    {

        foreach (GameObject g in gui_controls)
            g.SetActive(false);

        foreach (GameObject g in gui_pause)
            g.SetActive(false);


    }

}
