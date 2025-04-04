using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterStats : MonoBehaviour, IPlayerStats
{
    [Inject]
    public int Power { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int Agility { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int Endurance { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
