using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerGameplay : MonoBehaviour
{
    public HelloARController helloARController;
    
    public GameObject GameTimeUI;
    
    private void Update()
    {
        m_states.m_current.Update();
    }
    #region state management
    private void SM_GoToState(GMGS_GameplayControllerStates newState)
    {
        m_states.m_current.Exit();
        m_states.m_current = newState;
        m_states.m_current.Enter();
    }

    public void SMG_GoToInactive()
    {
        SM_GoToState(m_states.m_inactive);
    }
    public void SMG_GoToInitGame()
    {
        SM_GoToState(m_states.m_initGame);
    }
    public void SMG_GoToPlaying()
    {
        SM_GoToState(m_states.m_playing);
    }
    #endregion
    private void Awake()
    {


        m_states.m_inactive = ScriptableObject.CreateInstance<GMGS_Inactive>().Init(this) as GMGS_Inactive;
        m_states.m_initGame = ScriptableObject.CreateInstance<GMGS_InitGame>().Init(this) as GMGS_InitGame;
        m_states.m_playing = ScriptableObject.CreateInstance<GMGS_Playing>().Init(this) as GMGS_Playing;
        m_states.m_current = m_states.m_inactive;
        SMG_GoToInactive();
    }



    [SerializeField]
    public GameManagerGameplayStates m_states;

    [System.Serializable]
    public class GameManagerGameplayStates
    {
        public GMGS_GameplayControllerStates m_current;
        
        public GMGS_Inactive m_inactive;
        public GMGS_InitGame m_initGame;
        public GMGS_Playing m_playing;


    }
}
