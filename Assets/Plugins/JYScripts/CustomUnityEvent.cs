using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
[Serializable]
public class ObjectUnityEvent : UnityEvent<System.Object>{}
 
[Serializable]
public class IntUnityEvent : UnityEvent<int> { }

[Serializable]
public class VectorUnityEvent : UnityEvent<Vector3> { }

[Serializable]
public class TransformUnityEvent : UnityEvent<Transform> { }

[Serializable]
public class RaycastHitUnityEvent : UnityEvent<RaycastHit> { }

[Serializable]
public class GameObjectUnityEvent : UnityEvent<GameObject> { }

[Serializable]
public class FloatUnityEvent : UnityEvent<float>{}