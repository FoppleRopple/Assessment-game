using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speedMult = 3;
    [SerializeField] private float jumpHeight = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = Input.GetAxis("Horizontal") * speedMult;
        if (Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocityY = jumpHeight;

        }
    }
}
