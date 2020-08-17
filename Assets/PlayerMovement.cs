using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 Move;
    private Transform camTransform;

    public GameObject Player;
    private Vector3 startPos;
    private Rigidbody rb;
    public float speed;
    public float push;

    // Start is called before the first frame update
    void Start()
    {
        
        startPos = Player.transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("A"))
        //{
        //    rb.AddForce(0, 0, -push * 100);
        //}
        //if (Input.GetButtonDown("Y"))
        //{
        //    rb.AddForce(0, 0, push * 75);
        //}
        Move = PoolInput();

        Move = RotateWithView();

        MoveVector();

        if (Input.GetButtonDown("B"))
        {
            Player.transform.position = startPos;
            Debug.Log("restart");
        }

        
                
    }

    private void FixedUpdate()
    {
        
    }

    private Vector3 RotateWithView()
    {
        if (camTransform != null)
        {
            Vector3 dir = camTransform.TransformDirection(Move);
            dir.Set(dir.x, 0, dir.z);
            return dir.normalized * Move.magnitude;
        }
        else
        {
            camTransform = Camera.main.transform;
            return Move;
        }

    }

    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis("JoystickHorizontal");
        dir.z = Input.GetAxis("JoystickVertical");
        
        if (dir.magnitude > 1)
        {
            dir.Normalize();
        }
        return dir;
    }

    private void MoveVector()
    {
        
        rb.AddForce(Move * speed * 100);
        
    }
    
 }

