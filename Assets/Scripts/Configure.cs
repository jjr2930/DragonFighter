using UnityEngine;
using System.Collections;

public class Configure : MonoSingle<Configure>
{
    #region Camera's Configure
    public Vector3 TPS_CAM_IDLE_POS;
    public Vector3 TPS_CAM_WALK_POS;
    public Vector3 TPS_CAM_RUN_POS;
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

    #region Player Configure

    #region Plaer Animator Configure
    public float PLAYER_FWD_ACCEL = 0.5f;
    public float PLAYER_BACK_ACCEL = 1f;
    
    public float PLAYER_FWDSPEED_LIMIT = 1f;
    public float PLAYER_BACKSPEED_LIMIT = 1f;
    public float PLAYER_STRAFE_LIMIT = 1f;

    public float PLAYER_STRAFE_ACCEL = 0.5f;

    public float PLAYER_STOP_SPEED_ACCEL = 2f;

    public string ANIM_FORWARD = "Forward";
    public string ANIM_STRAFE = "Right";
    public string ANIM_BtnA = "BtnA";
    public string ANIM_BtnB = "BtnB";

    #endregion

    #region tag

    public string TAG_PLAYER = "Player";
    #endregion


    #endregion

}
