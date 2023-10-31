using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour 
{
    [Header("Component")]
    public Rigidbody rb;
    public PlayerInput input;
    [HideInInspector] public InputAction moveAction, AimAction;
    Vector3 direction;
    [Header("Move Info")]
    public float currentSpeed;
   
    [Header("Bullet Info")]
   public Transform FirePoint;


    private void Awake()
    {
        moveAction = input.actions["Movement"];
        AimAction = input.actions["Aim"];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, direction, Color.red);
        // rb.MovePosition(direction * currentSpeed * Time.deltaTime);

        // permet de faire une rotation selon mon axis avec le forward 
        /*  if (direction != Vector3.zero)
          {
              gameObject.transform.forward = direction;
          }*/


        if (direction.magnitude != 0)
        {
            Quaternion q = Quaternion.LookRotation(direction);
            rb.MoveRotation(q);
            ;
        }


        // rb.MovePosition(transform.position + currentSpeed  * Time.deltaTime * direction);
        rb.velocity = direction * currentSpeed * Time.deltaTime * 50;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = moveAction.ReadValue<Vector2>(); 

        direction = new Vector3 (movement.x , 0,movement.y);
        direction = direction.normalized;

        
       
    }

   
}
