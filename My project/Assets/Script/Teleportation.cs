using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    
    public int Teleportdirection;
    private GameObject Player;
    private PlayerMovement PM;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PM = Player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Teleport();
        }
    }

    void Teleport()
    {
        CameraControl.PlayerDir = Teleportdirection;
        PlayerMovement.MovementDir = Teleportdirection;
        PM.Rotates();
        if (Teleportdirection == 0)
        {
            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - 0.5f);
            CameraControl.CamMove = true;
            PlayerMovement.Teleporting = true;
        }
        else if(Teleportdirection == 1)
        {
            Player.transform.position = new Vector2(Player.transform.position.x- 0.5f, Player.transform.position.y);
            PlayerMovement.Teleporting = true;
            CameraControl.CamMove = true;
        }
        else if (Teleportdirection == 2)
        {
            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + 0.5f);
            CameraControl.CamMove = true;
            PlayerMovement.Teleporting = true;
        }
        else if (Teleportdirection == 3)
        {
            Player.transform.position = new Vector2(Player.transform.position.x+ 0.5f, Player.transform.position.y);
            CameraControl.CamMove = true;
            PlayerMovement.Teleporting = true;
        }
    }

}
