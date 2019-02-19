using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] Camera targetCamera;
    [SerializeField] Transform originTransform;

    public void JackOut()
    {
        Vector3 p0 = targetCamera.transform.position;
        Vector3 p1 = p0 - targetCamera.transform.forward * 5f;
        Vector3 p2 = p1 + Vector3.up * 5f;

        Quaternion startQuaternion = targetCamera.transform.rotation;

        float t = 0.0f;
        this.UpdateAsObservable()
            .Select(_ => t = Mathf.Lerp(t, 1.0f, 0.05f))
            .TakeWhile(_ => 1.0f - t > 1e-5)
            .Subscribe(_ =>
            {
                targetCamera.transform.position = BezierCurve.QuadroBezierCurve(p0, p1, p2, t);
                targetCamera.transform.LookAt(originTransform, targetCamera.transform.up);
            })
            .AddTo(gameObject);
    }

    public void JackIn(Transform dstTransform)
    {
        Vector3 p0 = targetCamera.transform.position;
        Vector3 p1 = p0 + targetCamera.transform.forward * 2f;
        Vector3 p3 = dstTransform.position;
        Vector3 p2 = p3 - dstTransform.forward * 5f;
        
        Quaternion dstQuaternion = dstTransform.transform.rotation;

        float t = 0.0f;
        this.UpdateAsObservable()
            .Select(_ => t = Mathf.Lerp(t, 1.0f, 0.05f))
            .TakeWhile(_ => 1.0f - t > 1e-5)
            .Subscribe(_ =>
            {
                targetCamera.transform.position = BezierCurve.CubicBezierCurve(p0, p1, p2, p3, t);
                targetCamera.transform.rotation = Quaternion.Slerp(targetCamera.transform.rotation, dstQuaternion, t);
            })
            .AddTo(gameObject);
    }
}
