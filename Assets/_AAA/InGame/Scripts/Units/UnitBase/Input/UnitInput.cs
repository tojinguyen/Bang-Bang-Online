using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class UnitInput : MonoBehaviour
{
    public Vector2 Move;

    public Action OnAttack;
    public Action OnUseSkill;
    public Action OnDodge;

    public Action OnDefense;
    public Action OnCancelDefense;


    public Queue<NormalAttackInput> BufferAttackInputs;
    public Queue<SkillInput> BufferSkillAttackInputs;
}


public struct SkillInput
{
    public UnitInputType Type;
    public int Tick;
}

public struct DefenseInput
{
    public UnitInputType Type;
    public int Tick;
}

public struct NormalAttackInput
{
    public UnitInputType Type;
    public int Tick;
}

public struct DodgeInput
{
    public UnitInputType Type;
    public int Tick;
}

public enum UnitInputType
{
    Move,
    Sprint,
    NormalAttack,
    Skill,
    Defense,
    Dodge
}

