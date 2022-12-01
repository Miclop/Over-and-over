using UnityEngine;
using TMPro;
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
    private Animator Anime;
    

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
    private bool started;

    //for Fade
    public FadeControll FC;


    //Sound Lib
    private Soundlib SB;
    private AudioSource AS;

    //Text
    public TextMeshProUGUI Numberleft;
    public GameObject Spacebar;
    public GameObject Text;
    public GameObject End;

    private void Start()
    {
        Dir = Vector3.zero;
        AS = this.GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody2D>();
        SB= GameObject.FindGameObjectWithTag("SoundLib").GetComponent<Soundlib>();
        Anime = this.GetComponent<Animator>();
        Teleporting = false;
        MovementDir = 2;
        PrevDir = 2;
        notwall = true;
        started = false;
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
        if (rb.velocity.magnitude <=0.05)
        {
            Anime.SetBool("isMoving", false); ;
        }
        else
        {
            Anime.SetBool("isMoving", true);
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            Anime.SetBool("isReverse", false);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            Anime.SetBool("isReverse", true);
        }

        Dir.x = Input.GetAxisRaw("Horizontal");
        Dir.y = Input.GetAxisRaw("Vertical");

      


        Vector2 desiredMoveDirection = Camera.main.transform.rotation * Dir;



        //Debug.Log(desiredMoveDirection);
        if (!Teleporting && started) {
            rb.AddForce(new Vector2(desiredMoveDirection.x * speed, desiredMoveDirection.y * speed), ForceMode2D.Impulse);
        }

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
        

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Crystal")){
            Spacebar.SetActive(true);
        }
        else
        {
            Spacebar.SetActive(false);
        }

        if (collision.CompareTag("book"))
        {
            Text.SetActive(true);
        }
        else
        {
            Text.SetActive(false);
        }
        if (collision.CompareTag("End"))
        {
            AS.clip = SB.Clips[3];
            AS.Play();
            End.SetActive(true);
        }
        if (collision.CompareTag("Crystal") && Input.GetKey(KeyCode.Space))
        {
            
            PlayClearRuneSound();
            Destroy(collision.gameObject);
            MazeInfo.NumofRunes -= 1;
            if (MazeInfo.NumofRunes == 2)
                Numberleft.SetText("TWO");
            if (MazeInfo.NumofRunes == 1)
                Numberleft.SetText("ONE");
            if (MazeInfo.NumofRunes == 0)
                Numberleft.SetText("ZERO");

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("wall"))
        {
            notwall = true;
        }


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
                    this.RotateLeft();
                    CamControl.RotateLeft();
                }
                else if (MovementDir == 2)
                {
                    this.Rotate180();
                    CamControl.Rotate180();
                }

                else if (MovementDir == 3)
                {
                    this.RotateRight();    
                    CamControl.RotateRight();
                }

            }
            if (PrevDir == 1)
            {
                if (MovementDir == 0)
                {
                    this.RotateRight();
                    CamControl.RotateRight();
                }
                else if (MovementDir == 1)
                {
                   
                }
                else if (MovementDir == 2)
                {
                    
                    this.RotateLeft();
                    CamControl.RotateLeft();
                }

                else if (MovementDir == 3)
                {
                    this.Rotate180();
                    CamControl.Rotate180();
                }

            }

            if (PrevDir == 2)
            {
                if (MovementDir == 0)
                {
                    this.Rotate180();
                    CamControl.Rotate180();
                }
                else if (MovementDir == 1)
                {
                    this.RotateRight();
                    CamControl.RotateRight();
                }
                else if (MovementDir == 2)
                {
                    
                }

                else if (MovementDir == 3)
                {
                    this.RotateLeft();
                    CamControl.RotateLeft();
                }

            }
            if (PrevDir == 3)
            {
                if (MovementDir == 0)
                {
                    this.RotateLeft();
                    CamControl.RotateLeft();
                }
                else if (MovementDir == 1)
                {
                    this.Rotate180();
                    CamControl.Rotate180();
                }
                else if (MovementDir == 2)
                {
                    this.RotateRight();
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
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void RotateLeft()
    {
        this.transform.Rotate(new Vector3(0f, 0f, -90f), Space.World);
    }
    private void RotateRight()
    {
        this.transform.Rotate(new Vector3(0f, 0f, 90f), Space.World);
    }
    private void Rotate180()
    {
        this.transform.Rotate(new Vector3(0f, 0f, -180f), Space.World);
    }


    public void PlayTeleSound()
    {
        AS.clip = SB.Clips[1];
        AS.Play();
    }
    public void PlayTeleFailSound()
    {
        AS.clip = SB.Clips[2];
        AS.Play();
    }
    public void PlayClearRuneSound()
    {
        AS.clip = SB.Clips[0];
        AS.Play();
    }
    
    public void StartGame()
    {
        started = true;
    }
}