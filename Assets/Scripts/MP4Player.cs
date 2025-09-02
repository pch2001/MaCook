using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MP4Player : MonoBehaviour
{
    public GameObject panelMP4Player;     // ���� ǥ�ÿ� �г�
    public VideoPlayer videoplayer;       // VideoPlayer ������Ʈ
    public RawImage rawImage;             // ������ ����� UI RawImage

    private string startVideoPath;
    private string loopVideoPath;
    private bool isStartVideo = true;


    public GameObject StartButton;
    public GameObject MainImage;

    void Start()
    {
        startVideoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Start.mp4");
        loopVideoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Loop.mp4");

        panelMP4Player.SetActive(true);
        StartButton.SetActive(false);
        MainImage.SetActive(false);

        // �̺�Ʈ ��� (���� ���� ��)
        videoplayer.loopPointReached += OnVideoEnd;

        // Start ���� ���� ����
        PlayVideo(startVideoPath, false); // ó�� ������ �ݺ� X
    }
    private void PlayVideo(string path, bool loop)
    {
        videoplayer.Stop();                // Ȥ�� ���� ���� ��� ���̸� ����
        videoplayer.isLooping = loop;      // �ݺ� ���� ����
        videoplayer.url = path;
        StartCoroutine(LoadVideo());
    }
    private IEnumerator LoadVideo()
    {
        // ���� �غ�
        videoplayer.Prepare();

        while (!videoplayer.isPrepared)
        {
            Debug.Log("���� �ε���...");
            yield return null;
        }

        Debug.Log("���� �ε� �Ϸ�!");

        // ���� Texture�� RawImage�� �Ҵ�
        rawImage.texture = videoplayer.texture;

        // ���� ���
        videoplayer.Play();
    }
    private void OnVideoEnd(VideoPlayer vp)
    {
        StartButton.SetActive(true);

        if (isStartVideo)
        {
            // Start.mp4 ������ Loop.mp4 ��� (���� �ݺ� ON)
            isStartVideo = false;
            PlayVideo(loopVideoPath, true);
        }
    }

    public void StartGame()
    {
        MainImage.SetActive(true);
        if (videoplayer.isPlaying)
        {
            videoplayer.Stop();
        }
        rawImage.texture = null;                 // ȭ�� ����
        panelMP4Player.SetActive(false);         // �г� �ݱ�
        StartButton.SetActive(false);
    }
}
