using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    private Vector2 limitMin = new Vector2(-8.0f, -4.5f);
    private Vector2 limitMax = new Vector2(8.0f, 4.5f);

    private void Update()
    {
        if ( transform.position.x < limitMin.x || transform.position.y < limitMin.y ||
             transform.position.x > limitMax.x || transform.position.y > limitMax.y)
        {
            Destroy(gameObject);
        }
    }
}
