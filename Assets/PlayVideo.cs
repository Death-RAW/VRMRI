using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoClip videoClip; // Video clip to play
    private VideoPlayer videoPlayer; // Reference to the VideoPlayer component

    void Start()
    {
        // Get or add the VideoPlayer component
        if (GetComponent<VideoPlayer>() == null)
        {
            videoPlayer = gameObject.AddComponent<VideoPlayer>();
        }
        else
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Set the video clip
        if (videoPlayer != null && videoClip != null)
        {
            videoPlayer.clip = videoClip;
        }

        // Play the video
        if (videoPlayer != null)
        {
            videoPlayer.Play();
        }
    }
}
