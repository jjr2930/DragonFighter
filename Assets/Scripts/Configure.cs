using UnityEngine;
using System.Collections;

public class Configure : MonoSingle<Configure> {
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

}
