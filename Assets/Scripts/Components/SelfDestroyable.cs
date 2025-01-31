using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyable : MonoBehaviour, IAbilityTarget
{
    public bool canBeDestroy = false;
    public float timeToDestroy = 0;
    private float _createTime;
    public List<GameObject> Targets { get; set; }

    private void Awake()
    {
        _createTime = Time.time;
    }

    public void Execute()
    {
        foreach (var target in Targets)
        {
            if (target.CompareTag("Player") && _createTime + 0.3f < Time.time) //����������� �� ������������ � ������, � ��������� � ������ ������ ����
            {
                canBeDestroy = true;
            }
            if (timeToDestroy != 0 && _createTime + timeToDestroy < Time.time) //����������� �� ������� �����
            {
                canBeDestroy = true;
            }
        }
    }

}
