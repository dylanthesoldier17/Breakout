using Core;
using UnityEngine;

namespace Controllers
{
    public class PaddleMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D paddleRigidBody;
        [SerializeField] private FloatVariable bounds;
        [SerializeField] private FloatVariable speed;
        private Vector2 _leftBoundsPosition;
        private Vector2 _rightBoundsPosition;

        private void Start()
        {
            float yPos = transform.position.y;
            _leftBoundsPosition = new Vector2(-bounds.GetValue(), yPos);
            _rightBoundsPosition = new Vector2(bounds.GetValue(), yPos);
        }
        private void Update()
        {
            float axisInput = Input.GetAxis("Horizontal");

            _restrictLeftBounds();
            _restrictRightBounds();
        
            paddleRigidBody.velocity = Vector2.right * axisInput * speed.GetValue();
        }

        private void _restrictLeftBounds()
        {
            if (transform.position.x < -bounds.GetValue())
                transform.position = _leftBoundsPosition;
        }
        private void _restrictRightBounds()
        {
            if (transform.position.x > bounds.GetValue())
                transform.position = _rightBoundsPosition;
        }
    }
}
