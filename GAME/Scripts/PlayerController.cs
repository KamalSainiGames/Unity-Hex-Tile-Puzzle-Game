using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;
    public float smoothTurnTime = 0.1f;

    public float jumpForce = 5f;
    public float gravity = -9.8f;

    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 velocity;
    private float turnSmoothVelocity;

    private int cubeCount;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cubeCount = GameObject.FindGameObjectsWithTag("Cube").Length;
    }

    void Update()
    {
        Move();
        ApplyGravity();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(h, 0, v).normalized;

        if (inputDir.magnitude >= 0.1f)
        {
            // Camera-based angle
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            // Smooth rotation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move direction
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Jump
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpForce;
            }
        }
    }

    void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            cubeCount--;

            Debug.Log("Cube Collected: " + cubeCount);

            if (cubeCount <= 0)
            {
                Debug.Log("You Win!");
            }
        }
    }
}