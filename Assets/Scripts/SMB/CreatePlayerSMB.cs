using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AssetBundles;
public class CreatePlayerSMB : StateMachineBehaviour {

    public string spawnPointName = "";
    // Use this for initialization

    AssetBundleLoadAssetOperation operation = null;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        string bundleName = INGAMECONST.BundleName.BUNDLE_NAME_PLAYER;
        string assetName = INGAMECONST.AssetName.ASSET_NAME_PLAYER_PREFAB;
        operation = AssetBundleManager.LoadAssetAsync(bundleName, assetName, typeof(GameObject));
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (operation.IsDone())
        {
            GameObject spawnPoint   = GameObject.Find(spawnPointName);
            GameObject loadedGo     = operation.GetAsset<GameObject>();
            GameObject instanceGo   = Instantiate(loadedGo) as GameObject;

            instanceGo.transform.position = spawnPoint.transform.position;
            instanceGo.transform.rotation = spawnPoint.transform.rotation;

            JLib.QuaterViewCamera quaterViewCamera = FindObjectOfType<JLib.QuaterViewCamera>();
            quaterViewCamera.SetTarget(instanceGo.transform);

            //navgation mesh off on, it will be initialize navMesh
            NavMeshAgent agent = instanceGo.GetComponent<NavMeshAgent>();
            agent.enabled = false;
            agent.enabled = true;

            int enterCinemaHash = INGAMECONST.AnimatorHash.ENTER_CINEMA;
            animator.SetTrigger(enterCinemaHash);
        }
    }
}
