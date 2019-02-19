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

        if (Input.GetKeyDown(KeyCode.L))
        {
            index = (index + 2) % indices;
            mover.JackIn(dstTransforms[index]);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            index = (index + 1) % indices;
            mover.JackIn(dstTransforms[index]);
        }
    }
}
