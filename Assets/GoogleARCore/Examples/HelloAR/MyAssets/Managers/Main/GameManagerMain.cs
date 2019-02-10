using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMain : MonoBehaviour
{

    //public PrincipalARController principalARController;
    private void Update()
    {
        m_states.m_current.Update();
    }
    #region state management
    private void SM_GoToState(GMS_ControllerState newState)
    {
        m_states.m_current.Exit();
        m_states.m_current = newState;
        m_states.m_current.Enter();
    }

    public void SM_GoToMenu()
    {
        SM_GoToState(m_states.m_menu);
    }

    public void SM_GoToScanningRoom()
    {
        SM_GoToState(m_states.m_scanningroom);
    }
    public void SM_GoToPlaying()
    {
        SM_GoToState(m_states.m_playing);
    }

    public void SM_GoToInactive()
    {
        SM_GoToState(m_states.m_inactive);
    }
    #endregion

    private void Awake()
    {
        m_states.m_menu = ScriptableObject.CreateInstance<GMS_Menu>().Init(this) as GMS_Menu;
        m_states.m_scanningroom = ScriptableObject.CreateInstance<GMS_ScanningRoom>().Init(this) as GMS_ScanningRoom;
        m_states.m_playing = ScriptableObject.CreateInstance<GMS_Playing>().Init(this) as GMS_Playing;
        m_states.m_inactive = ScriptableObject.CreateInstance<GMS_Inactive>().Init(this) as GMS_Inactive;

        m_states.m_current = m_states.m_inactive;
        SM_GoToScanningRoom();
    }

    [SerializeField]
    GameManagerMainControllerStates m_states;

    [System.Serializable]
    public class GameManagerMainControllerStates
    {
        public GMS_ControllerState m_current;

        public GMS_Menu m_menu;
        public GMS_ScanningRoom m_scanningroom;
        public GMS_Playing m_playing;
        public GMS_Inactive m_inactive;
    }
}