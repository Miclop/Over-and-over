using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeInfo : MonoBehaviour
{
    public static int NumofRoom;
    public static int NumofRunes=3;
    public static GameObject[] Rooms;
    public static bool greenSpawn, bluespawn, yellowspawn;

   void Start()
    {
        NumofRoom = 0;
        NumofRunes = 3;
        greenSpawn = false;
        bluespawn = false;
        Rooms = new GameObject[50];
        yellowspawn = false;
    }






    //public Room[] Rooms;


}
