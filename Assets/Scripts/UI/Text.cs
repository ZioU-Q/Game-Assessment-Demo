using UnityEngine;
using TMPro;
using System.Collections; 

public class CircleCollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public string message = "You can't go up, because I didn't write double jump code.";

    private bool isDemoEnded = false;

    void Start()
    {
        if (tipText != null)
        {
            tipText.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isDemoEnded) 
            {
                TriggerUI();
            }
        }
    }

    void TriggerUI()
    {
        if (tipText != null)
        {
            tipText.text = message;
            tipText.gameObject.SetActive(true); 

            
            StartCoroutine(HideTextAfterDelay(3f));
        }

        isDemoEnded = true; 
       
    }

  
    IEnumerator HideTextAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds); 

        if (tipText != null)
        {
            tipText.gameObject.SetActive(false); 
        }
    }
}