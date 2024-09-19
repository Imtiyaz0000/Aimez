using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableTarget : MonoBehaviour
{
    public void OnHit()
    {
        SendMessage("HandleHit", SendMessageOptions.DontRequireReceiver);
    }
}
