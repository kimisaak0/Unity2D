using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float       moveSpeed = 5.0f;               //이동 속도
    private Rigidbody2D rigid2D;

    private float x = 0.0f;
    private float y = 0.0f;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigid2D.velocity = new Vector3(x,y,0) * moveSpeed;
    }

    public void SetUp(Vector3 other, float speed)
    {
        x = other.x;
        y = other.y;

        moveSpeed = speed;
    }


}
