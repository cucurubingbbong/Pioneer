using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEventManager : MonoBehaviour
{
    public SceneEventManager Instance { get; private set; }

    /// <summary>
    /// �� ���� �̺�Ʈ
    /// </summary>
    public static event Action SceneStartEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // �� �ε�� ȣ��Ǳ�
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // �� ��ȯ �� �ߺ� ����
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        // �� ���� �� �߻���ų �̺�Ʈ ȣ��
        SceneStartEvent?.Invoke();
    }

    /// <summary>
    /// ȣ��� ����ƽ �޼���
    /// </summary>
    public static void TriggerSceneStart()
    {
        SceneStartEvent?.Invoke();
    }



}
