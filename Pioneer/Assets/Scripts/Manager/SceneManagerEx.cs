using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 씬 매니저
/// </summary>
public class SceneManagerEx : MonoBehaviour
{
    public static SceneManagerEx Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    /// <summary>
    /// 씬 로드
    /// </summary>
    /// <param name="sceneName">로딩할 씬</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
