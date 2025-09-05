using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int turn = 0;

    [SerializeField] BattleManager battleManager = null;

    public void TurnStart()
    {
        battleManager.BattleStart();
    }
}
