using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizGameManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] answers;
        public int correctIndex;
    }

    public List<Question> questions;
    public Text questionText;
    public Button[] answerButtons;
    public Text feedbackText;
    public GameObject gamePanel;
    public GameObject quizIntroPanel;
    public Text scoreText;
    private int score = 0;

    private int currentQuestionIndex = 0;

    void Start()
    {
        gamePanel.SetActive(false);
        quizIntroPanel.SetActive(false);
    }

    public void StartGame()
    {
        gamePanel.SetActive(true);
        currentQuestionIndex = 0;
        score = 0;
        ShuffleQuestions();
        UpdateScoreUI();
        gamePanel.SetActive(true);
        ShowQuestion();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void ShuffleQuestions()
    {
        for (int i = 0; i < questions.Count; i++)
        {
            Question temp = questions[i];
            int randomIndex = Random.Range(i, questions.Count);
            questions[i] = questions[randomIndex];
            questions[randomIndex] = temp;
        }
    }


    void ShowQuestion()
    {
        feedbackText.text = "";
        Question q = questions[currentQuestionIndex];
        questionText.text = q.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = q.answers[i];
            answerButtons[i].interactable = true;
            answerButtons[i].image.color = Color.white; // Reset color
            int index = i;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void CheckAnswer(int selectedIndex)
    {
        bool isCorrect = selectedIndex == questions[currentQuestionIndex].correctIndex;

        // Color all buttons gray by default
        foreach (var btn in answerButtons)
        {
            btn.image.color = Color.gray;
        }

        // Set colors based on result
        if (isCorrect)
        {
            answerButtons[selectedIndex].image.color = new Color32(165, 214, 167, 255); // soft green
            feedbackText.text = "✅ Correct!";
            feedbackText.color = new Color32(76, 175, 80, 255); // green
            score += 1;
        }
        else
        {
            answerButtons[selectedIndex].image.color = new Color32(239, 154, 154, 255); // soft red
            feedbackText.text = "❌ Wrong!";
            feedbackText.color = new Color32(244, 67, 54, 255); // red
        }

        // Disable all buttons temporarily
        foreach (var btn in answerButtons)
        {
            btn.interactable = false;
        }

        UpdateScoreUI();

        Invoke("NextQuestion", 2f); // Wait 2 seconds before next
    }


    void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
            ShowQuestion();
        else
            EndGame();
    }

    void EndGame()
    {
        feedbackText.color = new Color32(50, 50, 50, 255);
        feedbackText.text = $"🎉 Quiz Finished!\nFinal Score: {score}/{questions.Count}";
        Invoke("CloseGame", 2f);
    }

    public void CloseGame()
    {
        gamePanel.SetActive(false);
    }

    public void CloseGameExternally()
    {
        StopAllCoroutines(); 
        gamePanel.SetActive(false);
    }

}
