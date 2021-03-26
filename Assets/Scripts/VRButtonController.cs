using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// VR Button controller and events.
/// </summary>
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

    /// <summary>
    /// Message sent by CameraPointer.
    /// </summary>
    public void OnPointerEnter()
    {
        animator.SetBool(onGaze, true);
    }

    /// <summary>
    /// Message sent by CameraPointer.
    /// </summary>
    public void OnPointerExit()
    {
        animator.SetBool(onGaze, false);
    }

    /// <summary>
    /// Message sent by CameraPointer.
    /// </summary>
    public void OnPointerClick()
    {
        OnClick.Invoke();
    }
}
