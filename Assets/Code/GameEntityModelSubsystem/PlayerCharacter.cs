using System;
using System.Linq;
using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public class PlayerCharacter : GameEntity
    {
        private const float Gravity = -9.8f;
        private const float MAXVerticalSpeedAbs = 10;

        private const int MAXOverlapCheckIterations = 10;

        private Vector2 _velocity;
        
        public PlayerCharacter(Vector2 position) : base(position)
        {
        }

        public override void FrameAction(float frameTime)
        {
            base.FrameAction(frameTime);


            //Рассчёт скорости
            _velocity.y += Gravity * frameTime;
            _velocity.y = Mathf.Clamp(_velocity.y, -MAXVerticalSpeedAbs, MAXVerticalSpeedAbs);

            //Рассчёт перемещения
            Vector2 movement = _velocity * frameTime;
            Vector2 originalMovement = movement;

            //Проверка пересечений и коррекция перемещения для их избежания
            int overlapCheckIterations = 0;
            while (true)
            {
                Vector2 assumedPosition = Position + movement;
                var solidTerrainElements = Storage.Where(x => x is SolidTerrainElement);
                GameEntity overlappingTerrainElement =
                    solidTerrainElements.FirstOrDefault(x => OverlapsAssumePosition(x, assumedPosition));
                if (overlappingTerrainElement == null)
                    break;
                Vector2 overlapAmmount = OverlapAmountAssumePosition(overlappingTerrainElement, assumedPosition);
                movement = ShortenVector2(movement, overlapAmmount);

                overlapCheckIterations++;
                if (overlapCheckIterations > MAXOverlapCheckIterations)
                {
                    throw new Exception("Превышено допустимое количесво итераций избежания столкновений");
                }
            }

            //Применение перемещения
            Move(movement);

            if (movement.x != originalMovement.x)
            {
                _velocity.x = 0;
            }

            if (movement.y != originalMovement.y)
            {
                _velocity.y = 0;
            }
        }

        private Vector2 ShortenVector2(Vector2 vector, Vector2 shortening)
        {
            if (vector.x > 0)
            {
                vector.x -= shortening.x;
                if (vector.x < 0)
                    vector.x = 0;
            }
            else if (vector.x < 0)
            {
                vector.x += shortening.x;
                if (vector.x > 0)
                {
                    vector.x = 0;
                }
            }
            
            if (vector.y > 0)
            {
                vector.y -= shortening.y;
                if (vector.y < 0)
                    vector.y = 0;
            }
            else if (vector.y < 0)
            {
                vector.y += shortening.y;
                if (vector.y > 0)
                {
                    vector.y = 0;
                }
            }

            return vector;
        }

        private void Squeeze()
        {
            Die();
        }

        private void Die()
        {
            Delete();
        }
    } 
}
