using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PopMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Pop pop;
    public float baseSpeed = 4.0f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pop = GetComponent<Pop>();

        PatrolHomeWork();
    }

    private void Update()
    {
        UpdateSpeed();

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    PatrolHomeWork();
                }
            }
        }
    }

    private void UpdateSpeed()
    {
        if (NavMesh.SamplePosition(transform.position, out NavMeshHit navHit, 1f, NavMesh.AllAreas))
        {
            int mask1 = navHit.mask;
            int index = 0;

            while ((mask1 >>= 1) > 0)
            {
                index++;
            }
            float areaCost = NavMesh.GetAreaCost(index);
            agent.speed = baseSpeed / areaCost;
        }
    }

    void PatrolHomeWork()
    {
        if (pop.Home == null || pop.Work == null) return;

        float homeDist = (transform.position - pop.Home.door.position).sqrMagnitude;
        float workDist = (transform.position - pop.Work.door.position).sqrMagnitude;

        if (homeDist > workDist)
        {
            agent.SetDestination(pop.Home.door.position);
        }
        else
        {
            agent.SetDestination(pop.Work.door.position);
        }
    }
}
