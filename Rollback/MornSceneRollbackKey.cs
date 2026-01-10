using System;
using MornEnum;

namespace MornLib
{
    [Serializable]
    public sealed class MornSceneRollbackKey : MornEnumBase
    {
        protected override string[] Values => MornSceneGlobal.I.RollbackKeys;
    }
}