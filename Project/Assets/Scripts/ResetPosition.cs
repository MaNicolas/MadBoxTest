using UnityEngine;

public class ResetPosition : MonoBehaviour
{
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