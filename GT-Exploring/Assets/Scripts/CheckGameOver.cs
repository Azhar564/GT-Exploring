using UnityEngine;

public class CheckGameOver : MonoBehaviour
{
    public LayerMask layerPlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (layerPlayer == (layerPlayer | (1 << other.gameObject.layer)))
        {
            Destroy(other);
            GameManager.Instance.gameState = GameState.GameOver;
        }
    }
}