using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Senz_Program
{
    [System.Serializable]
    public class SaveData
    {
        public bool FinishTutorial;
        public float SEVolume;
        public float BGMVolume;
        public float Stage1Score;
        public float Stage2Score;
        public float Stage3Score;
        public float Stage4Score;
        public float Stage5Score;
        public float StageExScore;
    }
}
