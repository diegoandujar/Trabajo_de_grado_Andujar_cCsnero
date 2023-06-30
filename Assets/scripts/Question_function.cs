using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Question_function : MonoBehaviour
{
    int numPreguntas = 0;
    int numCorrects;

    public PreguntasCorrectas preguntasCorrectas;

    public Questions[] questions;
    private static List<Questions> Preguntas;

    private Questions currentQuestion;

    [SerializeField]
    private Text textoPregunta;

    [SerializeField] private float timeBetweenQuestions = 1f;

    // Start is called before the first frame update
    void Start()
    {
        preguntasCorrectas = transform.GetComponent<PreguntasCorrectas>();
        
        if (Preguntas == null || Preguntas.Count == 0)
        {
            Preguntas = questions.ToList<Questions>();
        }

        GetRandomQuestion();
        Debug.Log(currentQuestion.Question + " es " + currentQuestion.isTrue);

    }

    void GetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, Preguntas.Count);
        currentQuestion = Preguntas[randomQuestionIndex];

        textoPregunta.text = currentQuestion.Question;

        Preguntas.RemoveAt(randomQuestionIndex);

    }

    IEnumerator TransitionToNextQuestion()
    {
        yield return new WaitForSeconds(timeBetweenQuestions);

        if (Preguntas == null || Preguntas.Count == 0)
        {
            Preguntas = questions.ToList<Questions>();
        }

        GetRandomQuestion();
        Debug.Log(currentQuestion.Question + " es " + currentQuestion.isTrue);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void checkTrue()
    {
        if (currentQuestion.isTrue)
        {
            preguntasCorrectas.sumar();
            Debug.Log("preguntas correctas: " + preguntasCorrectas.CorrectAnswers);
            textoPregunta.text = "Correct";
        }
        else
        {
            Debug.Log("wrong");
            textoPregunta.text = "wrong";
        }

        if (numPreguntas == Preguntas.Count)
        {
            if (preguntasCorrectas.CorrectAnswers >= 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
        else
        {
            StartCoroutine(TransitionToNextQuestion());
        }
        
    }

    public void checkFalse()
    {
        if (!currentQuestion.isTrue)
        {
            preguntasCorrectas.sumar();
            Debug.Log("preguntas correctas: "+ preguntasCorrectas.CorrectAnswers);            
            textoPregunta.text = "Correct";
        }
        else
        {
            Debug.Log("wrong");
            textoPregunta.text = "wrong";
        }

        if (numPreguntas == Preguntas.Count)
        {
            if (preguntasCorrectas.CorrectAnswers >= 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
        else
        {
           
            Debug.Log(numPreguntas);
            StartCoroutine(TransitionToNextQuestion());
        }

    }

}
