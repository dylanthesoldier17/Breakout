using System.Collections;
using Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D ballRigidbody2D;
        [SerializeField] private FloatVariable spawnDirection;
        [SerializeField] private FloatVariable spawnDirectionExclude;
        [SerializeField] private FloatVariable speed;
        [SerializeField] private FloatVariable startDelayInSeconds;
        [SerializeField] private FloatVariable bounds;
        private Ball _ball;
        
        private void Start()
        {
            _ball = new Ball(ballRigidbody2D, transform, Vector2.zero);
            ResetBall();
        }
        private void Update()
        {
            if(_isOutOfBounds(bounds.GetValue()))
                ResetBall();

            _limitSpeed();
        }
        
        public void ResetBall()
        {
            _ball.StopMovement();
            _ball.ResetPosition();
            Vector2 randomDirection = _getRandomDirection() * speed.GetValue();
            StartCoroutine(_ball.LaunchCO(randomDirection, startDelayInSeconds.GetValue()));
        }
        
        private Vector2 _getRandomDirection()
        {
            float randomX = _getRandomXPosition(spawnDirection.GetValue(), spawnDirectionExclude.GetValue());
            return new Vector2(randomX,-2).normalized;
        }
        private float _getRandomXPosition(float boundsPosition, float exlusionArea)
        {
            float randomX;
            float triggerRange = Random.Range(-boundsPosition, boundsPosition);
        
            if (triggerRange >= 0)
            {
                randomX = Random.Range(boundsPosition, exlusionArea);
            }
            else
            {
                randomX = Random.Range(-boundsPosition, -exlusionArea);
            }

            return randomX;
        }
        private bool _isOutOfBounds(float boundsPosition)
        {
            float xPos = transform.position.x;
            
            bool pastLeftBoundary = xPos < -boundsPosition;
            bool pastRightBoundary = xPos > boundsPosition;

            if (pastLeftBoundary || pastRightBoundary)
                return true;

            return false;
        }
        private void _limitSpeed()
        {
            bool overSpeed = ballRigidbody2D.velocity.magnitude > speed.GetValue();
            if (overSpeed)
                ballRigidbody2D.velocity = ballRigidbody2D.velocity.normalized * speed.GetValue();
        }
    }

    internal class Ball
    {
        private readonly Rigidbody2D _rigidbody2D;
        private readonly Transform _transform;
        private readonly Vector2 _startingPosition;
        
        public Ball(Rigidbody2D rigidbody2D, Transform transform, Vector2 startingPosition)
        {
            _rigidbody2D = rigidbody2D;
            _startingPosition = startingPosition;
            _transform = transform;
        }
        
        public void ResetPosition()
        {
            _transform.position = _startingPosition;
        }
        public IEnumerator LaunchCO(Vector2 direction, float delayInSeconds)
        {
            yield return new WaitForSeconds(delayInSeconds);
            _rigidbody2D.velocity = direction;
        }
        public void StopMovement()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}

