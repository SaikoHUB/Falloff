using UnityEngine;
using UnityEngine.SceneManagement;

public class OnMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EasyRock")
        {
            // ADD SCRIPT to change the difficulty of the game
            SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.tag == "MediumRock")
        {
            // ADD SCRIPT to change the difficulty of the game
            SceneManager.LoadScene(0);
        }
        else if (collision.gameObject.tag == "HardRock")
        {
            // ADD SCRIPT to change the difficulty of the game
            SceneManager.LoadScene(0);
        }
    }
}
