using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CameraMover mover;
    [SerializeField] Transform[] dstTransforms;

    int index = 0;
    int indices;

    void Start()
    {
        indices = dstTransforms.Length;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            mover.JackOut();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            index = (index + 1) % indices;
            mover.JackIn(dstTransforms[index]);
        }
    }
}
