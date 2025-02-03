
using UnityEngine;
using UnityEngine.SceneManagement;
public class losdscenes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void OnCollisionEnter2D()
    {
       // if (other.gameObjiect.CompareTag("player"))
        SceneManager.LoadScene(1);
    }
}
