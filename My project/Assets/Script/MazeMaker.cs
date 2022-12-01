using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeMaker : MonoBehaviour
{
    //for timer
    private float Timer;
    private float TimetoReset = 4.0f;
    private bool Checking;
    

    public GameObject StartRoom;
    public GameObject LoadScreen;
    public FadeControll FC;

    private AudioSource AS;

    void Start()
    {
        Spawnstart();
        AS = this.GetComponent<AudioSource>();
        Checking = true;
        
    }
    void Update()
    {
        if (Checking)
        {
            Timer += Time.deltaTime;
            if (Timer >= TimetoReset)
            {

                if (CheckMaze())
                {
                    Checking = false;
                    LoadScreen.SetActive(false);
                    AS.Play();
                    FC.FadeIN();
                }
                else
                {
                    Invoke("Spawnstart", 0.1f);
                }

                Timer = 0;

            }
        }

     }
    void DestroyAll()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
            MazeInfo.NumofRoom = 0;
        }

    
    }
    void Spawnstart()
    {
        Debug.Log("Spawn Start");
        GameObject tempGO= Instantiate(StartRoom,transform.position,Quaternion.identity);
        tempGO.transform.parent = this.transform;
        MazeInfo.NumofRoom +=1;
    }
    bool CheckMaze()
    {
        if (MazeInfo.NumofRoom < 24)
        {
            DestroyAll();
            return false;
        }
        else
        {
            return true;
        }
    }
}
