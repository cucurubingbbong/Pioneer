using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class UnitBase
{
    /// <summary>
    /// �����̸�
    /// </summary>
    public string unitName = null;

    /// <summary>
    /// ��ų ����Ʈ
    /// </summary>
    public List<Skill> skillList = new List<Skill>();
    /// <summary>
    /// �ִ�ü��
    /// </summary>
    public float maxHp = 0.0f;

    /// <summary>
    /// ����ü��
    /// </summary>
    public float currentHp = 0.0f;

    /// <summary>
    /// ���ݷ���
    /// </summary>
    public int attackLevel = 0;

    /// <summary>
    /// ����
    /// </summary>
    public int defenseLevel = 0;

    /// <summary>
    /// �ӵ�
    /// </summary>
    public int speed = 0;

    /// <summary>
    /// ���ŷ�
    /// </summary>
    public int mentalPower = 0;
}
