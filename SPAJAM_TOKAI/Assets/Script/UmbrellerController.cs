using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellerController : MonoBehaviour
{
    [SerializeField]
    Vector2 _position;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = _position;
    }

    public void SetPosition(Vector2 pos)
    {
        _position = pos;
    }

    public Vector2 GetPosition()
    {
        return _position;
    }
}
