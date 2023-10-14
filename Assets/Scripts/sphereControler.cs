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
    public float maxAngularVelocity;

    private Rigidbody rb;
    private bool isRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        if(isRigidBody = TryGetComponent<Rigidbody>(out rb)){
            rb.maxAngularVelocity = maxAngularVelocity;
            Debug.Log(rb.maxAngularVelocity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float Hdirection;
        float Vdirection;


        if(isRigidBody){
            if((Hdirection = Input.GetAxis("Horizontal")) != 0 && (Vdirection = Input.GetAxis("Vertical")) != 0){
                rb.AddTorque(0,0,-Hdirection * Time.deltaTime * speed);
                rb.AddTorque(Vdirection * Time.deltaTime * speed,0,0);
            }
            else if((Hdirection = Input.GetAxis("Horizontal")) != 0) // pobiera oś ustaloną w input managerze
            { 
            
                // rb.AddForce(direction * Time.deltaTime * speed,0, 0);
                rb.AddTorque(0,0,-Hdirection * Time.deltaTime * speed);
            } 
            else if((Vdirection = Input.GetAxis("Vertical")) != 0)
            { 
                // rb.AddForce(0,0, direction * Time.deltaTime * speed);
                rb.AddTorque(Vdirection * Time.deltaTime * speed,0,0);
            }
        }
    }
}
