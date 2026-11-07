using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyExit : MonoBehaviour
{
    public void OnBackButton()
    {
        SceneManager.LoadScene("SmapleScene");
    }
}