using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MM_Highlight_TextAnimation : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    Animator _animator;

    private void Awake()
    {
        _animator = this.GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _animator.SetBool("IsCursorHighlight", true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _animator.SetBool("IsCursorHighlight", false);
    }

}
