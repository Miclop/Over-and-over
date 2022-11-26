using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public int Teleportdirecton;
    private GameObject Player;
    private GameObject Maze;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Maze = GameObject.FindGameObjectWithTag("123");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            //Debug.Log("hit");
            Teleport();
        }
    }

    void Teleport()
    {
        if (Teleportdirecton == 0)
        {
            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - 0.5f);
            PlayerMovement.Teleporting = true;
            Maze.transform.Rotate(0f, 0.0f, 180f, Space.World);
        }
        else if(Teleportdirecton == 1)
        {
            Player.transform.position = new Vector2(Player.transform.position.x- 0.5f, Player.transform.position.y);
            PlayerMovement.Teleporting = true;
            Maze.transform.Rotate(0f, 0.0f, -90f, Space.World); 
        }
        else if (Teleportdirecton == 2)
        {
            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + 0.5f);
            PlayerMovement.Teleporting = true;
            Maze.transform.Rotate(0f, 0.0f, 0.0f, Space.World);
        }
        else if (Teleportdirecton == 3)
        {
            Player.transform.position = new Vector2(Player.transform.position.x+ 0.5f, Player.transform.position.y);
            PlayerMovement.Teleporting = true;
            Maze.transform.Rotate(0f, 0.0f, 90f, Space.World);
        }
    }

}
