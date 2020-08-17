using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    public Text countText;
    private int count;
    public GameObject[] coins;
    public GameObject[] coins1;
    public GameObject[] coins2;
    public GameObject[] coins3;
    public GameObject[] coins4;


    void Start()
    {
        count = 0;
        SetCountText();
        coins = GameObject.FindGameObjectsWithTag("Pick Up");
        coins1 = GameObject.FindGameObjectsWithTag("Pick Up 1");
        coins2 = GameObject.FindGameObjectsWithTag("Pick Up 2");
        coins3 = GameObject.FindGameObjectsWithTag("Pick Up 3");
        coins4 = GameObject.FindGameObjectsWithTag("Pick Up 4");

    }


    void Update()
    {

        if (Input.GetButtonDown("B"))
        {
            for(int i = 0; i < coins.Length; i++)
            {
                coins[i].SetActive(true);
                coins1[i].SetActive(true);
                coins2[i].SetActive(true);
                coins3[i].SetActive(true);
                coins4[i].SetActive(true);
            }
            count = 0;
            SetCountText();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up") || other.gameObject.CompareTag("Pick Up 1") || other.gameObject.CompareTag("Pick Up 2") || other.gameObject.CompareTag("Pick Up 3") || other.gameObject.CompareTag("Pick Up 4"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

    }

}
