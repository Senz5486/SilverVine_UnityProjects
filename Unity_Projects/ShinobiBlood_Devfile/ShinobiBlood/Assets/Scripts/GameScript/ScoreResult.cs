using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Senz_Program {
    public class ScoreResult : MonoBehaviour
    {
        Score_Mass MassScore;
        [SerializeField] private Text ResultScoreText;
        [SerializeField] private Text CurrentStageMaxScoreText;
        private float ShownTime;
        void Start()
        {
            MassScore = GameObject.Find("ScriptObject").GetComponent<Score_Mass>();
            ShownTime = 3.0f;
        }

        private void Update()
        {
            ShownTime -= Time.deltaTime;
            if (ShownTime > 0)
            {
                ResultScoreText.text = Random.Range(100000, 999999).ToString("0");
            }
            else if (ShownTime < 0)
            {
                ResultScoreText.text = MassScore.Score().ToString();
                ShownTime = -1;
            }
        }
    }
}
