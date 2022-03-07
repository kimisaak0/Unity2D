using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PositionAutoDestroyer>() != null) {
            Destroy(other.gameObject);
        }

        //충돌이 일어나면 벽의 색상을 잠깐 변경한다.
        StartCoroutine("HitAnimation");
    }

    private IEnumerator HitAnimation()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);
        
        spriteRenderer.color = Color.white;
    }
   
}
