using UnityEngine;

public class GreetingPromptHandler : MonoBehaviour
{
    public GameObject greetingPrompt;      // The greeting panel to hide
    public GameObject optionsButton;       // The Options Button to show
    public FarmerController farmerController; // Assign this in Inspector

    public void HideGreetingPrompt()
    {

        // Hide the greeting prompt
        greetingPrompt.SetActive(false);

        // Show the options UI
        optionsButton.SetActive(true);

        farmerController.PlayWave();
        farmerController.PlayIdle();

    }
}


