using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndyAgent : MonoBehaviour
{
    public HelloARController principalARController;
    public GameManagerPlaying gameManagerPlaying;
    public int id_pos; 

    private void Update()
    {
        m_states.m_current.Update();
    }
    #region state management
    private void SM_GoToState(AD_AndyControllerState newState)
    {
        m_states.m_current.Exit();
        m_states.m_current = newState;
        m_states.m_current.Enter();
    }

    public void SM_GoToWaiting()
    {
        SM_GoToState(m_states.m_waiting);
    }
    public void SM_GoToInactive()
    {
        SM_GoToState(m_states.m_inactive);
    }
    public void SM_GoToDeath()
    {
        SM_GoToState(m_states.m_death);
    }

    #endregion

    private void Awake()
    {
        m_states.m_waiting = ScriptableObject.CreateInstance<AD_Waiting>().Init(this) as AD_Waiting;
        m_states.m_inactive = ScriptableObject.CreateInstance<AD_Inactive>().Init(this) as AD_Inactive;
        m_states.m_death = ScriptableObject.CreateInstance<AD_Death>().Init(this) as AD_Death;
        m_states.m_current = m_states.m_waiting;

        SM_GoToWaiting();
    }

    [SerializeField]
    ADControllerStates m_states;

    [Serializable]
    public class ADControllerStates
    {
        public AD_AndyControllerState m_current;

        public AD_Waiting m_waiting;
        public AD_Inactive m_inactive;
        public AD_Death m_death;
    }

}
