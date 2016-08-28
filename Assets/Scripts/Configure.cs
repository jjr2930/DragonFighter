using UnityEngine;
using System.Collections;

[System.Serializable]
public class Configure : MonoSingle<Configure>
{
    #region Camera's Configure
    public Vector3 TPS_CAM_LOCATION;
    public Vector3 TPS_CAM_LOOKPOS;
    public float TPS_CAM_MOVE_SPEED;
    #endregion

    #region PC Key
    public KeyCode FWD_KEY = KeyCode.UpArrow;
    public KeyCode LEFT_KEY = KeyCode.LeftArrow;
    public KeyCode BACK_KEY = KeyCode.DownArrow;
    public KeyCode RIGHT_KEY = KeyCode.RightArrow;
    public KeyCode KEY_A = KeyCode.A;
    public KeyCode KEY_B = KeyCode.B;
    #endregion

    #region Virtual lever sleep amount

    public float LEVER_SLEEP = 20f;

    #endregion

    #region Player Configure

    #region Player Animator Configure
    public float ANIM_FWD_ACCEL = 0.5f;
    public float ANIM_BACK_ACCEL = 1f;
    
    public float ANIM_FWDSPEED_LIMIT = 1f;
    public float ANIM_BACKSPEED_LIMIT = -1f;
    public float ANIM_STRAFE_LIMIT = 1f;

    public float ANIM_STRAFE_ACCEL = 0.5f;

    public float ANIM_STOP_SPEED_ACCEL = 2f;

    public string ANIM_USER_FORWARD = "Forward";
    public string ANIM_USER_STRAFE = "Right";
    public string ANIM_USER_BtnA = "BtnA";
    public string ANIM_USER_BtnB = "BtnB";

    #endregion

    #region Player Locomotion Configure

    public float MOVE_FWD_LIMIT = 1f;
    public float MOVE_BACK_LIMIT = 1f;
    public float MOVE_STRAFE_LIMIT = 1f;
    public float MOVE_ROT_SPEED = 120f;

    #endregion

    #region Player ETC

    public float PLAYER_ATTACK_RANGE = 1f;

    #endregion

    #endregion

    #region zombie Configure

    #region animation param
    public string ANIM_ZOMBIE_IDLE      = "Idle";
    public string ANIM_ZOMBIE_WALK      = "Walk";
    public string ANIM_ZOMBIE_RUN       = "Run";
    public string ANIM_ZOMBIE_SCREAM    = "Scream";
    public string ANIM_ZOMIBE_ATTACK    = "Attack";
    public string ANIM_ZOMBIE_NECKBITE  = "NeckBite";
    public string ANIM_ZOMBIE_BITE      = "Bite";
    public string ANIM_ZOMBIE_DEATH_FWD = "DeathForward";
    public string ANIM_ZOMBIE_DEATH_BCK = "DeathBack";
    public string ANIM_ZOMBIE_HIT       = "HitReaction";
    #endregion

    #region etc

    public int ZOMBIE_DEFAULT_POINT = 5;
        
    #endregion
    #endregion

    #region tag

    public string TAG_PLAYER    = "Player";
    public string TAG_RESPAWN   = "Respawn";
    #endregion

    #region Resrouces path
    public string PATH_PLAYER   = "Player";
    public string PATH_ZOMBIE_0 = "Zombie_0";
    public string PATH_ZOMBIE_1 = "Zombie_1";
    public string PATH_ZOMBIE_2 = "Zombie_2";
    public string PATH_ZOMBIE_3 = "Zombie_3";

    #endregion

    #region SceneName

    public string SCENENAME_MENU = "Menu";
    public string SCENENAME_INGAME = "Ingame";
    public string SCENENAME_INTRO = "Intro";
    public string SCENENAME_UI = "UI";

    #endregion

    #region TableName Path
    public string PATH_DIFF_TABLE = "Tables/DifficultTable";
    public string PATH_LOCAL_TABLE = "Tables/Localize";
    public string PATH_RESC_TABLE = "Tables/ResourceTable";
    #endregion  
    /// <summary>
    /// initialize( Load Configure.txt and overwrite)
    /// </summary>
    void Awake()
    {
        TextAsset ta = JResources.Load("Tables/Configure") as TextAsset;
        string json = ta.text;

        JsonUtility.FromJsonOverwrite(json, this);      
    }    
}
