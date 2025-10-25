using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
    public void Exit()
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }
}
