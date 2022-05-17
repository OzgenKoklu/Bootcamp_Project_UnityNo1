using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private int interPolationFramesCount = 90;
    int elapsedFrames = 0;
    Vector3 endPosition = new Vector3(0, 0, 0);

    Vector3 cameraOffsetVector = new Vector3(35, 10, 0);
    selectCountries _selectCountries;
    // Start is called before the first frame update
    void Start()
    {
        _selectCountries = GameObject.Find("CountryMarkers").GetComponent<selectCountries>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        changeCameraPosition();
    }



    void changeCameraPosition()
    {
        endPosition = _selectCountries.middleVector + cameraOffsetVector; //asl�nda bu camera offset her zaman i�e yaramaz ��nk� d�nyan�n arkas�na girdi�imizde + 25,10,0 muhtemelen d�nyan�n i�ine girmesine sebep olur.
                                                                          //Offseti de conditional yapaca��m. Prototipleme i�in bu
        if (transform.position != endPosition)
        {
            float lerpInterpolationRatio = (float)elapsedFrames / interPolationFramesCount;
            transform.position = Vector3.Lerp(transform.position, endPosition, Mathf.SmoothStep(0.0f, 1.0f, lerpInterpolationRatio));
            elapsedFrames = (elapsedFrames + 1) % (interPolationFramesCount + 1);
        }
    }


    void idleCameraMovement()
    {

    }
}
