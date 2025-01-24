using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathGround : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Log the death event
            Debug.Log("Player has died.");

            // End the game
            EndGame();
        }
    }

    void EndGame()
    {
        // Option 1: Reload the current scene (restart the game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Option 2: Quit the application (useful for standalone builds)
        // Application.Quit();
    }
}