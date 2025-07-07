using UnityEngine;

public class TreeClickTrigger : MonoBehaviour
{
    public AudioClip treeVoiceClip;                  // Tree-specific voice
    public FarmerController farmerController;        // Reference to farmer
    public InteractionGate interactionGate;          // Reference to gate manager
    public Texture treeImage;
    public string treeMessage;

    private TreeDialogueUI dialogueUI;

    void Start()
    {
        dialogueUI = FindObjectOfType<TreeDialogueUI>();
    }

    // Call this from your UI button instead of OnMouseDown
    public void OnTreeButtonClicked()
    {
        if (farmerController != null && treeVoiceClip != null)
        {
            Debug.Log("Clicked " + gameObject.name);
            farmerController.PlayVoice(treeVoiceClip);
        }

        if (dialogueUI != null)
        {
            dialogueUI.ShowDialogue(treeImage, treeMessage);
        }

        if (interactionGate != null)
        {
            interactionGate.DisableInteractions();
        }
    }
}
