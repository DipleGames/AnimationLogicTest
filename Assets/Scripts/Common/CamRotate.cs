using UnityEngine;

public class CamRotate : MonoBehaviour
{
    [Header("설정")]
    public float sensitivity = 2.0f;
    public Transform playerBody;    // 플레이어 본체(PlayerRoot)

    [Header("3인칭 거리 설정")]
    public float distance = 6.0f;   // 플레이어로부터의 거리 (Z: -6)
    public float height = 4.0f;     // 플레이어로부터의 높이 (Y: 4)

    float _mouseX = 0f;
    float _mouseY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (playerBody == null) return;

        // 2. 회전 적용
        // 플레이어 몸통은 좌우로만 회전
        playerBody.rotation = Quaternion.Euler(0, _mouseX, 0);

        // 카메라의 회전값 계산
        Quaternion rotation = Quaternion.Euler(_mouseY, _mouseX, 0);

        // 3. 카메라 위치 계산 (핵심)
        // 플레이어 위치에서 '회전된 뒤쪽 방향'으로 distance만큼 가고, '위쪽'으로 height만큼 이동
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + playerBody.position + new Vector3(0, height, 0);

        // 4. 최종 변수 적용
        transform.rotation = rotation;
        transform.position = position;
    }

    public void SetRotateValue(float mouseX, float mouseY)
    {
        _mouseX = mouseX * sensitivity;
        _mouseY = mouseY * sensitivity;

        _mouseY = Mathf.Clamp(_mouseY, -20f, 60f); 
    }
}