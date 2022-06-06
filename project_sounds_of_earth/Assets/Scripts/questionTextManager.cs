using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questionTextManager : MonoBehaviour
{
    gameManager gameManager;

    [SerializeField] Text questionLatinText;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    void Update()
    {
        SetNewQuestionText();
    }
    /// <summary>
    /// Normalde bu scriptte ekran �st�ne yazd�r�lan textlerin tamam�n�n kontrol� planlanm��t�.
    /// �rne�in sorudan �nce gelen bi countdown texti de bu script de�i�tirecekti. Ama develpment s�ras�nda i�levsiz kald�
    /// </summary>
    void SetNewQuestionText()
    {
        if(gameManager.questionResult != null && gameManager.gotAnswerFromApi == true)
        {
            questionLatinText.text = "Text: " + gameManager.questionResult[4];
        }
             
    }

}
