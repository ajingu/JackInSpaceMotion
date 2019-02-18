using UnityEngine;

public static class BezierCurve
{
    static Vector3 QuadroBezierCurve(Vector3[] controllPoints, float t)
    {
        return controllPoints[0] * Mathf.Pow(1 - t, 2) +
               controllPoints[1] * 2 * t * (1 - t) +
               controllPoints[2] * Mathf.Pow(t, 2);
    }

    static Vector3 CubicBezierCurve(Vector3[] controllPoints, float t)
    {
        return controllPoints[0] * Mathf.Pow(1 - t, 3) +
               controllPoints[1] * 3 * t * Mathf.Pow(1 - t, 2) +
               controllPoints[2] * 3 * Mathf.Pow(t, 2) * (1 - t) +
               controllPoints[3] * Mathf.Pow(t, 3);
    }
}
