using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (collisionInfo.collider.tag == "Positive" && !movement.polarity)
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (collisionInfo.collider.tag == "Negative" && movement.polarity)
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
