using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Playermovment : MonoBehaviour
{

    public float speed = 5.0f;
    void Start()
    {
   
      

    }

// Update is called once per frame
void Update()
    { 
        Vector2 direction = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
            {
            direction = Vector2.up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
            direction = Vector2.down;
            }
            else if (Input.GetKey(KeyCode.A))
            {   
            direction = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.D))
             {
           direction = Vector2.right;
            }

        float dt = Time.deltaTime;
        
        Vector3 change = direction * speed * dt;
        transform.position = transform.position + change;
    }
}
