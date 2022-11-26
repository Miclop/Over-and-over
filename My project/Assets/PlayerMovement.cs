using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 8f;
    private Rigidbody2D rb;


    //for timer
    private float Timer;
    private float TimetoReset=1.0f;

    public static bool Teleporting;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Teleporting = false;
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
        if(!Teleporting)
        transform.position = new Vector2(transform.position.x + 0.01f * horizontal, transform.position.y + 0.01f * vertical);
    }
    
}