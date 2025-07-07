using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class TreeDialogueUI : MonoBehaviour
{
    public GameObject dialoguePanel;
    public RawImage photo;
    public TextMeshProUGUI dialogueText;

    public void ShowDialogue(Texture imageTexture, string message)
    {
        dialoguePanel.SetActive(true);
        photo.texture = imageTexture;
        dialogueText.text = message;
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}

