using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItweenSimpleVersion : MonoBehaviour
{
    public static void Move(GameObject Object, Transform pos, float time)
    {
        iTween.MoveTo(Object, iTween.Hash("position", pos, "time", time, "easetype", iTween.EaseType.easeInOutSine));

    }
    public static void MoveUI(GameObject Object, Transform pos, float time)
    {
        iTween.MoveTo(Object, iTween.Hash("x", pos.position.x, "y", pos.position.y, "z", pos.position.z, "time", 2, "easetype", iTween.EaseType.easeInOutSine));
    }
    

    public static void Scale(GameObject Object, float x, float y, float z, float time)
    {
        iTween.ScaleTo(Object, iTween.Hash("scale", new Vector3(x, y, z), "time", time));
    }

    public static void Rotate(GameObject Object, Transform pos, float time)
    {
        iTween.RotateTo(Object, iTween.Hash("rotation", pos, "time", time, "easetype", iTween.EaseType.easeInOutSine));

    }
}
