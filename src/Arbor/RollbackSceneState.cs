#if USE_ARBOR
using Arbor;
#else
using MornLib;
using StateBehaviour = MornLib.MornStateBehaviour;
#endif
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MornLib
{
    [Serializable]
    public class RollbackSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneRollbackKey _key;
        [SerializeField] private LoadSceneMode _loadSceneMode;

        public override void OnStateBegin()
        {
            if (_key.TryGetRollbackScene(out var sceneName))
            {
                SceneManager.LoadSceneAsync(sceneName, _loadSceneMode);
            }
            else
            {
                MornSceneGlobal.Logger.LogError($"RollbackSceneAction: Not found scene key: {_key}");
            }
        }
    }
}
