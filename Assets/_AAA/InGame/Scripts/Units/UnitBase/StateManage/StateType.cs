
public enum StateType : byte
{
    None = 0,
    Idle = 1,

    Move = 5,

    NormalAttack = 20,


    Skill = 50,

    Defense = 80,


    Damaged = 100,
    KnockBack = 101,

    Invulnerable = 110,

    DodgeFront = 150,
    DodgeBack = 151,

    Dead = 200,
    Respawn = 201,
}