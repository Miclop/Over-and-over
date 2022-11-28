using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 8f;
    private int Movetype;
    private Rigidbody2D rb;



    //for timer
    private float Timer;
    private float TimetoReset=1.0f;


    //for teleporting
    public static bool Teleporting;
    public static int PrevDir;
    public static int MovementDir;
    

    //get Cam
    public CameraControl CamControl;



    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Teleporting = false;
        MovementDir = 2;
        PrevDir = 2;
        Movetype = 0;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
       
     
        if (Teleporting)
        {
            
            Timer += Time.deltaTime;
            if(Timer >= TimetoReset)
            {
                Timer = 0;
                Teleporting = false;
            }
            
        }
    }

    private void FixedUpdate()
    {
        movement();
       
       
    }
    
    private void movement()
    {
        if (Movetype == 0)
        {
            transform.position = new Vector2(transform.position.x + 0.01f * horizontal, transform.position.y + 0.01f * vertical);
        }
        if (Movetype == 1)
        {
            transform.position = new Vector2(transform.position.x + 0.01f * vertical, transform.position.y - 0.01f * horizontal);
        }
        if (Movetype == 2)
        {
            transform.position = new Vector2(transform.position.x - 0.01f * horizontal, transform.position.y - 0.01f * vertical);
        }
        if (Movetype == 3)
        {
            transform.position = new Vector2(transform.position.x - 0.01f * vertical, transform.position.y + 0.01f * horizontal);
        }
    }
    public void Rotates()
    {
        Debug.Log(PrevDir);
        Debug.Log("/");
        Debug.Log(MovementDir);
        if (!Teleporting)
        {
            if (PrevDir == 0)
            {
                if (MovementDir == 0)
                {
                    Movetype = 0;
                }
                else if (MovementDir == 1)
                {
                    Movetype = 1;
                    CamControl.RotateLeft();
                }
                else if (MovementDir == 2)
                {
                    Movetype = 2;
                    CamControl.Rotate180();
                }

                else if (MovementDir == 3)
                {
                    Movetype = 3;
                    CamControl.RotateRight();
                }

            }
            if (PrevDir == 1)
            {
                if (MovementDir == 0)
                {
                    Movetype = 2;
                    CamControl.RotateRight();
                }
                else if (MovementDir == 1)
                {
                    Movetype = 3;
                }
                else if (MovementDir == 2)
                {
                    Movetype = 0;
                    CamControl.RotateLeft();
                }

                else if (MovementDir == 3)
                {
                    Movetype = 1;
                    CamControl.Rotate180();
                }

            }

            if (PrevDir == 2)
            {
                if (MovementDir == 0)
                {
                    Movetype = 2;
                    CamControl.Rotate180();
                }
                else if (MovementDir == 1)
                {
                    Movetype = 3;
                    CamControl.RotateRight();
                }
                else if (MovementDir == 2)
                {
                    Movetype = 0;
                }

                else if (MovementDir == 3)
                {
                    Movetype = 1;
                    CamControl.RotateLeft();
                }

            }
            if (PrevDir == 3)
            {
                if (MovementDir == 0)
                {
                    Movetype = 1;
                    CamControl.RotateLeft();
                }
                else if (MovementDir == 1)
                {
                    Movetype = 3;
                    CamControl.Rotate180();
                }
                else if (MovementDir == 2)
                {
                    Movetype = 3;
                    CamControl.RotateRight();
                }

                else if (MovementDir == 3)
                {
                    Movetype = 1;
                }

            }
        }
        PrevDir = MovementDir;
    }
    
}