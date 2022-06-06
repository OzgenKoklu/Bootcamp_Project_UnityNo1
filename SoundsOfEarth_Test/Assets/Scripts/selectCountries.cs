using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class selectCountries : MonoBehaviour
{
    countryFinder _countryfinder;
    gameManager gameManager;
    public bool inSelectionPhase = true;
    string selectedCountryName = null;
    string country1name = null;
    string country2name = null;
    string country3name = null;
    public float magnitudeOfcombinationVector = 0;
    private string tempCountry;
    int radiusOfEarth = 20;
    Vector3 countryVector1 = new Vector3(0, 0, 0);
    Vector3 countryVector2 = new Vector3(0, 0, 0);
    Vector3 countryVector3 = new Vector3(0, 0, 0);
    Vector3 countryVector4 = new Vector3(0, 0, 0);
    public Vector3 middleVector = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        _countryfinder = GameObject.FindGameObjectWithTag("countryFinder").GetComponent<countryFinder>();
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager._isGameActive && inSelectionPhase)
        {
           
            changeSelectedCountryName();
            //showCountryList();
            if (_countryfinder.countryList.Count <= 4)
                SetCountryFinderLocation();
            
               
            if (_countryfinder.countryList.Count > 4)
            {
                selectRemainingCountries();
                enableMeshAndScriptForSelected();
                findMiddleVector();
                inSelectionPhase = false;
            }
            
            
        }
       // showCountryList();
    }

    //bu iki fonksiyon birle�tirilip bir for d�ng�s� ve selected country arrayi ile 2-3 sat�ra kadar indirilebilir ama �imdilik b�yle b�rakt�m. 
    void enableMeshAndScriptForSelected()
    {
        transform.Find((string)selectedCountryName).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)country1name).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)country2name).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)country3name).GetComponent<MeshRenderer>().enabled = true;
        transform.Find((string)selectedCountryName).GetComponent<countryMarkerBehaviour>().enabled = true;
        transform.Find((string)country1name).GetComponent<countryMarkerBehaviour>().enabled = true;
        transform.Find((string)country2name).GetComponent<countryMarkerBehaviour>().enabled = true;
        transform.Find((string)country3name).GetComponent<countryMarkerBehaviour>().enabled = true;
    }

    public void disableMeshAndScriptForSelected()
    {
        transform.Find((string)selectedCountryName).GetComponent<MeshRenderer>().enabled = false;
        transform.Find((string)country1name).GetComponent<MeshRenderer>().enabled = false;
        transform.Find((string)country2name).GetComponent<MeshRenderer>().enabled = false;
        transform.Find((string)country3name).GetComponent<MeshRenderer>().enabled = false;
        transform.Find((string)selectedCountryName).GetComponent<countryMarkerBehaviour>().enabled = false;
        transform.Find((string)country1name).GetComponent<countryMarkerBehaviour>().enabled = false;
        transform.Find((string)country2name).GetComponent<countryMarkerBehaviour>().enabled = false;
        transform.Find((string)country3name).GetComponent<countryMarkerBehaviour>().enabled = false;
    }

    void findMiddleVector()
    {
        countryVector2 = transform.Find((string)country1name).GetComponent<Transform>().position;
        countryVector3 = transform.Find((string)country2name).GetComponent<Transform>().position;
        countryVector4 = transform.Find((string)country3name).GetComponent<Transform>().position;
        magnitudeOfcombinationVector = (countryVector1 + countryVector2 + countryVector3 + countryVector4).magnitude; //for camera distance calculation
        // Debug.Log("magnitude of combination vector: " + magnitudeOfcombinationVector);
        middleVector = (countryVector1 + countryVector2 + countryVector3 + countryVector4).normalized * radiusOfEarth;
        
        // Debug.Log(middleVector);
    }

    void changeSelectedCountryName()
    {  
            selectedCountryName = "Germany"; // Normalde bu metod i�inde ba�ka bir scriptten gelecek se�ilmi� �lke verisine e�lenecek;
            countryVector1 = transform.Find((string)selectedCountryName).GetComponent<Transform>().position;   
    }

    void SetCountryFinderLocation()
    {
        if (Random.Range(1, 3) % 2 == 0)
        {
            _countryfinder.transform.position = countryVector1 + new Vector3(Random.Range(2, 5), Random.Range(2, 10), Random.Range(2, 5));

        }
        else
        {
            _countryfinder.transform.position = countryVector1 + new Vector3(Random.Range(-5, -2), Random.Range(-10, -2), Random.Range(-5, -2));
        }
        // Debug.Log("CountryFinderLOc: " + _countryfinder.transform.position);
        
    }

   
    void selectRemainingCountries()
    {
       
            _countryfinder.countryList.Remove(selectedCountryName);
            ShuffleCountryList();
            country1name = (string)_countryfinder.countryList[1];
            country2name = (string)_countryfinder.countryList[2];
            country3name = (string)_countryfinder.countryList[3];

        //Debug.Log("Country1: " + country1name + " Country2: " + country2name + " Country3 : " + country3name);

    }

    public void ShuffleCountryList()
    {
        for (int i = 0; i < _countryfinder.countryList.Count; i++)
        {
            int rnd = Random.Range(0, _countryfinder.countryList.Count);
            tempCountry = (string)_countryfinder.countryList[rnd];
            _countryfinder.countryList[rnd] = _countryfinder.countryList[i];
            _countryfinder.countryList[i] = tempCountry;
        }
    }

    //tamamen debug ama�lar�yla yapt���m bir fonksiyon. Di�er scriptten ald���m veriyi do�ru ald�m m� kontrol etmek i�in yazd�r�yorum.
    void showCountryList()
    {
            foreach (string value in _countryfinder.countryList)
            {
                print(value);
            }
    }
}
