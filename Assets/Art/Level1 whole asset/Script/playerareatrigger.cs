using UnityEngine;
using TMPro;
public class playerareatrigger : MonoBehaviour
{
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI BylineText;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        areatrigger area = collision.GetComponent<areatrigger>();
        if (area != null)
        {
            TitleText.text = area.title;
            BylineText.text = "By: " + area.author;
            Debug.Log(collision.gameObject.name);
        }
    }

}
