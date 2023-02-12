using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReflectionsUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI reflectionHeader, reflectionText, happiness;
    [SerializeField] List<ReflectionsSO> reflections = new List<ReflectionsSO>();
    ReflectionsSO currentReflection;
    [SerializeField] GameObject[] reflectionButtons;
    int reflectionTypeIndex;
    [SerializeField] GameObject shuffleButton;

    private void GetRandomReflection()
    {
        int index = Random.Range(0, reflections.Count);
        currentReflection = reflections[index];
    }

    private void GetNextReflection()
    {
        if (reflections.Count > 0)
        {
            GetRandomReflection();
            DisplayReflection();
        } 
    }

    private void DisplayReflection()
    {
        for (int i = 0; i < reflectionButtons.Length; i++)
        {
            reflectionHeader.text = currentReflection.GetReflectionTitle();
            reflectionText.text = currentReflection.GetReflection();
            happiness.text = currentReflection.GetHappinessPoints().ToString();
        }
    }
}

// public class Quiz : MonoBehaviour
// {
//     [Header("Questions")]
//     [SerializeField] TextMeshProUGUI questionText;
//     [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
//     QuestionSO currentQuestion;

//     [Header("Answers")]
//     [SerializeField] GameObject[] answerButtons;
//     int correctAnswerIndex;
//     bool hasAnsweredEarly = true;

//     [Header("Button Colors")]
//     [SerializeField] Sprite defaultAnswerSprite;
//     [SerializeField] Sprite correctAnswerSprite;

//     [Header("Timer")]
//     [SerializeField] Image timerImage;
//     Timer timer;

//     [Header("Scoring")]
//     [SerializeField] TextMeshProUGUI scoreText;
//     ScoreKeeper scoreKeeper;

//     [Header("Progress Bar")]
//     [SerializeField] Slider progressBar;

//     public bool isComplete; 

//     void Awake()
//     {
//         timer = FindObjectOfType<Timer>();
//         scoreKeeper = FindObjectOfType<ScoreKeeper>();
//         progressBar.maxValue = questions.Count;
//         progressBar.value = 0;
//     }

//     void Update()
//     {
//         timerImage.fillAmount = timer.fillFraction;
//         if (timer.loadNextQuestion)
//         {
//             if (progressBar.value == progressBar.maxValue)
//             {
//                 isComplete = true;
//                 return;
//             }

//             hasAnsweredEarly = false;
//             GetNextQuestion();
//             timer.loadNextQuestion = false;
//         }
//         else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
//         {
//             DisplayAnswer(-1);
//             SetButtonState(false);
//         }
//     }

//     public void OnAnswerSelected(int index)
//     {
//         hasAnsweredEarly = true;
//         DisplayAnswer(index);
//         SetButtonState(false);
//         timer.CancelTimer();
//         scoreText.text  = "Score: " + scoreKeeper.CalculateScore() + "%";
//     }
//     void DisplayAnswer(int index)
//     {
//         Image buttonImage;
//         progressBar.value++;

//         if(index == currentQuestion.GetAnswerIndex())
//         {
//             questionText.text = "Correct!";
//             buttonImage = answerButtons[index].GetComponent<Image>();
//             buttonImage.sprite = correctAnswerSprite;
//             scoreKeeper.IncrementCorrectAnswers();
//         }
//         else
//         {
//             correctAnswerIndex = currentQuestion.GetAnswerIndex();
//             string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
//             questionText.text = "Sorry, the correct answer was:\n" + correctAnswer;
//             buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
//             buttonImage.sprite = correctAnswerSprite;
//         }
//     }

//     void GetNextQuestion()
//     {
//         if (questions.Count > 0)
//         {
//             SetButtonState(true);
//             SetDefaultButtonSprite();
//             GetRandomQuestion();
//             DisplayQuestion();
//             scoreKeeper.IncrementQuestionsSeen();
//         } 
//     }

//     void GetRandomQuestion()
//     {
//         int index = Random.Range(0, questions.Count);
//         currentQuestion = questions[index];
        
//         if (questions.Contains(currentQuestion))
//         {
//             questions.Remove(currentQuestion);
//         }
//     }

//     void DisplayQuestion()
//     {
//         questionText.text = currentQuestion.GetQuestion();


//         for (int i = 0; i < answerButtons.Length; i++)
//         {
//             TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
//             buttonText.text = currentQuestion.GetAnswer(i);
//         }
//     }

//     void SetButtonState(bool state)
//     {
//         for (int i = 0; i < answerButtons.Length; i++)
//         {
//             Button button = answerButtons[i].GetComponent<Button>();
//             button.interactable = state;
//         }
//     }

//     void SetDefaultButtonSprite()
//     {
//         for(int i = 0; i < answerButtons.Length; i++)
//         {
//             Image buttonImage = answerButtons[i].GetComponent<Image>();
//             buttonImage.sprite = defaultAnswerSprite;
//         }
//     }
// }