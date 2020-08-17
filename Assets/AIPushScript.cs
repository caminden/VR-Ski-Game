using UnityEngine;
using UnityEngine.AI;


public class AIPushScript : MonoBehaviour
{
    public NavMeshAgent player;
    public GameObject end;
    private Vector3 Ending;
    private Vector3 start;
    public GameObject[] coins;
    public int i;
    public int CL;
    private int n, s;

    // Start is called before the first frame update
    void Start()
    {
        Ending = end.transform.position;
        start = player.transform.position;
        n = Random.Range(0, 3);
        switch (n){
            case 0: coins = GameObject.FindGameObjectsWithTag("Pick Up"); break;
            case 1: coins = GameObject.FindGameObjectsWithTag("Pick Up 1"); break;
            case 2: coins = GameObject.FindGameObjectsWithTag("Pick Up 2"); break;
            case 3: coins = GameObject.FindGameObjectsWithTag("Pick Up 3"); break;
            default: coins = GameObject.FindGameObjectsWithTag("Pick Up"); break;
        }
        i = 0;
        CL = coins.Length;
        s = Random.Range(23, 26);
        GetComponent<NavMeshAgent>().speed = s;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Y"))
        {
            player.SetDestination(coins[i].GetComponent<Transform>().position);
        }
        if (Input.GetButton("B"))
        {
            i = 0;
            player.SetDestination(start);
        }

        if (coins[i].activeSelf == false || player.transform.position.z < coins[i].transform.position.z)
        {
           i++;
           player.SetDestination(coins[i].GetComponent<Transform>().position);
        }

        if(i >= CL-1 || player.transform.position.z < coins[CL-1].transform.position.z)
        {
            player.SetDestination(Ending);

        }

       

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up") || other.gameObject.CompareTag("Pick Up 1") || other.gameObject.CompareTag("Pick Up 2") || other.gameObject.CompareTag("Pick Up 3"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
