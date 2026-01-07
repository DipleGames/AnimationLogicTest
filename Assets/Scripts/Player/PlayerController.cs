using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private PlayerAttack _playerAttack;
    private PlayerMove _playerMove;
    private CamRotate _camRotate;

    float _keyBoardX = 0f;
    float _keyBoardZ = 0f;
    float _mouseX = 0f;
    float _mouseY = 0f;

    void Awake()
    {
        _playerAttack = GetComponent<PlayerAttack>();
        _playerMove = GetComponent<PlayerMove>();
        _camRotate = GetComponentInChildren<CamRotate>();
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true; 
    }

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        _mouseX = angles.y;
        _mouseY = angles.x;
    }

    // Update is called once per frame
    void Update()
    {
        // 키보드 입력 받기
        InputKeyBoardHandler();
        InputMouseHandler();

        _playerMove.Move(_keyBoardX, _keyBoardZ);
        _camRotate.SetRotateValue(_mouseX, _mouseY);
    }

    void InputKeyBoardHandler()
    {
        _keyBoardX = Input.GetAxisRaw("Horizontal");
        _keyBoardZ = Input.GetAxisRaw("Vertical");
    }

    void InputMouseHandler()
    {
        _mouseX += Input.GetAxisRaw("Mouse X");
        _mouseY -= Input.GetAxisRaw("Mouse Y");
    }
}
