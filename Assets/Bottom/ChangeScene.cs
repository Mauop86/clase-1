using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int tagScene = 0;
    public void loadScene()
    {
        SceneManager.LoadScene(tagScene);
    }
}
