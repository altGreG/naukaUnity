using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereControler : MonoBehaviour // Dziedziczenie po klasie MonoBehaviour, tam są metody które używamy np. transform
{
    // [HideInInspector]
    // public float speed = 2f; // zmienne publiczne można edytować z poziomu edytora unity
    
    [Header("Control Settings")]
    [SerializeField]
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
        Debug.Log(transform.rotation.eulerAngles);
        Debug.Log(transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {
        float direction;
        Debug.Log(Input.GetAxis("Horizontal"));

        if((direction = Input.GetAxis("Horizontal")) != 0) // pobiera oś z ustaloną w input managerze
        { 
            Debug.Log("Klikamy strzałki!");
        } 

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-1f * Time.deltaTime * speed,0, 0, Space.World); // Space.World po zrotowaniu dalej będzie szła kula w lewo
        }
        
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(1f * Time.deltaTime * speed,0, 0, Space.World); // translacja nie niweluje pędu, to jak teleportacja xD
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0,0, 1f * Time.deltaTime * speed, Space.World); 
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0,0, -1f * Time.deltaTime * speed, Space.World); 
        }
    }
}
