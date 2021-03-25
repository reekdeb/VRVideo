using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

[RequireComponent(typeof(Animator))]
public class UIManager : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartVR()
    {
        IEnumerator LoadNextScene()
        {
            var ao = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            ao.allowSceneActivation = false;
            while(!ao.isDone)
            {
                if(ao.progress >= 0.9f)
                {
                    var didWaitForOrientation = false;
                    if (Input.deviceOrientation != DeviceOrientation.LandscapeLeft)
                    {
                        didWaitForOrientation = true;
                        animator.SetTrigger("WaitForVR");
#if !UNITY_EDITOR
                        yield return new WaitUntil(() => Input.deviceOrientation == DeviceOrientation.LandscapeLeft);
#else
                        yield return new WaitForSecondsRealtime(2);
#endif
                    }
                    Screen.orientation = ScreenOrientation.LandscapeLeft;
                    if(didWaitForOrientation)
                    {
                        animator.SetTrigger("EnterVR");
                        yield return new WaitForSecondsRealtime(2);
                    }
                    yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
                    XRGeneralSettings.Instance.Manager.StartSubsystems();
                    ao.allowSceneActivation = true;
                }
                yield return null;
            }
        }
        StartCoroutine(LoadNextScene());
    }
}
