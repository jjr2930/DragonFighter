using UnityEngine;
using System.Collections;

public interface ITargetInfo
{
    Transform TargetTransform { get; }
    RaycastHit TargetHitInfo { get; }
}
