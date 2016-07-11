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

    #region Player Animator Configure
    public float ANIM_FWD_ACCEL = 0.5f;
    public float ANIM_BACK_ACCEL = 1f;
    
    public float ANIM_FWDSPEED_LIMIT = 1f;
    public float ANIM_BACKSPEED_LIMIT = -1f;
    public float ANIM_STRAFE_LIMIT = 1f;

    public float ANIM_STRAFE_ACCEL = 0.5f;

    public float ANIM_STOP_SPEED_ACCEL = 2f;

    public string ANIM_FORWARD = "Forward";
    public string ANIM_STRAFE = "Right";
    public string ANIM_BtnA = "BtnA";
    public string ANIM_BtnB = "BtnB";

    #endregion

    #region Player Locomotion Configure

    public float MOVE_FWD_LIMIT = 1f;
    public float MOVE_BACK_LIMIT = 1f;
    public float MOVE_STRAFE_LIMIT = 1f;
    

    #endregion

    #region tag

    public string TAG_PLAYER = "Player";
    #endregion


    #endregion

}
