using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject Player;
    private Transform _myTransform;
    private Vector3 distIni;
    private Vector3 distDin;
    #endregion
    void Start()
    {
        _myTransform = transform;
        distIni =  _myTransform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {/*
        //if(v.magnitude > 7f) _myTransform.position = v;
        
        Debug.Log(v);*/
        //dist = (Player.transform.position - _myTransform.position);
        //if (dist.magnitude > 8) _myTransform.position += dist * 0.005f;


        distDin = _myTransform.position - Player.transform.position;
        Vector3 dif_v = Vector3.Lerp(distDin, distIni, 0.001f);
        transform.position = dif_v;



        //if(dist.magnitude > 5) _myTransform.position -= dif_v;
    }
}
