using UnityEngine;

public class move : MonoBehaviour
{
    private Vector3 _input;
    public float moveSpeed = 5f;
    public float runSpeed = 8f;
    public float rotationSpeed = 10f;
   
  

    private Rigidbody rb;
    private bool isGrounded;
    public Transform cameraTransform;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
       
        if (rb.linearVelocity.magnitude > 0.1f) // magnitude > 0.1f означает, что объект движется
        {
            animator.SetBool("ismoving", true);
        }
        else
        {
            animator.SetBool("ismoving", false);
        }
    }

    
    

   

    private void Move()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
        
        // Получаем ввод (WASD)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Направление движения ОТНОСИТЕЛЬНО КАМЕРЫ
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0; // Игнорируем наклон камеры вверх/вниз
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Рассчитываем направление движения (учитывая камеру)
        Vector3 moveDirection = (cameraForward * vertical + cameraRight * horizontal).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            // Двигаем персонажа
            rb.linearVelocity = new Vector3(
                moveDirection.x * currentSpeed,
                rb.linearVelocity.y,
                moveDirection.z * currentSpeed
            );

            // Поворачиваем персонажа в сторону движения (только по Y)
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
            // Останавливаем движение (но сохраняем гравитацию)
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }
    }
    
    
    

