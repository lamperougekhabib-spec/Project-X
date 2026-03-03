using UnityEngine;

public class MovementP2 : MonoBehaviour
{
    public float speed;
    public float Slowmo_dorong;

    private float jarak_dorong = 2f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private bool isDorong;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            movement.y = 1;

        if (Input.GetKey(KeyCode.DownArrow))
            movement.y = -1;

        if (Input.GetKey(KeyCode.RightArrow))
            movement.x = 1;

        if (Input.GetKey(KeyCode.LeftArrow))
            movement.x = -1;

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