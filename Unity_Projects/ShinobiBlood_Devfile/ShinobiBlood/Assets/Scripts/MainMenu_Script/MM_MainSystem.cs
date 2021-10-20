using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
        public class MM_MainSystem : MonoBehaviour
        {
            //SoundObject
            [SerializeField] private SoundController _SoundController;
            [SerializeField] private MusicController _MusicController;

            //GameObject
            [SerializeField] private GameObject[] _DissolveObjects;
            [SerializeField] private GameObject DissolveFade;

            //Float
            private float FadeSpeed;
            private void Awake()
            {
                
                _SoundController = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
                _MusicController = GameObject.Find("MusicControllerObject").GetComponent<MusicController>();
                Invoke("PlayMusic", 0.15f);

            }
            void Start()
            {
                FadeSpeed = 0.0083f;
            }

            void FixedUpdate()
            {
                DissolveFade.GetComponent<UIDissolve>().location += 0.02f;

                if (DissolveFade.GetComponent<UIDissolve>().location >= 0.95f)
                {
                    DissolveFade.SetActive(false);
                }

                if (_DissolveObjects[0].GetComponent<UIDissolve>().location > 0.0f)
                {
                    for (int i = 0; i < _DissolveObjects.Length; i++)
                    {
                        _DissolveObjects[i].GetComponent<UIDissolve>().location -= FadeSpeed;
                    }
                }
            }

            void PlayMusic()
            {
            _MusicController.PlayBGMAudio = 1;
            }
        }
}
