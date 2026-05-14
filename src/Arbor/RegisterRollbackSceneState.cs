#if USE_MORNSTATE || USE_ARBOR
#if USE_MORNSTATE
using MornLib;
using StateBehaviour = MornLib.MornStateBehaviour;
#elif USE_ARBOR
using Arbor;
#endif
using System;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    public class RegisterRollbackSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneRollbackKey _key;

        public override void OnStateBegin()
        {
            _key.RegisterRollbackScene(gameObject.scene);
        }
    }
}
#endif // USE_MORNSTATE || USE_ARBOR
