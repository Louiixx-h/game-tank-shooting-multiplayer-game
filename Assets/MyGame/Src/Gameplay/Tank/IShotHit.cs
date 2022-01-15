using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Src.Gameplay
{
    public interface IShotHit
    {
        void Hit(Vector3 direction);
    }
}
