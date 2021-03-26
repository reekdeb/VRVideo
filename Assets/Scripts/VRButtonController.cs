using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class VRButtonController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnClick;

    private Animator animator;
    private int onGaze = Animator.StringToHash("OnGaze");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter()
    {
        animator.SetBool(onGaze, true);
    }

    public void OnPointerExit()
    {
        animator.SetBool(onGaze, false);
    }

    public void OnPointerClick()
    {
        OnClick.Invoke();
    }
}
