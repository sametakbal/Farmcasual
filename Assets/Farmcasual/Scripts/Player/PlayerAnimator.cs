using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Animator animator;


    [Header(" Settings ")]
    [SerializeField] private float moveSpeedMultiplier = 50f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ManageAnimations(Vector3 moveVector)
    {
        if (moveVector.magnitude > 0)
        {
            animator.SetFloat("moveSpeed", moveVector.magnitude * moveSpeedMultiplier);
            PlayRunAnimation();
            animator.transform.forward = moveVector.normalized;
        }
        else
        {
            PlayIdleAnimation();
        }
    }

    private void PlayRunAnimation()
    {
        animator.Play("Run");
        Debug.Log("Playing Run Animation");
    }
    private void PlayIdleAnimation()
    {
        animator.Play("Idle");
        Debug.Log("Playing Idle Animation");
    }
}
