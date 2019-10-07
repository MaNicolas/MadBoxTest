using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public NavMeshAgent m_navMeshAgent;
    
    public float m_speed;

    public Transform m_arrivalPoint;
    public Transform m_startPosition;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            m_navMeshAgent.isStopped = false;
            m_navMeshAgent.SetDestination( m_arrivalPoint.position );
        }
        else
        {
            m_navMeshAgent.isStopped = true;
        }
    }
}