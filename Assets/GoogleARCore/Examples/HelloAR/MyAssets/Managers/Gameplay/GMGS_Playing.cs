using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GMGS_Playing : GMGS_GameplayControllerStates
{
    private float gameTime;
    private Text gameTimeText;

    public GameManagerPlaying gameManagerPlaying;
    public GameManagerMain gameManagerMain;
    private PoolAndy poolAndy;

    public override void Enter()
    {
        gameManagerPlaying = FindObjectOfType<GameManagerPlaying>();
        gameManagerMain = FindObjectOfType<GameManagerMain>();

        gameManagerPlaying.GPS_GoToPlaying_Waiting();
        poolAndy = FindObjectOfType<PoolAndy>();

        m_target.GameTimeUI.SetActive(true);
        gameTimeText = m_target.GameTimeUI.GetComponentInChildren<Text>();
        gameTime = 60.0f;
        gameTimeText.text = "Tiempo: " + " " + gameTime.ToString("f0");
        
    }

    public override void Exit()
    {
        poolAndy.GameOver();
        m_target.GameTimeUI.SetActive(false);
        m_target.helloARController.boardObject.SetActive(false);
    }

    public override void Update()
    {
        if( gameTime > 0)
        {
            gameTime -= Time.deltaTime;

            gameTimeText.text = "Tiempo:" + " " + gameTime.ToString("f0");

        }
        else
        {
            gameManagerMain.SM_GoToMenu();
            gameManagerPlaying.GPS_GoToInactive();
            m_target.SMG_GoToInactive();
        }
    }
}
