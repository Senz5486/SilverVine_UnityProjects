using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MM_Highlight_TextAnimation : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    Animator _animator;
    SoundController _soundcontroller;

    private void Awake()
    {
        _soundcontroller = GameObject.Find("SoundControllerObject").GetComponent<SoundController>();
        _animator = this.GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _soundcontroller.PlaySEAudio = 2;
        _animator.SetBool("IsCursorHighlight", true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _soundcontroller.PlaySEAudio = -1;
        _animator.SetBool("IsCursorHighlight", false);
    }

}
