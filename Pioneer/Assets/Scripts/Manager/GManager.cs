using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager Instance { get; private set; } = null;

    private void Awake()
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
    /// ��¥
    /// </summary>
    public int Day = 0;

}
