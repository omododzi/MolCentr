using UnityEngine;
using UnityEngine.AI;

public class Guests : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject[] magazinepoints;
    private bool goinmagaz = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        magazinepoints = GameObject.FindGameObjectsWithTag("magazine");
    }

    void Update()
    {
        if (magazinepoints != null)
        {
            if (!goinmagaz)
            {
                Gomagaz();
            }

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                goinmagaz = false;
            }
        }
    }

    void Gomagaz()
    {
        goinmagaz = true;
        int n = Random.Range(0,magazinepoints.Length);
        agent.SetDestination(magazinepoints[n].transform.position);
    }
}
