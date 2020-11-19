﻿using System;
using System.Linq;
using Demoniac.PlayerInputSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public class PlayerCharacter : GameEntity
    {
        private const float Gravity = -20f;
        private const float MAXVerticalSpeed = 8f;
        private const float MAXHorizontalSpeed = 10f;
        private const float MoveAcceleration = 20f;
        private const float BreakAcceleration = 50f;
        private const float InitialJumpSpeed = 8f;
        private const float MAXJumpTime = 0.3f;
        
        private PlayerInputSubsystemFacade _playerInput;
        private Vector2 _velocity;
        private bool _isPushingLeftWall;
        private bool _isPushingRightWall;
        private bool _isGrounded;
        private bool _isAtCeiling;
        private bool _isJumping;
        private Vector2 _oldPosition;
        private Vector2 _oldVelocity;
        private bool _wasPushingLeftWall;
        private bool _wasPushingRightWall;
        private bool _wasGrounded;
        private bool _wasAtCeiling;
        private float _currentJumpTime;
        
        public PlayerCharacter(Vector2 position, PlayerInputSubsystemFacade playerInput) : base(position)
        {
            _playerInput = playerInput;
        }

        public override void FrameAction(float frameTime)
        {
            base.FrameAction(frameTime);

            //сохранение изначальных данных
            _oldPosition = Position;
            _oldVelocity = _velocity;
            _wasPushingLeftWall = _isPushingLeftWall;
            _wasPushingRightWall = _isPushingRightWall;
            _wasGrounded = _isGrounded;
            _wasAtCeiling = _isAtCeiling;

            //проверка на приземлённость
            if (Position.y < 0)
            {
                Position = new Vector2(Position.x, 0);
                _isGrounded = true;
            }
            else
            {
                _isGrounded = false;
            }
            
            //рассчёт скорости по x
            float maxXVelocityDelta = MoveAcceleration * frameTime;
            float maxXBreakVelocityDelta = BreakAcceleration * frameTime;
            float desiredXVelocity = MAXHorizontalSpeed * _playerInput.Horisontal;
            if (desiredXVelocity > _velocity.x)
            {
                _velocity.x += _velocity.x < 0 ? maxXBreakVelocityDelta : maxXVelocityDelta;
                if (_velocity.x > desiredXVelocity)
                {
                    _velocity.x = desiredXVelocity;
                }
            }
            else if (desiredXVelocity < _velocity.x)
            {
                _velocity.x -= _velocity.x > 0 ? maxXBreakVelocityDelta : maxXVelocityDelta;
                if (_velocity.x < desiredXVelocity)
                {
                    _velocity.x = desiredXVelocity;
                }
            }
            _velocity.x = Mathf.Clamp(_velocity.x, -MAXHorizontalSpeed, MAXHorizontalSpeed);
            
            //рассчёт скорости по y
            if (!_isGrounded)
                _velocity.y += Gravity * frameTime;
            if (_playerInput.JumpDown && _isGrounded)
            {
                _isJumping = true;
                _currentJumpTime = 0f;
            }
            if (_isJumping)
            {
                if (_playerInput.JumpPressed)
                {
                    _velocity.y = InitialJumpSpeed;
                    _currentJumpTime += frameTime;
                    if (_currentJumpTime >= MAXJumpTime)
                        _isJumping = false;
                }
                else
                {
                    _isJumping = false;
                }
            }

            _velocity.y = Mathf.Clamp(_velocity.y, -MAXVerticalSpeed, MAXVerticalSpeed);
            
            Move(_velocity * frameTime);
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
