﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace GetNoodie
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : MonoBehaviour
    {
        #region Variables
        [SerializeField] private bool m_enabled = true;
        [SerializeField] private KeyCode m_jumpKey = KeyCode.Space;
        [SerializeField] private float m_movementSpeed = 10f;
        [SerializeField] private float m_jumpHeight = 3f;
        [SerializeField] private AnimationCurve m_jumpCurve = new AnimationCurve(new Keyframe(0.0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1.0f, 0f));
        [SerializeField] private List<Transform> m_wallPoints = new List<Transform>();
        [SerializeField] private int m_currentWallIndex = 0;
        [SerializeField] private List<Sprite> m_sprites = new List<Sprite>();
        [HideInInspector] [SerializeField] private Vector3 m_startPosition;
        [HideInInspector] [SerializeField] private SpriteRenderer m_spriteRenderer;
        #endregion
        #region Properties
        public Vector3 Target => CurrentWallPoint.position;
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        public List<Transform> WallPoints => m_wallPoints;
        public Transform CurrentWallPoint => WallPoints[CurrentWallIndex];
        public int CurrentWallIndex
        {
            get => m_currentWallIndex;
            set => m_currentWallIndex = Utility.LoopIndex(value, 0, WallPoints.Count - 1);
        }
        public KeyCode JumpKey => m_jumpKey;
        public float MovementSpeed => m_movementSpeed;
        public float JumpHeight => m_jumpHeight;
        public AnimationCurve JumpCurve => m_jumpCurve;
        public Vector3 StartPosition => m_startPosition;
        #endregion
        #region Methods
        private void Awake()
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void Start()
        {
            m_startPosition = transform.position;
            // Set sprite to default
            m_spriteRenderer.sprite = m_sprites[0];
        }
        private void Update()
        {
            if (Game.IsPaused)
                return;
            Jump();
            Move();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var powerup = other.GetComponent<Powerup>();
            if (powerup != null)
            {
                var value = powerup.Collect();
                Scored(value, other.transform.position);
            }
            var obstacle = other.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                GameOver();
            }
        }
        private void Jump()
        {
            if (!m_enabled)
                return;
            // Jump key is pressed
            bool isMouseButton = Input.GetMouseButtonDown(0);
            bool isPressingSpace = Input.GetKeyDown(JumpKey);
            bool isTouchingScreen = Input.touchCount > 0;
            bool isJumping = isMouseButton || isPressingSpace || isTouchingScreen;
            if (isJumping)
            {
                CurrentWallIndex++;
            }
        }
        private void Move()
        {
            var target = Target;
            var current = Position;
            var maxDelta = MovementSpeed * Time.deltaTime;
            current.x = Mathf.MoveTowards(current.x, target.x, maxDelta);
            var wallSpacing = Game.WallSpacing;
            var time = Mathf.InverseLerp(-wallSpacing, wallSpacing, current.x);
            current.y = StartPosition.y + JumpCurve.Evaluate(time) * JumpHeight;
            Position = current;
            if (Mathf.Approximately(target.x, current.x))
                m_enabled = true;
            else
                m_enabled = false;
        }
        public void Scored(int value, Vector3 hitPosition)
        {
            UI.AddBonusText(value, hitPosition);
            Game.Instance.AddScore(value);
        }
        public void GameOver()
        {
            m_spriteRenderer.sprite = m_sprites[1];
            Game.Instance.GameOver();
        }
        #endregion
    }
}