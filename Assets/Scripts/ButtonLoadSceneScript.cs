using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadSceneScript : MonoBehaviour
{
    public void ButtonLoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
