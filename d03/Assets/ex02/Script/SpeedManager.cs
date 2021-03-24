using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public void ClickPause()
    {
        gameManager.gm.pause(true);
    }

    public void ClickSpeed(float speed)
    {
        gameManager.gm.changeSpeed(speed);
    }
}
