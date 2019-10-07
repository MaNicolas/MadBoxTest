using UnityEngine;

public class ArrivalScript : MonoBehaviour
{
    public GameManager m_gameManager;

    private void Awake()
    {
        m_gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
    }

    private void OnTriggerEnter( Collider other )
    {
        m_gameManager.m_endScreen.gameObject.SetActive( true );

        if( other.CompareTag( "Player" ) )
        {
            Debug.Log( "You win" );
            m_gameManager.m_winLoseText.color = Color.green;
            m_gameManager.m_winLoseText.text = "You Win";
            m_gameManager.m_CountDownUI.gameObject.SetActive( false );
        }
        else if( other.CompareTag( "AI" ) )
        {
            Debug.Log( "You lose" );
            m_gameManager.m_winLoseText.color = Color.green;
            m_gameManager.m_winLoseText.text = "You Lose";
            m_gameManager.m_CountDownUI.gameObject.SetActive( false );
        }
    }
}