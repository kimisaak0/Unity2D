using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode     keyCodeFire = KeyCode.Space;
    [SerializeField]
    private GameObject  bulletPrefab;
    
    private Vector3     lastMoveDirection = Vector3.right;

    private float       moveSpeed = 5.0f;               //이동 속도
    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        rigid2D.velocity = new Vector3(x,y,0) * moveSpeed;

        if ( x != 0 || y != 0 ) {
            lastMoveDirection = new Vector3(x,y,0);
        }

        if( Input.GetKeyDown(keyCodeFire) ) {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            clone.name = "Bullet";
            clone.transform.localScale = Vector3.one * 0.5f;
            clone.GetComponent<SpriteRenderer>().color = Color.red;
            
            clone.GetComponent<Movement2D>().SetUp(lastMoveDirection, 5.0f);
        }

    }
}
