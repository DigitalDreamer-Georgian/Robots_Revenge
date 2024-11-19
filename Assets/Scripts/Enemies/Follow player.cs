using UnityEngine;

public class Followplayer : MonoBehaviour
{

    public float speed;
    public Transform target;
    public float MinimumDistance;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > MinimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}