using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadePanel : MonoBehaviour
{
   
    public Transform teleportDestination;

    
    public Image fadePanel;

   
    public float transitionDuration = 1f;

    private bool isTeleporting = false; 

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player") && !isTeleporting)
        {
            isTeleporting = true;
            
            StartCoroutine(TransitionSequence(other.transform));
        }
    }

    IEnumerator TransitionSequence(Transform playerTransform)
    {
      
        fadePanel.gameObject.SetActive(true);
        fadePanel.color = new Color(0, 0, 0, 0f);

        float elapsedTime = 0f;
        Color currentColor = fadePanel.color;

       
        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
           
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / transitionDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        
        fadePanel.color = new Color(0, 0, 0, 1f);
        yield return null; 

        
        playerTransform.position = teleportDestination.position;
        
        elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
          
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / transitionDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
       
        fadePanel.color = new Color(0, 0, 0, 0f);
        fadePanel.gameObject.SetActive(false);

        
        isTeleporting = false;
    }
}