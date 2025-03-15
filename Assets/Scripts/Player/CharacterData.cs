using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Data")]
public class CharacterData : ScriptableObject
{
    [Header("MOVEMENT")]
    public float Speed;
    public float JumpForce;

    [Header("HEALTH")]
    public int MaxHealth = 3;

}
