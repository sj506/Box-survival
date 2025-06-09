using UnityEngine;
using UnityEngine.InputSystem; // 새로운 InputSystem을 위한 네임스페이스

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 inputDirection = Vector2.zero;

        if (Keyboard.current.leftArrowKey.isPressed)
            inputDirection.x -= 1f;
        if (Keyboard.current.rightArrowKey.isPressed)
            inputDirection.x += 1f;
        if (Keyboard.current.upArrowKey.isPressed)
            inputDirection.y += 1f;
        if (Keyboard.current.downArrowKey.isPressed)
            inputDirection.y -= 1f;

        inputDirection = inputDirection.normalized; // 대각선 이동 시 속도 일정하게

        rb.linearVelocity = inputDirection * moveSpeed;
    }
}
