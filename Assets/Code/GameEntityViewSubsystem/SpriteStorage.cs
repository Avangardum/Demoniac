using System.Collections.Generic;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class SpriteStorage
    {
        private const string SquarePath = "Sprites/Square";
        private const string CirclePath = "Sprites/Circle";

        public readonly Sprite Square = Resources.Load<Sprite>(SquarePath);
        public readonly Sprite Cirlce = Resources.Load<Sprite>(CirclePath);
    }
}