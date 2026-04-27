using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 2;

    private InputAction moveAction;

    private InputAction jumpAction;
    public bool onFloor = false;

    private Rigidbody2D rb;


    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (jumpAction.WasPressedThisFrame() && onFloor && !GameManager.gameOver)
        {
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
        
    }

    private void FixedUpdate()
    {
        if (!GameManager.gameOver)
        {
            float holizontalInput = moveAction.ReadValue<Vector2>().x;
            transform.Translate(Vector2.right * speed * holizontalInput * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) 
        {
            onFloor = true;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onFloor = false;
        }
    }

}
