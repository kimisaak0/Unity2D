using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField]
    private Color               colorOrigin;
    [SerializeField]
    private Color               color;
    
    private SpriteRenderer      spriteRenderer;

    private void Awake()
    {
        if(GetComponent<SpriteRenderer>() != null) {
            spriteRenderer = GetComponent<SpriteRenderer>();
        } else {
            Debug.Log("스프라이트 렌더러 컴포넌트가 없음.");
        }

        if(colorOrigin != null) {
            spriteRenderer.color = colorOrigin;
        } else {
            Debug.Log("colorOrigin이 지정되어 있지 않음");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(color != null) {
            spriteRenderer.color = color;
        } else {
            Debug.Log("color가 지정되어 있지 않음");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + " : OnCollisionStay2D() 실행 중");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(color != null) {
            spriteRenderer.color = colorOrigin;
        } else {
            Debug.Log("colorOrigin가 지정되어 있지 않음");
        }
    }

}
