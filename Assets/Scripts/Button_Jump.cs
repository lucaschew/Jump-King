using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Jump : MonoBehaviour
{

    public Player_Movement pm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jumpButtonPressed()
    {

        pm.jumpButtonPressed();


    }

    public void jumpButtonReleased()
    {

        pm.jumpButtonPressed();


    }

}
