using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class brujula : MonoBehaviour
{
    public TMP_Text texto;
    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
        Input.gyro.enabled = true;
        Input.compass.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {


        Debug.Log("Brujula: " + Input.compass.trueHeading);
        Debug.Log("Aceleración " + Input.acceleration);
        Debug.Log(Input.location.status);
        Debug.Log("Latitud: " + Input.location.lastData.latitude + " Longitud: " + Input.location.lastData.longitude + " Altitud: " + Input.location.lastData.altitude);
        Debug.Log("Velocidad angular: " + Input.gyro.rotationRate);

        texto.text = $"Brujula: {Input.compass.trueHeading} \n Aceleración: {Input.acceleration} \n Latitud {Input.location.lastData.latitude} \n Longitud {Input.location.lastData.longitude} \n Altitud {Input.location.lastData.altitude} \n Velocidad Angular {Input.gyro.rotationRate}";
        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -Input.compass.trueHeading, 0), 0.5f);
    }
}
