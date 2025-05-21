using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;         // Скорость перемещения WASD
    public float rotationSpeed = 5f;      // Скорость вращения ПКМ
    public float panSpeed = 0.5f;         // Скорость панорамирования СКМ
    public float zoomSpeed = 10f;         // Скорость приближения колесиком
    public float minZoom = 5f;            // Мин. расстояние от цели
    public float maxZoom = 100f;          // Макс. расстояние от цели

    private Vector3 targetPosition;       // Центр фокуса камеры (куда "смотрим")

    void Start()
    {
        targetPosition = transform.position + transform.forward * 10f;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseRotation();
        HandleMousePanning();
        HandleZoom();
    }

    void HandleMovement()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = transform.TransformDirection(direction) * moveSpeed * Time.deltaTime;
        transform.position += move;
        targetPosition += move;
    }

    void HandleMouseRotation()
    {
        if (Input.GetMouseButton(1)) // ПКМ
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed;
            float rotY = -Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.RotateAround(targetPosition, Vector3.up, rotX);
            transform.RotateAround(targetPosition, transform.right, rotY);
        }
    }

    void HandleMousePanning()
    {
        if (Input.GetMouseButton(2)) // СКМ
        {
            float panX = -Input.GetAxis("Mouse X") * panSpeed;
            float panY = -Input.GetAxis("Mouse Y") * panSpeed;
            Vector3 move = transform.right * panX + transform.up * panY;

            transform.position += move;
            targetPosition += move;
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPosition);

            float zoomAmount = scroll * zoomSpeed;
            if ((scroll > 0 && distance > minZoom) || (scroll < 0 && distance < maxZoom))
            {
                transform.position += direction * zoomAmount;
            }
        }
    }
}
