using UnityEngine;

public class MovementP1 : MonoBehaviour
{
    public float speed;
    public float Slowmo_dorong;
    private Animator anim;

    private float jarak_dorong = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private bool isDorong;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            movement.y = 1;

        if (Input.GetKey(KeyCode.S))
            movement.y = -1;

        if (Input.GetKey(KeyCode.D))
            movement.x = 1;

        if (Input.GetKey(KeyCode.A))
            movement.x = -1;

        anim.SetFloat("moveX", movement.x);
        anim.SetFloat("moveY", movement.y);
        anim.SetBool("isMoving", movement != Vector2.zero);


        transform.Translate(movement * speed * Time.deltaTime); 
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        CheckDorong();
        Move();
    }

    void Move()
    {
        float currentSpeed = isDorong ? Slowmo_dorong : speed;
        rb.linearVelocity = movement * currentSpeed;
    }

    void CheckDorong()
    {
        isDorong = false;

        if (movement == Vector2.zero)
            return;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, jarak_dorong);

        if (hit.collider != null && hit.collider.CompareTag("Obstacle"))
        {
            isDorong = true;
        }
    }
}