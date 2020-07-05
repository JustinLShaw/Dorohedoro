using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndScene : MonoBehaviour
{
    public GameObject video_player;
    VideoPlayer videoPlane;

    // Start is called before the first frame update
    void Start()
    {
        videoPlane = video_player.GetComponent<VideoPlayer>();
        videoPlane.Prepare();
        videoPlane.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        videoPlane.Play();
        //Destroy(this.gameObject);
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("WinScene");
    }
}
