using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Move2D      move2D;

    private void Awake()
    {
        move2D = GetComponent<Move2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        move2D.Move(x);

        if ( Input.GetKeyDown(KeyCode.Space) ) {
            move2D.Jump();
        } 

        if ( Input.GetKey(KeyCode.Space) ) {
            move2D.isLongJump = true;
        }
        else if ( Input.GetKeyUp(KeyCode.Space) ) {
            move2D.isLongJump = false;
        }
    }
}
