#if USE_ARBOR
using Arbor;
using UnityEngine;

namespace MornLib
{
    public class RegisterRollbackSceneState : StateBehaviour
    {
        [SerializeField] private MornSceneRollbackKey _key;

        public override void OnStateBegin()
        {
            MornSceneService.I.RegisterRollbackScene(_key, gameObject.scene);
        }
    }
}
#endif