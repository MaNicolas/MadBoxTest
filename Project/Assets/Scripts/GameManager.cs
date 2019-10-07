using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject m_endScreen;
    public GameObject m_CountDownUI;

    public float m_Timer = 60;
    public TextMeshProUGUI m_CountDownText;
    public TextMeshProUGUI m_winLoseText;

    private bool _TimerIsOn;


    private void Start()
    {
        m_endScreen.gameObject.SetActive( false );
        _TimerIsOn = true;
        Time.timeScale = 1f;
        m_CountDownUI.gameObject.SetActive( true );
    }
    public void OnRestartButton()
    {
        SceneManager.LoadScene( "MainScene" );
    }

    public void OnNextButton()
    {
        Debug.Log( "This would lead players to the next level, providing they successfully completed the current one" );
        SceneManager.LoadScene( "MainScene" );
    }

    private void Update()
    {
        
        if( _TimerIsOn && m_Timer >= 0f)
        {
            m_Timer -= Time.deltaTime;
            m_CountDownText.text = m_Timer.ToString("F");
        }

        else if (m_Timer < 0.1f)
        {
            _TimerIsOn = false;
            m_Timer = Mathf.Clamp( m_Timer, 0f, m_Timer );

            m_CountDownText.text = m_Timer.ToString( "0.00" );
            m_Timer = 0.0f;
            m_CountDownUI.gameObject.SetActive( false );

            m_winLoseText.color = Color.red;
            m_winLoseText.text = "You Lose";
            
            Time.timeScale = 0f;

            m_endScreen.gameObject.SetActive( true );
        }
    }
}