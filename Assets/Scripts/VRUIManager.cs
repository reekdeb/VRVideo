using UnityEngine;
using UnityEngine.Video;

public class VRUIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private SpriteRenderer playPauseButton;

    [Header("Assets")]
    [SerializeField]
    private Sprite videoPlaySprite;
    [SerializeField]
    private Sprite videoPauseSprite;

    public void PlayPauseToggle()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            playPauseButton.sprite = videoPlaySprite;
        }
        else
        {
            videoPlayer.Play();
            videoPlayer.GetComponent<MeshRenderer>().enabled = true;
            playPauseButton.sprite = videoPauseSprite;
        }
    }
}
