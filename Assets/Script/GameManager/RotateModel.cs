using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    [SerializeField] private Vector3 _vector3;
   
    private void Start()
    {
        transform.DORotate(_vector3, 5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetRelative().SetEase(Ease.Linear);
    }
}
