using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMovement movement;

    void OnTriggerEnter()
    {
        if (movement.enabled)
        {
            movement.enabled = false;
            gameManager.CompleteLevel();
            Invoke("LoadNextLevel", 3);
        }
    }
    void LoadNextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
