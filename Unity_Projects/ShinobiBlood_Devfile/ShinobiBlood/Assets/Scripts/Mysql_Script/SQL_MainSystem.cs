using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SQL_MainSystem : MonoBehaviour
{
    string url = "http://58.88.221.104/data/data_server.php";
    public int Stage_ID;
    public float Stage_MaxScore;
    
    public void CallLoadScore()
    {
        //StartCoroutine(DataServer());
    }

    /*IEnumerator DataServer()
    {
        WWWForm form = new WWWForm();
        form.AddField
    }*/
}
