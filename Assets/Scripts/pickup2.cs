using UnityEngine;

public class Pickup2 : MonoBehaviour
{
    private int pickupCounter = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            pickupCounter++;
            Debug.Log("Scrap collected: " + pickupCounter);
        }
    }
}
