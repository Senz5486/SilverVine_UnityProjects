using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OR_DontDestroySceneLoadObject : MonoBehaviour
{
    public GameObject MainMenuSoundObject;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        MainMenuSoundObject = this.gameObject;
    }


}
