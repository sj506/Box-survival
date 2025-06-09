using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;        // 플레이어의 Transform
    public Transform background;    // 배경의 Transform
    public Vector2 backgroundOffset = Vector2.zero;  // 배경 위치 보정용 오프셋

    void LateUpdate()
    {
        if (player != null && background != null)
        {
            // 배경이 플레이어의 위치를 따라가게 함
            Vector3 newBackgroundPos = new Vector3(
                player.position.x + backgroundOffset.x,
                player.position.y + backgroundOffset.y,
                background.position.z
            );

            background.position = newBackgroundPos;
        }
    }
}
