#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace MornLib
{
    [CustomPropertyDrawer(typeof(MornSceneRollbackKey))]
    public class MornSceneRollbackKeyDrawer : MornEnumDrawerBase
    {
        protected override string[] Values => MornSceneGlobal.I.RollbackKeys;
        protected override Object PingTarget => MornSceneGlobal.I;
    }
}
#endif