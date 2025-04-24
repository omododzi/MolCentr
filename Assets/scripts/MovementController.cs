using System.Collections;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5f;
    public float runSpeed = 10f;
    public float rotationSpeed = 10f;
    
    private Vector3 velocity;
    private Vector2 inputDirection;
    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

     private void Update()
    {
        Move();
        ApplyGravity();
        CollisionFlags flags = controller.Move(velocity * Time.deltaTime);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("ismoving", true);
        }
        else
        {
            animator.SetBool("ismoving", false);
        }
        
    }

    void Move()
    {
        
        // Get camera forward and right vectors (ignoring Y axis)
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Get input axes
        inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        // Normalize input to prevent faster diagonal movement
        if (inputDirection.magnitude > 1f)
        {
            inputDirection.Normalize();
        }
        
        // Calculate movement direction relative to camera
        Vector3 movementDirection = (cameraForward * inputDirection.y + cameraRight * inputDirection.x).normalized;
        
        // Apply speed multiplier based on run key
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;
        Vector3 movement = movementDirection * currentSpeed;
        
        // Apply movement to velocity (preserve vertical velocity for gravity)
        velocity.x = movement.x;
        velocity.z = movement.z;
        
        // Rotate character to face movement direction when moving
        if (inputDirection.magnitude > 0.1f)
        {
            // Calculate target rotation based on movement direction
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            
            // Smoothly rotate towards target direction
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            velocity.y = -0.5f; // Small force to keep character grounded
        }
    }

    
}
