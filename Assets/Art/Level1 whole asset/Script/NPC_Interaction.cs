using UnityEngine;
using Yarn.Unity;

public class NPC_Interaction : MonoBehaviour
{
    public GameObject interactPrompt;
    public DialogueRunner runner;
    public string startnode;
    bool caninteract = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactPrompt.SetActive(false);
        runner = FindAnyObjectByType<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (caninteract)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                runner.StartDialogue(startnode);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Playermovment player = collision.GetComponent<Playermovment>();
        if (player != null)
        {
            caninteract = true;
 
            interactPrompt.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Playermovment player = collision.GetComponent<Playermovment>();
        if (player != null)
        {
            interactPrompt.SetActive(false);
            caninteract = false;
            runner.Stop();
        }
    }
}
