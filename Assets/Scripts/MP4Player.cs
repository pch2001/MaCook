using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MP4Player : MonoBehaviour
{
    public GameObject panelMP4Player;     // 영상 표시용 패널
    public VideoPlayer videoplayer;       // VideoPlayer 컴포넌트
    public RawImage rawImage;             // 영상을 출력할 UI RawImage

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

        // 이벤트 등록 (영상 끝날 때)
        videoplayer.loopPointReached += OnVideoEnd;

        // Start 영상 먼저 실행
        PlayVideo(startVideoPath, false); // 처음 영상은 반복 X
    }
    private void PlayVideo(string path, bool loop)
    {
        videoplayer.Stop();                // 혹시 이전 영상 재생 중이면 정지
        videoplayer.isLooping = loop;      // 반복 여부 설정
        videoplayer.url = path;
        StartCoroutine(LoadVideo());
    }
    private IEnumerator LoadVideo()
    {
        // 영상 준비
        videoplayer.Prepare();

        while (!videoplayer.isPrepared)
        {
            Debug.Log("비디오 로딩중...");
            yield return null;
        }

        Debug.Log("비디오 로딩 완료!");

        // 영상 Texture를 RawImage에 할당
        rawImage.texture = videoplayer.texture;

        // 영상 재생
        videoplayer.Play();
    }
    private void OnVideoEnd(VideoPlayer vp)
    {
        StartButton.SetActive(true);

        if (isStartVideo)
        {
            // Start.mp4 끝나면 Loop.mp4 재생 (무한 반복 ON)
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
        rawImage.texture = null;                 // 화면 비우기
        panelMP4Player.SetActive(false);         // 패널 닫기
        StartButton.SetActive(false);
    }
}
