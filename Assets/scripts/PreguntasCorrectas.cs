using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreguntasCorrectas : MonoBehaviour
{
    public int CorrectAnswers = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        CorrectAnswers = 0;
    }

    public void sumar()
    {
        CorrectAnswers = CorrectAnswers + 1;
    }

}
