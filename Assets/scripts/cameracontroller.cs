using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Transform target; // Объект, вокруг которого вращается камера
    [SerializeField] private float distance = 10.0f; // Стандартное расстояние
    [SerializeField] private float minDistance = 2.0f; // Минимальное расстояние
    [SerializeField] private float sensitivity = 100.0f; // Чувствительность мыши
    [SerializeField] private float yOffset = 0f; // Вертикальное смещение камеры
    [SerializeField] private LayerMask obstacleMask; // Слои препятствий

    [Header("Rotation Clamp")]
    [SerializeField] private float minVerticalAngle = -80f;
    [SerializeField] private float maxVerticalAngle = 80f;

    private float xRotation = 0f;
    private float yRotation = 0f;
    private float currentDistance;

    void Start()
    {
        currentDistance = distance;

        if (target == null)
        {
            Debug.LogError("CameraController: Target not assigned!");
            enabled = false; // Отключаем скрипт, если нет цели
        }
    }

    void LateUpdate()
    {
        if (!target) return;

        // Обработка ввода мыши
        xRotation += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        yRotation -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, minVerticalAngle, maxVerticalAngle);

        // Вычисляем желаемую позицию камеры
        Quaternion rotation = Quaternion.Euler(yRotation, xRotation, 0);
        Vector3 desiredPosition = target.position + rotation * new Vector3(0, yOffset, -distance);

        // Проверка на столкновения с препятствиями
        HandleCameraCollision(rotation, ref desiredPosition);

        // Плавное перемещение камеры
        transform.position = desiredPosition;
        transform.rotation = rotation;
    }

    private void HandleCameraCollision(Quaternion rotation, ref Vector3 desiredPosition)
    {
        RaycastHit hit;
        Vector3 direction = (desiredPosition - target.position).normalized;
        float maxDistance = Vector3.Distance(target.position, desiredPosition);

        if (Physics.SphereCast(
            target.position,
            0.2f, // Радиус сферы для плавного обхода углов
            direction,
            out hit,
            maxDistance,
            obstacleMask))
        {
            currentDistance = Mathf.Clamp(hit.distance * 0.9f, minDistance, distance);
            desiredPosition = target.position + rotation * new Vector3(0, yOffset, -currentDistance);
        }
        else
        {
            currentDistance = distance;
        }
    }
}