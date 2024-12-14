using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;               // Movement speed
    public Transform target;          // Target to follow (e.g., the player)
    public float minimumDistance;     // Minimum distance to maintain from the target
    public float proximityDistance;   // Distance within which the object starts chasing

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        // Check if the target is within the proximity distance and greater than the minimum distance
        if (distanceToTarget <= proximityDistance && distanceToTarget > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
