using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// VR Button controller and events.
/// </summary>
[RequireComponent(typeof(Animator))]
public class VRButtonController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onClick;
    [SerializeField]
    private UnityEvent onPointerEnter;
    [SerializeField]
    private UnityEvent onPointerExit;

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
        onPointerEnter.Invoke();
    }

    /// <summary>
    /// Message sent by CameraPointer.
    /// </summary>
    public void OnPointerExit()
    {
        animator.SetBool(onGaze, false);
        onPointerExit.Invoke();
    }

    /// <summary>
    /// Message sent by CameraPointer.
    /// </summary>
    public void OnPointerClick()
    {
        onClick.Invoke();
    }
}
