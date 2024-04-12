using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class BackGroundMovement : MonoBehaviour
{
    [SerializeField] RectTransform image1;
    [SerializeField] RectTransform image2;
  
    [SerializeField] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        image1.DOAnchorPosY(0f, speed).SetEase(Ease.Linear).SetLoops(-1,LoopType.Restart);
        image2.DOAnchorPosY(-6024.2f, speed).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

}
