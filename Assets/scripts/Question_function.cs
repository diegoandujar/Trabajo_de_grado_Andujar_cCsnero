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
    
    [SerializeField] AudioSource correctSound;
    [SerializeField] AudioSource errorSound;

    private GameObject verdad;
    private GameObject falso;

    // Start is called before the first frame update
    void Start()
    {
        verdad = GameObject.Find("True");
        falso = GameObject.Find("False");
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
        verdad.SetActive(false);
        falso.SetActive(false);
        yield return new WaitForSeconds(timeBetweenQuestions);

        if (Preguntas == null || Preguntas.Count == 0)
        {
            Preguntas = questions.ToList<Questions>();
        }

        GetRandomQuestion();
        Debug.Log(currentQuestion.Question + " es " + currentQuestion.isTrue);

        verdad.SetActive(true);
        falso.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    IEnumerator wait()
    {

        textoPregunta.text = "preguntas correctas: " + preguntasCorrectas.CorrectAnswers + "/3";

        yield return new WaitForSeconds(timeBetweenQuestions);

        if (preguntasCorrectas.CorrectAnswers >= 2)
        {
            textoPregunta.text = "Pasaste de nivel !!!";
        }
        else
        {
            textoPregunta.text = "No pasaste de nivel !!!";
        }

        yield return new WaitForSeconds(timeBetweenQuestions);


        if (preguntasCorrectas.CorrectAnswers >= 2)
        {
            //textoPregunta.text = "epale";
            //correctSound.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            //errorSound.Play();
            //textoPregunta.text = "hola";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }


    public void check()
    {
        if (numPreguntas == Preguntas.Count)
        {

            StartCoroutine(wait());
            
        }
        else
        {
            StartCoroutine(TransitionToNextQuestion());
        }
    }

    public void checkTrue()
    {

        /*if (numPreguntas == Preguntas.Count)
        {
            textoPregunta.text = "preguntas correctas: " + preguntasCorrectas.CorrectAnswers;
            new WaitForSeconds(timeBetweenQuestions);
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
        }*/

        if (currentQuestion.isTrue)
        {
            correctSound.Play();
            preguntasCorrectas.sumar();
            Debug.Log("preguntas correctas: " + preguntasCorrectas.CorrectAnswers);
            textoPregunta.text = "Correcto";
        }
        else
        {
            errorSound.Play();
            Debug.Log("wrong");
            textoPregunta.text = "Error";
        }

        new WaitForSeconds(timeBetweenQuestions);
        check();

    }

    public void checkFalse()
    {

        /*if (numPreguntas == Preguntas.Count)
        {
            textoPregunta.text = "preguntas correctas: " + preguntasCorrectas.CorrectAnswers;
            new WaitForSeconds(timeBetweenQuestions);
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
        }*/

        if (!currentQuestion.isTrue)
        {
            correctSound.Play();
            preguntasCorrectas.sumar();
            Debug.Log("preguntas correctas: "+ preguntasCorrectas.CorrectAnswers);            
            textoPregunta.text = "Correcto";
        }
        else
        {
            errorSound.Play();
            Debug.Log("wrong");
            textoPregunta.text = "Error";
        }

        new WaitForSeconds(timeBetweenQuestions);
        check();

    }

}
