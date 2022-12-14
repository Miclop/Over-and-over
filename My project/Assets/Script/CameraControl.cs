using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static int PlayerDir;
    public static bool CamMove;
    // Start is called before the first frame update
    void Start()
    {
        PlayerDir = 5;
        CamMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }


    void MoveCamera()
    {
        if (CamMove)
        {
            if (PlayerDir == 0)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 6, this.transform.position.z);
                CamMove = false;
            }
            else if (PlayerDir == 1)
            {
                this.transform.position = new Vector3(this.transform.position.x - 6f, this.transform.position.y, this.transform.position.z);
                CamMove = false;
            }
            else if (PlayerDir == 2)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 6f, this.transform.position.z);
                CamMove = false;
            }
            else if (PlayerDir == 3)
            {
                this.transform.position = new Vector3(this.transform.position.x + 6f, this.transform.position.y, this.transform.position.z);
                CamMove = false;
            }
        }
    }
    public void RotateLeft()
    {
        this.transform.Rotate(new Vector3(0f, 0f, -90f), Space.World);
    }
    public void RotateRight()
    {
        this.transform.Rotate(new Vector3(0f, 0f, 90f), Space.World);
    }
    public void Rotate180()
    {
        this.transform.Rotate(new Vector3(0f, 0f, 180f), Space.World);
    }

    public void ResetCam()
    {
        this.transform.position= new Vector3(0, 0, -10);
        this.transform.rotation= Quaternion.identity;
    }

}
