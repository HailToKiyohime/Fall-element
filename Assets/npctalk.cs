using System.Collections;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    [TextArea] public string message;
    public float typingSpeed = 0.05f;

    public GameObject dialogueBox; // panel background

    private bool playerInRange = false;
    private bool isTalking = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isTalking)
        {
            StartCoroutine(TypeDialogue());
        }
    }

    IEnumerator TypeDialogue()
    {
        isTalking = true;
        dialogueBox.SetActive(true);
        dialogueText.text = "";

        foreach (char c in message)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(2f);

        dialogueBox.SetActive(false);
        isTalking = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}