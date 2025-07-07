using UnityEngine;

public class OpenYTLink : MonoBehaviour
{
    public string youtubeURL = "https://www.youtube.com";

    public void OpenLink()
    {
        Application.OpenURL(youtubeURL);
    }
}
