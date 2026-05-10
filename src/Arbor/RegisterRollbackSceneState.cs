#if USE_ARBOR || USE_MORNSTATE
#if USE_ARBOR
using Arbor;
#elif USE_MORNSTATE
using MornLib;
using StateBehaviour = MornLib.MornStateBehaviour;
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
#endif
