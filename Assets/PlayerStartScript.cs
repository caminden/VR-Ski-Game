using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStartScript : MonoBehaviour
{
    public GameObject player;
    public GameObject startPlat;
    private Vector3 start;
    private Rigidbody rb;
    public float time;
    private bool g;
    // Start is called before the first frame update
    void Start()
    {
        start = player.transform.position;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        time = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position == start && Input.GetButtonDown("Y"))
        {
            time = 0;
            g = true;
            startPlat.SetActive(false);
            rb.constraints = unchecked(RigidbodyConstraints.FreezePositionX);
        }
        else if (time > 1)
        {
            rb.constraints = unchecked(RigidbodyConstraints.FreezeRotation);
        }
        if (Input.GetButtonDown("B"))
        {
            startPlat.SetActive(true);
            rb.constraints = RigidbodyConstraints.FreezeAll;
            player.transform.position = start;
            Debug.Log("restart");
            g = false;
            time = 0;
        }
          
    }
    void FixedUpdate()
    {
        if (g == true)
        {
            time += Time.deltaTime;
        }
    }

}
