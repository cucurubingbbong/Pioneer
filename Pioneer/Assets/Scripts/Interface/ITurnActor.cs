using System.Collections;
using UnityEngine;

public interface ITurnActor
{
    /// <summary>
    /// 턴 받기
    /// </summary>
    /// <returns></returns>
    IEnumerator TakeTurn(Unit orderUnit);
}
