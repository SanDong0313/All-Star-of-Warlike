using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_move_btn : MonoBehaviour 
{
    public string level_name;

    public void OnHome()
    {
        SMGameEnvironment.Instance.SceneManager.LoadScreen(level_name);
    }
}
