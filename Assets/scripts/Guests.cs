using UnityEngine;
using UnityEngine.AI;

public class Guests : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject[] magazine;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        magazine = GameObject.FindGameObjectsWithTag("magazine");
    }

    void Update()
    {
        if (magazine != null)
        {
            int n = Random.Range(0,magazine.Length);
            agent.SetDestination(magazine[n].transform.position);
        }
    }
}
