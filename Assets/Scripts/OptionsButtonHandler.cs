using UnityEngine;

public class OptionsButtonHandler : MonoBehaviour
{
    public GameObject optionModal;
    [SerializeField] private GameObject quizGamePanel;
    [SerializeField] private GameObject quizIntroPanel;
    [SerializeField] private QuizGameManager quizGameManager; // Reference to the script

    public void OnQuizButtonClicked()
    { 
        quizIntroPanel.SetActive(true);
    }

    public void OnStartQuizClicked()
    {
        quizIntroPanel.SetActive(false);
        quizGameManager.StartGame();
    }

    public void ToggleOptionModal()
    {
        // Toggle the modal's visibility
        optionModal.SetActive(!optionModal.activeSelf);
    }
}