using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButton()
    {
       
        gameObject.SetActive(false);

        
        
    }

    public void OnExitButton()
    {
        Application.Quit();
        Debug.Log("ÍË³öÓÎÏ·");
    }
}