using UnityEngine;

public class move : MonoBehaviour
{
     private Vector3 _input;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float rayDistance = 0.9f;
    public float rotationSpeed = 10f;
    private Rigidbody rb;
    private bool isGrounded;
    public Transform cameraTransform; // Ссылка на трансформ камеры

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckGrounded();
        Move();
        Jump();
    }

    private void Move()
    {
        bool canrun = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKey(KeyCode.LeftControl)&& !canrun)
        {
            gameObject.transform.localScale = new Vector3(1f, 0.7f, 1f);
            moveSpeed = 2f;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1f, 1.3f, 1f);
            moveSpeed = 5f;
        }

        if (Input.GetKey(KeyCode.LeftShift)&&canrun)
        {
            moveSpeed = 8f;}
        else if (Input.GetKeyUp(KeyCode.LeftShift)&& !canrun)
        {
            moveSpeed = 5f;
        }
        // Получаем ввод от игрока
        float horizontal = Input.GetAxis("Horizontal"); // Влево/вправо (A/D или стрелки влево/вправо)
        float vertical = Input.GetAxis("Vertical"); // Вперед/назад (W/S или стрелки вверх/вниз)

        // Создаем вектор движения на основе ввода
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;

        // Если есть движение, учитываем направление камеры
        if (movement != Vector3.zero)
        {
            // Вычисляем угол поворота персонажа на основе направления камеры
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Применяем движение к Rigidbody
            rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);

            // Плавное вращение персонажа в направлении движения
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Останавливаем горизонтальное движение, если нет ввода
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        }
    }

    private void Jump()
    {
        // Если персонаж на земле и нажата клавиша прыжка, прыгаем
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void CheckGrounded()
    {
        // Проверяем, находится ли персонаж на земле
        isGrounded = Physics.Raycast(transform.position, Vector3.down, rayDistance);

        
    }
}
