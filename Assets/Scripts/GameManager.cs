using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CameraMover mover;
    [SerializeField] Transform[] dstTransforms;

    int index = 1;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            mover.JackOut();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            mover.JackIn(dstTransforms[index]);
            index = (index + 1) % 2;
        }
    }
}
