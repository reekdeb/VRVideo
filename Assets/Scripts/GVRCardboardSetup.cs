using Google.XR.Cardboard;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

public class GVRCardboardSetup : MonoBehaviour
{
    private void Start()
    {
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

    private void CloseVRScene()
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
