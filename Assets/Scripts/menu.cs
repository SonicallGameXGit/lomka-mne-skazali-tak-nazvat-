using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void Intro()
    {
        SceneManager.LoadScene(1);
    }
    public void Boss()
    {
        SceneManager.LoadScene(2);
    }
    public void RickRoll()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }
}
