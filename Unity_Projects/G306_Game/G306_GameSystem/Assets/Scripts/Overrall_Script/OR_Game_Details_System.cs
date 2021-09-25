using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OR_Game_Details_System : MonoBehaviour
{
    //## GameVersion = ゲームのバージョンの指定(初期1.0.0 基本的に 1.1 / 1.2 という感じ 大きなアップデートが有れば 2.0 などにする。)
    //## BuildNumber = ビルドナンバーの指定(ビルドした年月日 + 46881 / 例(ビルドした日時2021/09/20): 2021092046881)
    public string GameVersion = "1.0.0";
    public string BuildNumber = "2021" + "09"+ "20" + "46881";
}
