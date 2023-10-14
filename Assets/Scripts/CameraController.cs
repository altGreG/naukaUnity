using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // public Transform ballTransform; - pobranie samej wartości transform obiektu, który dodamy w inspektorze
    public GameObject ballObject; // pobranie całego obiektu
    public Vector3 distance; // oddalenie kamery
    public float LookUp;
    public float lerpAmount;

    float timer = 5f;

    int updateCounter;
    int fixedUpdateCounter;

    // Start is called before the first frame update
    void Start()
    {
        
        // uruchomienie synchronizacji pionowej, tyle klatek ile zdoła obsłużyć monitor
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if(timer <= 0f){
            // Debug.Log($"Update: {updateCounter / 5}");
            // Debug.Log($"FixedUpdate: {fixedUpdateCounter / 5}");
            // Debug.LogError("End");
        }
        updateCounter ++; 
    }

    private void FixedUpdate(){ // wykonuje się co dany ułamek sekundy, tu powinno się wykonywać fizyke
         transform.position = Vector3.Lerp(transform.position,ballObject.transform.position + distance, lerpAmount);
        // transform.position = ballObject.transform.position + distance;
        transform.LookAt(ballObject.transform.position); // fizyka jest obliczna w pewnym interwale, co jakiś czas a nie co klatkę
        transform.Rotate(-LookUp,0,0);
        fixedUpdateCounter ++;
    }

}
