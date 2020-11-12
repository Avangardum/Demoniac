using System.Collections.Generic;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class SpriteStorage
    {
        private const string _squarePath = "Sprites/Square";
        private const string _circlePath = "Sprites/Circle";

        public readonly Sprite Square = Resources.Load<Sprite>(_squarePath);
        public readonly Sprite Cirlce = Resources.Load<Sprite>(_circlePath);
    }
}