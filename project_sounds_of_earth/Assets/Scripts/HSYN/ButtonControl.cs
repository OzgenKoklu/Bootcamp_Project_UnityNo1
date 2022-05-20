using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;


public class ButtonControl : MonoBehaviour
{

    public GameObject button;
    public GameObject canvas;
    public int countrynumber;
    public GameObject EarthModel;
    public GameObject GameObjectlereErisim;
    GameObject[] ulkeler;
    int i;
    
    string ulke;



    public ArrayList countryler = new ArrayList();

    public void Start()
    {

        EarthModel = this.gameObject;
        GameObject newCanvas = Instantiate(canvas) as GameObject;
        GameObject newButton = Instantiate(button) as GameObject;
        newButton.transform.SetParent(newCanvas.transform, true);
        ulkeler = GameObjectlereErisim.GetComponent<GameObjectlereErisim>().country;
        countryler.Add(ulkeler);
    }

    public void Update()
    {
    
    }

    public void OnButtonClick()
    {

        countrynumber = Random.Range(0, 250);// if the answer eithr true or false, produce a random number. if answer is true, we use this number in if parantezleri, if answer is false the we use this number in else parantezleri.

        if (button.transform.Find("Text").GetComponent<Text>().text=="Germany".ToUpper())
        {

            //foreach(string ulke in)
            //{
                Debug.Log(countryler);
                
            //}
            //Debug.Log(((Countries)Countries.TR).AsString(EnumFormat.Description));//in this line, we should read a new country and the old txrt should be disappeared
        }
        else
        {
            Debug.Log("s");//in this line, we should read a new country and the old txrt should be disappeared
            Debug.Log("You have the wrong answeer");
        }
    }
}


/*Butona bas�ld���nda cevab�n do�ru mu yanl�� m� oldu�unu s�yleyen script yaz�ld�. 4 buton i�inden biri do�ru cevap olacak, bu do�ru cevap olan �lkenin m�zi�i �ekilecek ses olarak ve 
 bu �lke ��klardan birine random olarak atanacak.(button .text=sdlkghslg) gbii. bu atama yap�ld�ktan sonra 250 �lke i�erisinden random 3 �lke se�ilip kalan 3 butona atanacak text olarak.
ve her se�im yap�ld���nda do�ru cevap gibi bir geri d�n�� yap�l�p butnlara yeni atama yap�lacak ve yeni �lkenin m�zipi ayn� �ekilde �ekilecek 
*/