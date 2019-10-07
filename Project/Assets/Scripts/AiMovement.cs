using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    public NavMeshAgent m_navMeshAgent;

    public float m_speed;

    public Transform m_arrivalPoint;
    public Transform m_startPosition;

    private Transform _transform;

    public Vector3 m_Offset;

    private bool _aiCanMove;

    void CastRay()
    {
        Ray ray = new Ray(_transform.position + new Vector3(0f, 0.5f, 0f), Vector3.forward);
        Debug.DrawRay( _transform.position + new Vector3( 0f, 0.5f, 0f ), Vector3.forward, Color.magenta );

        bool cast = Physics.Raycast(ray, 1f);

        if( cast )
        {
            _aiCanMove = false;
        }
        else
        {
            _aiCanMove = true;
        } 
    }

    public void Awake()
    {
        //Get Transform component
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        CastRay();

        if( _aiCanMove )
        {
            m_navMeshAgent.isStopped = false;
            m_navMeshAgent.SetDestination( m_arrivalPoint.position );
        }
        else
            m_navMeshAgent.isStopped = true;
    }
}