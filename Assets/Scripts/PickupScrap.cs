using UnityEngine;

public class PickupScrap : MonoBehaviour
{
    public int scrapValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Score.Instance.AddScore(scrapValue);
            Destroy(gameObject);
        }
    }
}
