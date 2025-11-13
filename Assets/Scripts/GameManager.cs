using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BossHealth boss; // Arrastrá el boss desde el inspector

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
            SceneManager.LoadScene("Game");

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            Application.Quit();

        if (boss == null)
        {
            SceneManager.LoadScene("WinGame");
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PauseMenu()
    {
        SceneManager.LoadScene("PauseMenu");
    }

    public void Restart()
    {

    }
}
