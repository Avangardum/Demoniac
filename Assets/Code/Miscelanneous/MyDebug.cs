using UnityEngine;

namespace Demoniac
{
    public static class MyDebug
    {
        private const float CrossLineSize = 0.5f;

        public static void DrawCross(Vector2 position, Color color, float duration)
        {
            Vector2 bottomLeft = position - Vector2.one * CrossLineSize / 2;
            Vector2 topRight = position + Vector2.one * CrossLineSize / 2;
            Vector2 topLeft = topRight + Vector2.left * CrossLineSize;
            Vector2 bottomRight = bottomLeft + Vector2.right * CrossLineSize;
            Debug.DrawLine(bottomLeft, topRight, color, duration, false);
            Debug.DrawLine(topLeft, bottomRight, color, duration, false);
        }
    }
}
