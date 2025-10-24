using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Play()
    {
       SceneManager.LoadScene("Game");
    }
    public void Exit()
    {
        Debug.Log("Saliendo");
        Application.Quit();
    }
}
