using UnityEngine;

public class DestroyBarriers : MonoBehaviour
{
    public GameObject[] barriers;

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0 )
        {
            foreach (GameObject obstacle in barriers)
            {
                Destroy(obstacle);
            }

            enabled = false;
        }
    }
}
