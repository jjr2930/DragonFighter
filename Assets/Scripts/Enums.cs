using UnityEngine;
using System.Collections;

public enum E_VirtualKey : int 
{
    Forward_Down = 0,
    Forward_UP,
    Forward,

    Back_Down,
    Back_UP,
    Back,

    Left_Down,
    Left_UP,
    Left,

    Right_Down,
    Right_UP,
    Right,

    Up_Down,
    Up_UP,
    Up,

    Down_Down,
    Down_UP,
    Down,

    ButtonA_Down,
    ButtonA_Up,
    ButtonA,

    ButtonB_Down,
    ButtonB_Up,
    ButtonB,

    Pause_Down,
    Max
}

public enum E_UserAnimEvent : int
{
    Idle = 0,
    Walk,
    Attack,
    EnemyAttack,
    Run,
    Max,

}

public enum E_ZombieAnimEvent : int
{
    Idle = 0,
    Scream,
    Walk,
    Run,
    Attack,
    Bite,
    NeckBite,
    DeathForward,
    DeathBack
}



public enum E_EtcEvent : int
{
    PointUp = 0,
    UserDied,
    VirtualKeyOn,
    Max
    
}

public enum E_UIEvent : int
{
    SceneChange = 0,
    MAX
}

public enum E_ZombieType : int
{
    Run = 0,
    Walk,
    MAX
}

public enum E_SceneNumber : int
{
    None = 0,
    Intro,
    Menu,
    Ingame,
    Exit,
    Loading,
    MAX

}

public enum E_MenuEvnet : int
{
    StartClick,
    RecordClick,
    CloseRecordClick,
    ExitClick,
}