using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instan_Prefab : MonoBehaviour
{

    public Player_Movement script;
    public GameObject[] worldPrefab;
    public int startWorld = 0;
    public GUI gui;
    private GameObject currentWorld;

    // Start is called before the first frame update
    void Start()
    {
        createWorld(startWorld);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createWorld(int a)
    {
        deleteWorld();
        gui.controls();
        Vector3 place = Vector3.zero;

        switch (a)
        {

            case 0:
                place = new Vector3(-2.362892f, 30.02163f, 0);
                break;
            case 1:
                place = new Vector3(-2.653192f, 4.97907f, 0f);
                break;
            default:
                Debug.Log("Error");
                break;

        }


        currentWorld = Instantiate(worldPrefab[a], place, Quaternion.identity);
        script.changeWorld(a);

    }

    public void deleteWorld()
    {

        Destroy(currentWorld);

    }

}
