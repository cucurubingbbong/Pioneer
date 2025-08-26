using UnityEngine;

abstract class UnitBase
{
    /// <summary>
    /// �ִ�ü��
    /// </summary>
    [SerializeField] float maxHp = 0.0f;

    /// <summary>
    /// ����ü��
    /// </summary>
    [SerializeField] float currentHp = 0.0f;

    /// <summary>
    /// ���ݷ���
    /// </summary>
    [SerializeField] int attackLevel = 0;

    /// <summary>
    /// ����
    /// </summary>
    [SerializeField] int defenseLevel = 0;

    /// <summary>
    /// �ӵ�
    /// </summary>
    [SerializeField] int speed = 0;

    /// <summary>
    /// ���ŷ�
    /// </summary>
    [SerializeField] int mentalPower = 0;
}
