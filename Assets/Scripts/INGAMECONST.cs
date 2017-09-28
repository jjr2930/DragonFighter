using UnityEngine;
using System.Collections;

public static class INGAMECONST 
{
    public static class BundleName
    {
        public const string BUNDLE_NAME_PLAYER = "player";
        public const string BUNDLE_NAME_ZOMBIE = "zombie";
    }

    public static class AssetName
    {
        public const string ASSET_NAME_PLAYER_PREFAB = "player";
        public const string ASSET_NAME_ZOMBIE1_PREFAB = "zombie1";
        public const string ASSET_NAME_ZOMBIE2_PREFAB = "zombie2";
        public const string ASSET_NAME_ZOMBIE3_PREFAB = "zombie3";
    }
    public static class AnimatorHash
    {
        public static readonly int CREATE_MONSTER       = Animator.StringToHash("CreateMonster");
        public static readonly int CREATE_PLAYER        = Animator.StringToHash("CreatePlayer");
        public static readonly int ENTER_CINEMA         = Animator.StringToHash("EnterCinema");
        public static readonly int LOOP                 = Animator.StringToHash("Loop");
        public static readonly int ENTER_BOSS_CINEMA    = Animator.StringToHash("EnterBossCinema");
        public static readonly int WIN_CINEMA           = Animator.StringToHash("WinCinema");
        public static readonly int DEAD_CINEMA          = Animator.StringToHash("DeadCinema");
        public static readonly int RESET                = Animator.StringToHash("Reset");
        public static readonly int SPEED                = Animator.StringToHash("Speed");
        public static readonly int MOVE                 = Animator.StringToHash("Move");
        public static readonly int ATTACK               = Animator.StringToHash("Attack");
        public static readonly int WAIT                 = Animator.StringToHash("Wait");
        public static readonly int DEAD                 = Animator.StringToHash("Dead");
        public static readonly int COMPLETE             = Animator.StringToHash("Complete");
        public static readonly int STOP_DISTANCE        = Animator.StringToHash("StopDistance");
        public static readonly int ATTACK_TYPE          = Animator.StringToHash("AttackType");
    }

    public static class Tag
    {
        public const string MONSTER = "Monster";
    }
}
