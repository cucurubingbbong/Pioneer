using UnityEngine;

/// <summary>
/// 의뢰 등급
/// </summary>
public enum QuestRank
{
    /// <summary>
    /// 뜬소문
    /// </summary>
    Rumors,
    /// <summary>
    /// 도시 괴담
    /// </summary>
    GhostStories,
    /// <summary>
    /// 도시 전설
    /// </summary>
    Legend,
    /// <summary>
    /// 도시 질병
    /// </summary>
    Disease,
    /// <summary>
    /// 도시 악몽
    /// </summary>
    Nightmare,
    /// <summary>
    /// 도시의 별
    /// </summary>
    Star,

}


[System.Serializable]
public class Quest
{
    /// <summary>
    /// 의뢰를 받기 위한 최소 레벨
    /// </summary>
    public int minLevel;

    /// <summary>
    /// 의뢰를 받기 위한 최대 레벨
    /// </summary>
    public int maxLevel;

    public QuestRank rank;
}
