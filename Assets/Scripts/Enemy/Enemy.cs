using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Enemy:MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir;
    protected Animator anim;
   
    //public Transform attacker;
    //public float hurtForce;

    

    [Header("״̬")]
    public bool isHurt;
    public bool isDead;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }


   
    public void OnTakeDamage(Transform attackTrans)
    {
                   
        //attacker=attackTrans;
        //if (attackTrans.position.x - transform.position.x > 0)
        //    transform.localScale = new Vector3(-1, 1, 1);
        //if (attackTrans.position.x - transform.position.x <0)
        //    transform.localScale = new Vector3(1, 1, 1);


        isHurt = true;
        anim.SetTrigger("hurt");
       
    }
    public void Ondie()
    {
        anim.SetBool("dead", true);
        isDead = true;
    }
    public void DestroyAfterAnimation()
    {
        Destroy(this.gameObject);
    }
    
}
