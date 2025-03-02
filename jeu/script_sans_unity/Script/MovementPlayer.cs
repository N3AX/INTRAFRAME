using UnityEngine;
public class MovementPlayer : MonoBehaviour
{
    public float jumpf;
    public bool isjumping;
    public float Ms;
    public Rigidbody2D rb;
    private Vector3 velocity=Vector3.zero;
    private Vector3 respawnPoint;
    


    void Start()
    {
        respawnPoint = transform.position; 
    }
    void FixedUpdate()
    {
        float horizontalM = Input.GetAxis("Horizontal") * Ms * Time.deltaTime;

        if(Input.GetButtonDown("Jump"))
        {
            isjumping = true;
        }

        MovePlayer(horizontalM);
    }

    void MovePlayer(float _horizontalM)
    {
        Vector3 target = new Vector2(_horizontalM, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, target, ref velocity, .05f);

        if(isjumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpf));
            isjumping = false;
        }
    
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Zombie")) 
        {
            transform.position = respawnPoint;
        }
        
    }


}
