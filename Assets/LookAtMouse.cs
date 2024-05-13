using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Transform m_transform;

    void Start()
    {
        m_transform = this.transform;
    }

    void Update()
    {
        LAMouse();
    }

    private void LAMouse()
    {
        var dir =
            Input.mousePosition -
            Camera.main.WorldToScreenPoint(m_transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        m_transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
