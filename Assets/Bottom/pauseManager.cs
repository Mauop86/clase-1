using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseManager: MonoBehaviour
{
    public static bool pause = false;
    public void modePause()
    {
        pause = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
    public void modePlay()
    {
        pause = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
}
