using UnityEngine;
using UnityEngine.InputSystem; // 새로운 InputSystem을 위한 네임스페이스

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    private Rigidbody2D rb;


    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;
    public float targetDistance = 5f;
    private float nextFireTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
    }

    void Update()
    {
        MovePlayer();

        Transform nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null && Time.time >= nextFireTime)
        {
            ShootAt(nearestEnemy);
            nextFireTime = Time.time + fireRate;
        }
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

    Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform nearest = null;
        float minDistance = targetDistance;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                nearest = enemy.transform;
            }
        }

        return nearest;
    }

    void ShootAt(Transform target)
    {
        // 방향 계산
        Vector2 dir = (target.position - firePoint.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // 총알 생성 + 회전
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, angle));
    }

}
