using UnityEngine;

public class TwoSideAnimAi : MonoBehaviour
{
    private Animator animator;
    private Vector2 lastPosition;
    private Vector2 movement;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate movement direction
        Vector2 currentPosition = transform.position;
        movement = currentPosition - lastPosition;

        if (movement != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            // Determine direction and set Animator parameters
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0)
                {
                    // flip horizontally, change the scale on the X-axis
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    // flip horizontally, change the scale on the X-axis
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }

        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        // Update last position
        lastPosition = currentPosition;
    }
}
