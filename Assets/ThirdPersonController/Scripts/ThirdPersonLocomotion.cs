using UnityEngine;

public class SimpleThirdPersonLocomotion : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float jumpForce = 5f;
    public Transform cameraTransform;

    private CharacterController controller;
    private float verticalVelocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleJump();
    }

    void HandleMovement()
    {
        isGrounded = controller.isGrounded;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontal + transform.forward * vertical;
        controller.Move(movement * moveSpeed * Time.deltaTime);

        if (!isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity = -0.5f;
        }

        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }

    void HandleRotation()
    {
        if (cameraTransform != null)
        {
            Vector3 cameraForward = cameraTransform.forward;
            cameraForward.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void HandleJump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpForce;
        }
    }
}
