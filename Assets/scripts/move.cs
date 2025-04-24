using UnityEngine;

public class move : MonoBehaviour
{
  public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float rotationSpeed = 10f;
    public float groundCheckDistance = 0.2f;
    public float slopeLimit = 45f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded;
    private RaycastHit groundHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGround();
        Move();
        
        animator.SetBool("ismoving", rb.linearVelocity.magnitude > 0.1f);
    }

    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.1f, 
                                   Vector3.down, 
                                   out groundHit, 
                                   groundCheckDistance, 
                                   groundLayer);
    }

    private void Move()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDirection = (cameraForward * vertical + cameraRight * horizontal).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            // Корректировка направления движения по наклону поверхности
            Vector3 slopeDirection = Vector3.ProjectOnPlane(moveDirection, groundHit.normal).normalized;
            
            // Проверка угла наклона
            float slopeAngle = Vector3.Angle(Vector3.up, groundHit.normal);
            if (slopeAngle <= slopeLimit)
            {
                rb.linearVelocity = new Vector3(
                    slopeDirection.x * currentSpeed,
                    rb.linearVelocity.y,
                    slopeDirection.z * currentSpeed
                );
            }
            else
            {
                // Скольжение вниз по слишком крутому склону
                rb.linearVelocity = new Vector3(
                    slopeDirection.x * currentSpeed * 0.3f,
                    rb.linearVelocity.y,
                    slopeDirection.z * currentSpeed * 0.3f
                );
            }

            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
        else
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }
    }
    
    
    

