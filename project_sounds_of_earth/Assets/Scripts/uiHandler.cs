using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using System.IO;

public class uiHandler : MonoBehaviour
{
    gameManager gameManager;
    selectCountries _selectCountries;
    CameraMovement cameraMovement;
    countryFinder countryFinder;

    public GameObject StartScreen;
    public GameObject playModeUi;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
        _selectCountries = GameObject.Find("CountryMarkers").GetComponent<selectCountries>();
        cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager._isGameActive)
        {

        }
        
    }

    public void AnswerButton_Click(Button button)
    {
        if (button.GetComponentInChildren<TMP_Text>().text == gameManager.rightAnswer)
        { 
            Debug.Log("Do�ru cevap");
            gameManager.increasePlayerScore(gameManager.questionTimerRemainder); //kalan zaman filan eklenecek.
            gameManager.increaseOrResetChain(true);
            gameManager.calculateScoreMultiplier();
            // gameManager.nextQuestionButton.gameObject.SetActive(true);

        }
        else
        {
            Debug.Log("Yanl�� Cevap!");
            gameManager.increasePlayerScore(0);
            gameManager.increaseOrResetChain(false);
            gameManager.calculateScoreMultiplier();
 
        }

        //burada yanl�� cevap, do�ru cevap animasyonlar� devreye girecek. Askphase a��ld�ktan sonra biraz couroutine ile s�re tan�nabilir ��nk� oyun donma yap�yor.
        //Bu da mp3 indirme s�reci ile ilgili olsa gere. Genel oalrak d�zeltilecek. 
        gameManager.goToNextQuestion();
      
        
    }

    
    public void StartTheGame()
    {
        gameManager._isGameActive = true;
        _selectCountries.inSelectionPhase = true;
        StartScreen.SetActive(false);
        playModeUi.SetActive(true);
    }

    public void ExitPlayMode()
    {
        _selectCountries.disableMeshAndScriptForSelected();
        gameManager._isGameActive = false;
        StartScreen.SetActive(true);
        playModeUi.SetActive(false);
        gameManager.ResetAlltoInitialCondition();
        
    }

    public void NextQuestion()
    {
        _selectCountries.disableMeshAndScriptForSelected();
        cameraMovement.randomIdleNumbersSet = false;
        cameraMovement.setToQuestionPosition = false;
        _selectCountries.inSelectionPhase = true;
      

    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}

