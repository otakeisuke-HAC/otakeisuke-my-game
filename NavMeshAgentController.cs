using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentController : MonoBehaviour
{
    public Transform[] m_PatrolPoints;
    private int m_CurrentPatrolPointIndex = -1;
    NavMeshAgent m_NavMeshAgent;
    // Start is called before the first frame update
    void Start()
    {       
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        SetNewPatrolPointToDestination();
        //for(int i = 0; i < m_PatrolPoints.Length; i++)
        //{
        //    m_PatrolPoints[i] = GameObject.Find("PatrolPoint(" + i + ")").transform;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (HasArrived())
        {
            SetNewPatrolPointToDestination();
        }
    }

    void SetNewPatrolPointToDestination()
    {
        m_CurrentPatrolPointIndex += 1;

        if(m_CurrentPatrolPointIndex >= m_PatrolPoints.Length)
        {
            m_CurrentPatrolPointIndex += 1;
        }

        m_NavMeshAgent.destination = m_PatrolPoints[m_CurrentPatrolPointIndex].position;
    }

    //“ž’…‚µ‚½‚©?
    bool HasArrived()
    {
        return Vector3.Distance(m_NavMeshAgent.destination, transform.position) < 0.5f;
    }
}
