using System.Collections;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private GameObject currentPlatformCollider;
    [SerializeField] private BoxCollider2D PlayerCollider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {   
            if(currentPlatformCollider!=null)
            StartCoroutine(DisablePlatformCoroutine());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OneWayPlat")
        {
            currentPlatformCollider = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OneWayPlatform") 
            currentPlatformCollider=null;
    }

    private IEnumerator DisablePlatformCoroutine()
    { 
        BoxCollider2D platformCollider=currentPlatformCollider.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(PlayerCollider, platformCollider);

        yield return new WaitForSeconds(0.25f);

        Physics2D.IgnoreCollision(PlayerCollider, platformCollider,false);
    }
}
