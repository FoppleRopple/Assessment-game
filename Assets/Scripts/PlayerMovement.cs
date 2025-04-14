using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Initialize variables
    private Rigidbody2D rb;
    [SerializeField] private float speedMult;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask groundLayer;
    
    private bool jumpReady = true;
    private BoxCollider2D boxCaster;

    // Set components
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCaster = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
        // Movement and jumping
        rb.linearVelocityX = Input.GetAxis("Horizontal") * speedMult;
        
        if (Input.GetKey(KeyCode.Space) && jumpReady == true)
        {
            Jump();

        } else if (jumpReady == false)
        {
            jumpReady = OnGround();
            Debug.Log("Off ground");
        }
    }

    // Functions
    private void Jump()
    {
        jumpReady = false;
        rb.linearVelocityY = jumpHeight;
    }

    private bool OnGround()
    {
        // Dunno if I can recycle this code to detect something else than the ground just yet
        RaycastHit2D onGround = Physics2D.BoxCast(boxCaster.bounds.center, boxCaster.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return onGround.collider != null;
    }
}
