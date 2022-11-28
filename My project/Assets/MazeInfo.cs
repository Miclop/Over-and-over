using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeInfo : MonoBehaviour
{
    public static int NumofRoom;
    public static GameObject[] Rooms;
    public static bool greenSpawn, bluespawn, yellowspawn;

   void Start()
    {
        NumofRoom = 0;
        greenSpawn = false;
        bluespawn = false;
        Rooms = new GameObject[50];
        yellowspawn = false;
    }






    //public Room[] Rooms;


}
