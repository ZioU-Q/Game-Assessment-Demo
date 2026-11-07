using Unity.VisualScripting;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public Vector2 bottomOffset;

    public float checkRaduis;

    public LayerMask groundLayer;

    public bool isGround;


    private void Update()
    {
        Check();
    }
    public void Check()
    {
        //检测地面
        isGround = Physics2D.OverlapCircle((Vector2)transform.position+ bottomOffset, checkRaduis, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        // 计算椭圆中心点
        Vector2 center = (Vector2)transform.position + bottomOffset;

        // 假设你要把 X 轴（宽度）拉长为原来的 2 倍，高度不变。
        float widthScale = 2.0f;
        float xRadius = checkRaduis * widthScale;
        float yRadius = checkRaduis;

        // 用代码模拟画出椭圆 (把圆分成 40 段来画)
        for (int i = 0; i < 40; i++)
        {
            float angle = (i / 40.0f) * Mathf.PI * 2f;
            Vector2 pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Vector2 point = new Vector2(pos.x * xRadius, pos.y * yRadius) + center;

            // 计算下一个点的位置
            float nextAngle = ((i + 1) / 40.0f) * Mathf.PI * 2f;
            Vector2 nextPos = new Vector2(Mathf.Cos(nextAngle), Mathf.Sin(nextAngle));
            Vector2 nextPoint = new Vector2(nextPos.x * xRadius, nextPos.y * yRadius) + center;

            // 画线连接这两个点
            Gizmos.DrawLine(point, nextPoint);
        }
    }
}
