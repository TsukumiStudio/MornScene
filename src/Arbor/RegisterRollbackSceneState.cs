#if USE_ARBOR
using Arbor;
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
