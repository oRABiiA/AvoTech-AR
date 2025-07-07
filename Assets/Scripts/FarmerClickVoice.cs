using UnityEngine;

public class FarmerClickVoice : MonoBehaviour
{
    public AudioClip farmerClickClip;
    public FarmerController farmerController;

    private void OnMouseDown()
    {
        if (farmerController != null && farmerClickClip != null)
        {
            farmerController.PlayVoice(farmerClickClip);
        }
    }
}
