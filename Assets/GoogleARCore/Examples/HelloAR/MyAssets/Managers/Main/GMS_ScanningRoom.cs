using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMS_ScanningRoom : GMS_ControllerState
{
    private bool placed;
    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        placed = m_target.helloARController.placed;
        if (!placed)
        {
            m_target.helloARController.Scan();
        }
        else
        {
            m_target.SM_GoToMenu();
        }
    }
}
