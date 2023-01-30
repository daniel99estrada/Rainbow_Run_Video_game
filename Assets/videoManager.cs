using UnityEngine;
using UnityEngine.Video;

public class videoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneToLoad = "Game";

    void Start()
    {
        videoPlayer.playOnAwake = true;
        videoPlayer.loopPointReached += LoadScene;
    }

    void LoadScene(VideoPlayer vp)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}