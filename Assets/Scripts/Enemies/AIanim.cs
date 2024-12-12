using UnityEngine;

public class AIanim : MonoBehaviour
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
            // Determine direction and set Animator parameters
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0)
                {
                    SetAnimationDirection("Right");
                }
                else
                {
                    SetAnimationDirection("Left");
                }
            }
            else
            {
                if (movement.y > 0)
                {
                    SetAnimationDirection("Up");
                }
                else
                {
                    SetAnimationDirection("Down");
                }
            }
        }


        // Update last position
        lastPosition = currentPosition;
    }

    void SetAnimationDirection(string direction)
    {
        // Reset all directional parameters
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);

        // Activate the correct directional parameter
        animator.SetBool(direction, true);
    }
}

