using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 Dir;
    private Vector3 camDirection;
    private float horizontal;
    private float vertical;
    private Vector3 forward;
    private Vector3 right;
    private float speed = 0.01f;
    private Rigidbody2D rb;



    //for timer
    private float Timer;
    private float TimetoReset=2.5f;


    //for teleporting
    public static bool Teleporting;
    public static int PrevDir;
    public static int MovementDir;
    

    //get Cam
    public CameraControl CamControl;
    

    //for movementControl
    private bool notwall;

    //for Fade
    public FadeControll FC;

    private void Start()
    {
        Dir = Vector3.zero; 
        rb = this.GetComponent<Rigidbody2D>();
        Teleporting = false;
        MovementDir = 2;
        PrevDir = 2;
        notwall = true;
    }

    void Update()
    {
        
        if (Teleporting)
        {
            rb.velocity = Vector2.zero;

            FC.FadeOUT();
            Timer += Time.deltaTime;
            if(Timer >= TimetoReset)
            {
                FC.FadeIN();
                Timer = 0;
                Teleporting = false;
            }
            
        }
    }

    private void FixedUpdate()
    {
        Dir.x = Input.GetAxisRaw("Horizontal");
        Dir.y = Input.GetAxisRaw("Vertical");
       
        Vector2 desiredMoveDirection = Camera.main.transform.rotation * Dir;
        //Debug.Log(desiredMoveDirection);
        if(!Teleporting)rb.AddForce(new Vector2(desiredMoveDirection.x * speed, desiredMoveDirection.y * speed),ForceMode2D.Impulse);

        /*
        if(notwall)
        transform.Translate(speed * Time.deltaTime * desiredMoveDirection);
        else
        transform.Translate(speed * Time.deltaTime * -desiredMoveDirection);
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wall"))
        {
            notwall = false;
        }

        Debug.Log("in");

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("wall"))
        {
            notwall = true;
        }

        Debug.Log("out");

    }


    public void Rotates()
    {

            if (PrevDir == 0)
            {
                if (MovementDir == 0)
                {

                }
                else if (MovementDir == 1)
                {
                    
                    CamControl.RotateLeft();
                }
                else if (MovementDir == 2)
                {
                   
                    CamControl.Rotate180();
                }

                else if (MovementDir == 3)
                {
                    
                    CamControl.RotateRight();
                }

            }
            if (PrevDir == 1)
            {
                if (MovementDir == 0)
                {
                    
                    CamControl.RotateRight();
                }
                else if (MovementDir == 1)
                {
                   
                }
                else if (MovementDir == 2)
                {
                    
                    CamControl.RotateLeft();
                }

                else if (MovementDir == 3)
                {
                   
                    CamControl.Rotate180();
                }

            }

            if (PrevDir == 2)
            {
                if (MovementDir == 0)
                {
                    
                    CamControl.Rotate180();
                }
                else if (MovementDir == 1)
                {
                   
                    CamControl.RotateRight();
                }
                else if (MovementDir == 2)
                {
                    
                }

                else if (MovementDir == 3)
                {
                    
                    CamControl.RotateLeft();
                }

            }
            if (PrevDir == 3)
            {
                if (MovementDir == 0)
                {
                    
                    CamControl.RotateLeft();
                }
                else if (MovementDir == 1)
                {
                    
                    CamControl.Rotate180();
                }
                else if (MovementDir == 2)
                {
                   
                    CamControl.RotateRight();
                }

                else if (MovementDir == 3)
                {
                    
                }

            }
        
        PrevDir = MovementDir;
    }
    
    public void ResetCam()
    {
        CamControl.ResetCam();
    }
}