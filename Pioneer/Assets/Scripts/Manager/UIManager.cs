using System.Collections.Generic;
using UnityEngine;


public enum UIScreenType
{
    None,
    InGameUi,
    Settings,
    BattleSet,
    UnitSet,
}

[System.Serializable]
public class UIScreen
{
    public UIScreenType type;
    public GameObject root;
}


public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public Dictionary<UIScreenType, GameObject> screenMap = new Dictionary<UIScreenType, GameObject>();

    public UIScreenType currentScreen = UIScreenType.None;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

      UIScreenRoot[] uiElements = FindObjectsByType<UIScreenRoot>(FindObjectsInactive.Include,FindObjectsSortMode.None);

        foreach (var elements in uiElements)
        {
            elements.Assign();
        }
    }

    public void RegisterScreen(UIScreenType type, GameObject root)
    {
        screenMap[type] = root;
        root.SetActive(false);
    }

    public void UnregisterScreen(UIScreenType type, GameObject root)
    {
        if (screenMap.TryGetValue(type, out var stored) && stored == root)
        {
            screenMap.Remove(type);
        }
    }

    public void ShowScreen(UIScreenType type)
    {

        if (screenMap.TryGetValue(currentScreen, out var prevRoot))
            prevRoot.SetActive(false);

        if (screenMap.TryGetValue(type, out var newRoot))
        {
            newRoot.SetActive(true);
            currentScreen = type;
        }
    }

    public void SetUnit()
    {
        ShowScreen(UIScreenType.BattleSet);
    }

    public void GameUi()
    {
        ShowScreen(UIScreenType.InGameUi);
    }

    public void Office()
    {
        ShowScreen(UIScreenType.InGameUi);
    }
}

