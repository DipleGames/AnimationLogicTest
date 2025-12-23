using UnityEngine;

public class CamRotate : MonoBehaviour
{
    [Header("설정")]
    public float sensitivity = 2.0f;
    public Transform playerBody;    // 플레이어 본체(PlayerRoot)

    [Header("3인칭 거리 설정")]
    public float distance = 6.0f;   // 플레이어로부터의 거리 (Z: -6)
    public float height = 4.0f;     // 플레이어로부터의 높이 (Y: 4)
    [SerializeField] float limitY;
    [SerializeField] float limitZ;

    float mouseX = 0f;
    float mouseY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 시작 시 초기 회전값 설정
        Vector3 angles = transform.eulerAngles;
        mouseX = angles.y;
        mouseY = angles.x;
    }

    void Update()
    {
        // 1. 마우스 입력 받기
        mouseX += Input.GetAxisRaw("Mouse X") * sensitivity;
        mouseY -= Input.GetAxisRaw("Mouse Y") * sensitivity;

        // 상하 회전 제한 (바닥이나 머리 끝까지 도는 것 방지)
        mouseY = Mathf.Clamp(mouseY, -limitY, limitZ); 
    }

    void LateUpdate()
    {
        if (playerBody == null) return;

        // 2. 회전 적용
        // 플레이어 몸통은 좌우로만 회전
        playerBody.rotation = Quaternion.Euler(0, mouseX, 0);

        // 카메라의 회전값 계산
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

        // 3. 카메라 위치 계산 (핵심)
        // 플레이어 위치에서 '회전된 뒤쪽 방향'으로 distance만큼 가고, '위쪽'으로 height만큼 이동
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + playerBody.position + new Vector3(0, height, 0);

        // 4. 최종 변수 적용
        transform.rotation = rotation;
        transform.position = position;
    }
}