using UnityEngine;

public class Move2D : MonoBehaviour
{
    [SerializeField]
    private float       speed = 5.0f; 
    [SerializeField]
    private float       jumpForce = 8.0f;

    private Rigidbody2D rigid2D;

    [HideInInspector]
    public bool         isLongJump = false;

    [SerializeField]
    private LayerMask           groundLayer;
    private CircleCollider2D    circle2D;
    private bool                isGrounded;
    private Vector3             footPosition;

    [SerializeField]
    private int                 maxJumpCnt = 2;
    private int                 crtJumpCnt = 0;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        circle2D = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        Bounds bounds   = circle2D.bounds;
        footPosition    = new Vector2(bounds.center.x, bounds.min.y);
        isGrounded      = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        if ( isGrounded == true && rigid2D.velocity.y <= 0) {
            crtJumpCnt = maxJumpCnt;
        }


        if ( isLongJump && rigid2D.velocity.y > 0 ) {
            rigid2D.gravityScale = 1.0f;
        } else {
            rigid2D.gravityScale = 2.5f;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPosition,0.1f);
    }

    public void Move(float x)
    {
        //x축 이동은 x * speed, y축 이동은 중력값
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if(crtJumpCnt > 0){
            rigid2D.velocity = Vector2.up * jumpForce;
            crtJumpCnt--;
        }
        
    }
}
