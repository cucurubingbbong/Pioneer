using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEventManager : MonoBehaviour
{
    public SceneEventManager Instance { get; private set; }

    /// <summary>
    /// 씬 시작 이벤트
    /// </summary>
    public static event Action SceneStartEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // 씬 로드시 호출되기
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // 씬 전환 시 중복 방지
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        // 씬 시작 시 발생시킬 이벤트 호출
        SceneStartEvent?.Invoke();
    }

    /// <summary>
    /// 호출용 스태틱 메서드
    /// </summary>
    public static void TriggerSceneStart()
    {
        SceneStartEvent?.Invoke();
    }



}
