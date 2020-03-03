using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    [SerializeField] Material myMaterial;
    [SerializeField] float scrollSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset = new Vector2(0f, myMaterial.mainTextureOffset.y + (scrollSpeed * Time.deltaTime));
    }
}
