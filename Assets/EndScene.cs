using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndScene : MonoBehaviour
{
    public GameObject video_player;
    VideoPlayer videoPlane;
    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        videoPlane = video_player.GetComponent<VideoPlayer>();
        videoPlane.Prepare();
        videoPlane.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, this.transform.position) < 5.0f)
        {
            videoPlane.Play();
        }
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
