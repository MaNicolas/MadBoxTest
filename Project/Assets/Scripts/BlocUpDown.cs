using UnityEngine;

public class BlocUpDown : MonoBehaviour
{
    public float m_enemySpeed;
    public Vector3 m_offsetEndPos;

    private Vector3 _startPos;
    private Vector3 _targetPos;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();

        _startPos = _transform.position;
        _targetPos = _startPos + m_offsetEndPos;
    }

    private void Update()
    {
        _transform.position = Vector3.MoveTowards( _transform.position, _targetPos, m_enemySpeed * Time.deltaTime );

        if( _transform.position == _targetPos )
        {
            if( _targetPos == _startPos )
                _targetPos = _startPos + m_offsetEndPos;
            else if( _targetPos == _startPos + m_offsetEndPos )
                _targetPos = _startPos;
        }
    }

    private void OnTriggerEnter( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            other.transform.position = other.GetComponent<PlayerMovement>().m_startPosition.position;
        }
        else if( other.CompareTag( "AI" ) )
        {
            other.transform.position = other.GetComponent<AiMovement>().m_startPosition.position;
        }
    }
}