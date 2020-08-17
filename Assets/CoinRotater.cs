using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotater : MonoBehaviour
{
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
       
        transform.Rotate(new Vector3(GetComponent<Transform>().transform.rotation.x, GetComponent<Transform>().transform.rotation.y, 30) * Time.deltaTime);
    }
}
