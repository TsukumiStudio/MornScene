#if UNITY_EDITOR
using MornEnum;
using UnityEditor;
using UnityEngine;

namespace MornScene
{
    [CustomPropertyDrawer(typeof(MornSceneRollbackKey))]
    public class MornSceneRollbackKeyDrawer : MornEnumDrawerBase
    {
        protected override string[] Values => MornSceneGlobal.I.RollbackKeys;
        protected override Object PingTarget => MornSceneGlobal.I;
    }
}
#endif