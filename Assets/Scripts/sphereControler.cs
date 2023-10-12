using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereControler : MonoBehaviour // Dziedziczenie po klasie MonoBehaviour, tam są metody które używamy np. transform
{

    public float speed = 2f; // zmienne publiczne można edytować z poziomu edytora unity

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
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position = new Vector3(transform.position.x-1f * Time.deltaTime * speed, transform.position.y, transform.position.z); - słabe rozw. 
            transform.Translate(-1f * Time.deltaTime * speed,0, 0, Space.World); // Space.World po zrotowaniu dalej będzie szła kula w lewo
        }
        
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(1f * Time.deltaTime * speed,0, 0, Space.World); // translacja nie niweluje pędu, to jak teleportacja xD
        }
    }
}
