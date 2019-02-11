using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GMGS_InitGame : GMGS_GameplayControllerStates
{
    public override void Enter()
    {
        m_target.helloARController.boardObject.SetActive(true);
        m_target.SMG_GoToPlaying();
    }
    public override void Exit()
    {
    }
    public override void Update()
    {
        
    }
}
