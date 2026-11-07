using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeAndTeleportTrigger : MonoBehaviour
{
    [Header("传送目的地 ")]
    public Transform teleportDestination;

    [Header("黑色渐显 UI 面板")]
    public Image fadePanel;

    [Header("变黑/变亮的过渡速度 ")]
    public float transitionDuration = 0.8f;

    [Header("变黑完成后、传送前的全黑停留时间 ")]
    public float holdBeforeTeleport = 1.0f;

    [Header("传送完成后的全黑停留时间 ")]
    public float holdAfterTeleport = 0.2f;  
    private bool isTeleporting = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTeleporting)
        {
            isTeleporting = true;
            StartCoroutine(TeleportSequence(other.transform));
        }
    }

    IEnumerator TeleportSequence(Transform playerTransform)
    {
       
        fadePanel.gameObject.SetActive(true);
        fadePanel.color = new Color(0, 0, 0, 0f);

        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / transitionDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadePanel.color = new Color(0, 0, 0, 1f); 

       
        yield return new WaitForSeconds(holdBeforeTeleport);

        
        yield return null; 
        playerTransform.position = teleportDestination.position;

        
        yield return new WaitForSeconds(holdAfterTeleport);

        
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