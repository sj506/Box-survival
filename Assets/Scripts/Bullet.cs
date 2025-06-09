using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject);   // 적 제거
            Destroy(gameObject);         // 총알 제거
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // 화면 밖으로 나가면 파괴
    }
}