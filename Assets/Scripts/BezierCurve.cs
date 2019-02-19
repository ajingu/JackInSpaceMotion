using UnityEngine;

public static class BezierCurve
{
    public static Vector3 QuadroBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        return p0 * Mathf.Pow(1 - t, 2) +
               p1 * 2 * t * (1 - t) +
               p2 * Mathf.Pow(t, 2);
    }

    public static Vector3 CubicBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        return p0 * Mathf.Pow(1 - t, 3) +
               p1 * 3 * t * Mathf.Pow(1 - t, 2) +
               p2 * 3 * Mathf.Pow(t, 2) * (1 - t) +
               p3 * Mathf.Pow(t, 3);
    }
}