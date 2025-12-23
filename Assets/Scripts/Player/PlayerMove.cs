using UnityEngine;

public class PlayerMove : MonoBehaviour, IMovable
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true; // 회전 고정 (필수)
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0f, z).normalized;

        // Y 속도는 유지 (중력)
        Vector3 velocity = new Vector3(dir.x * moveSpeed, _rb.linearVelocity.y, dir.z * moveSpeed);

        _rb.linearVelocity = velocity;
    }
}
