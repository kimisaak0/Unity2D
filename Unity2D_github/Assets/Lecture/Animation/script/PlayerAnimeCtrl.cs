using UnityEngine;

public class PlayerAnimeCtrl : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) ) {
            animator.SetTrigger("isDie");
        }
    }

    public void OnDieEvent()
    {
        Debug.Log("End of Die Animation");
    }
}
