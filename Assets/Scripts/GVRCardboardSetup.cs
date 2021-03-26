using Google.XR.Cardboard;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

/// <summary>
/// Setup Google VR Cardboard settings.
/// </summary>
public class GVRCardboardSetup : MonoBehaviour
{
    private void Start()
    {
        // Do not sleep
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }

    }

    private void Update()
    {
        if (Api.IsGearButtonPressed)
        {
            Api.ScanDeviceParams();
        }

        if (Api.IsCloseButtonPressed)
        {
            CloseVRScene();
        }

        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }

        Api.UpdateScreenParams();
    }

    /// <summary>
    /// Close VR scene and back to previous scene.
    /// </summary>
    public void CloseVRScene()
    {
        IEnumerator LoadPreviousScene()
        {
            var ao = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
            ao.allowSceneActivation = false;
            while (!ao.isDone)
            {
                if (ao.progress >= 0.9f)
                {
                    XRGeneralSettings.Instance.Manager.StopSubsystems();
                    XRGeneralSettings.Instance.Manager.DeinitializeLoader();
                    ao.allowSceneActivation = true;
                }
                yield return null;
            }
        }
        StartCoroutine(LoadPreviousScene());
    }
}
