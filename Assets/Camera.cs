using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;         // �������� ����������� WASD
    public float rotationSpeed = 5f;      // �������� �������� ���
    public float panSpeed = 0.5f;         // �������� ��������������� ���
    public float zoomSpeed = 10f;         // �������� ����������� ���������
    public float minZoom = 5f;            // ���. ���������� �� ����
    public float maxZoom = 100f;          // ����. ���������� �� ����

    private Vector3 targetPosition;       // ����� ������ ������ (���� "�������")

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
        if (Input.GetMouseButton(1)) // ���
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed;
            float rotY = -Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.RotateAround(targetPosition, Vector3.up, rotX);
            transform.RotateAround(targetPosition, transform.right, rotY);
        }
    }

    void HandleMousePanning()
    {
        if (Input.GetMouseButton(2)) // ���
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
