using UnityEngine;

public class Ani_Trigger : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        // Check if components are present
        if (animator == null) 
        { 
            Debug.LogWarning("Animator component is missing from this GameObject."); 
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            animator.SetInteger("Direction", 1);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            animator.SetInteger("Direction", 2);
        }
        if (Input.GetAxis("Vertical")>0)
        {
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            animator.SetInteger("Direction", 4);
        }
    }
}
