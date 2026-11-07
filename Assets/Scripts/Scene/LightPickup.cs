using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        
        Light2D playerLight = collision.GetComponent<Light2D>();

        if (playerLight != null)
        {
            playerLight.enabled = true;   
            Destroy(gameObject);          
        }
        else
        {
            Debug.LogWarning("玩家身上没有 Light2D 组件！");
        }
    }
}