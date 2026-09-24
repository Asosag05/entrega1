using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float thrustForce = 5f;
    public float rotationSpeed = 120f;

    Vector2 thrustDirection;
    Rigidbody2D _rigidbody;

    float limX;
    float limY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        float screenHeight = Camera.main.orthographicSize * 2f;
        float screenWidth = screenHeight * Camera.main.aspect;

        limX = screenWidth / 2f;
        limY = screenHeight / 2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float thrust = Input.GetAxis("Vertical") * thrustForce;

        thrustDirection = transform.right;

        transform.Rotate(Vector3.forward, -rotation);
        _rigidbody.AddForce(thrust * thrustDirection);

        if (transform.position.x < -limX || transform.position.x > limX ||
            transform.position.y < -limY || transform.position.y > limY)
        {
            transform.position = Vector3.zero;
            _rigidbody.linearVelocity = Vector2.zero;
        }
    }
}
