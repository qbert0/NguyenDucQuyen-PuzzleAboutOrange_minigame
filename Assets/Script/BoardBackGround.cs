using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBackGround : MonoBehaviour
{
    SpriteRenderer spriteRenderer;


    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void UpdateLocation(float height, float width, Vector3 center) {
        Vector2 targetSize = new Vector2( 4 ,3);
        Debug.Log("spri  ");

        this.transform.position = center;
        Debug.Log("spri  ");

        Vector2 spriteSize = this.spriteRenderer.bounds.size;

        Debug.Log("spri  " + spriteSize);

        Vector3 scale = this.transform.localScale;
        scale.x = height / spriteSize.x + 0.12f;
        scale.y = width / spriteSize.y + 0.15f;
        this.transform.localScale = scale;

        spriteSize = spriteRenderer.bounds.size;
        Debug.Log("spri  " + spriteSize);
    }

}
