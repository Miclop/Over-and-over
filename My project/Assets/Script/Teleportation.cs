using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    
    public int Teleportdirection;
    private GameObject Player;
    private PlayerMovement PM;
    
    public bool isWall;
    public bool isEnd;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PM = Player.GetComponent<PlayerMovement>();
        isWall = false;
        isEnd = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && PlayerMovement.Teleporting==false)
        {
            PlayerMovement.Teleporting = true;
            Invoke("Teleport",1f);
        }
    }

    void Teleport()
    {
   
        if (isEnd==true|| isWall==true)
        {
            Player.transform.position = new Vector3(0, -1, 0);
            PM.ResetCam();
            PlayerMovement.PrevDir = 2;
            PlayerMovement.MovementDir = 2;
            PM.PlayTeleFailSound();
            return;
        }
        CameraControl.PlayerDir = Teleportdirection;
        PlayerMovement.MovementDir = Teleportdirection;
        PM.PlayTeleSound();
        PM.Rotates();

       

        if (Teleportdirection == 0)
        {
            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - 2.5f);
            CameraControl.CamMove = true;

        }
        else if(Teleportdirection == 1)
        {
            Player.transform.position = new Vector2(Player.transform.position.x- 2.5f, Player.transform.position.y);
            CameraControl.CamMove = true;
        }
        else if (Teleportdirection == 2)
        {
            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + 2.5f);
            CameraControl.CamMove = true;
        }
        else if (Teleportdirection == 3)
        {
            Player.transform.position = new Vector2(Player.transform.position.x + 2.5f, Player.transform.position.y);
            CameraControl.CamMove = true;
        }

    }

}
