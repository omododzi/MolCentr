using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform target; // Объект, вокруг которого будет вращаться камера
    public float distance = 10.0f; // Расстояние от камеры до объекта
    public float sensitivity = 100.0f; // Чувствительность вращения
    public float ybaf = 0f;

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    void Start()
    {
        // Инициализация начального положения камеры
        Vector3 angles = transform.eulerAngles;
        xRotation = angles.y;
        yRotation = angles.x;

        // Если target не назначен, используем текущее положение камеры
        if (target == null)
        {
            Debug.LogWarning("Target not assigned. Camera will rotate around its own position.");
        }
    }

    void LateUpdate()
    {
        if (target)
        {
            // Получаем ввод от мыши
            xRotation += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            yRotation -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            // Ограничиваем угол вращения по вертикали, чтобы камера не переворачивалась
            yRotation = Mathf.Clamp(yRotation, -80, 80);

            // Вычисляем новое положение камеры
            Quaternion rotation = Quaternion.Euler(yRotation, xRotation, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f + ybaf, -distance) + target.position;

            // Применяем вращение и положение к камере
            transform.rotation = rotation;
            transform.position = position;

            // Вращаем объект по оси Y, чтобы он следовал за горизонтальным вращением камеры
            target.rotation = Quaternion.Euler(0, xRotation, 0);
        }
    }
}
