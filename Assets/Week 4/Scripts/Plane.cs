using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    Vector3 lastPosition;
    public float pointThreshold = 0.2f;
    LineRenderer lineRenderer;
    public float speed = 1f;
    public AnimationCurve landing;
    float landingTimer = 0;
    public Sprite[] sprites;

    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        if(TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer)){
            spriteRenderer.sprite = sprites[(int)Random.Range(0,4)];
        }
        speed = Random.Range(0.5f, 2f);
    }
    
    void OnMouseDown() {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        lineRenderer.SetPosition(0, mousePos);
    } 

    void OnMouseDrag() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if(lastPosition != null && Vector3.Distance(mousePos, lastPosition) > pointThreshold) {
            points.Add(new Vector2(mousePos.x, mousePos.y));
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePos);
            lastPosition = mousePos;
        }
    }

    void Update() {
        Vector2 pos2 = new Vector2(transform.position.x, transform.position.y);
        if(lineRenderer.positionCount > 0){
            Vector2 linePos = lineRenderer.GetPosition(0);
            Vector2 direction = new Vector2(linePos.x - pos2.x, linePos.y - pos2.y);
            float rotationTarget = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x) - 90;
            transform.Rotate(0, 0, (rotationTarget - transform.eulerAngles.z));
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(lineRenderer.positionCount > 0 && Vector2.Distance(pos2, lineRenderer.GetPosition(0)) < pointThreshold){
            for(int i = 1; i < lineRenderer.positionCount; i++){
                lineRenderer.SetPosition(i-1, lineRenderer.GetPosition(i));
            }
            lineRenderer.positionCount--;
        }

        if(Input.GetKey(KeyCode.Space)){
            landingTimer += 0.3f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.z < 0.3f){
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation) * 3;
        }
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(){
        if(TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer)){
            spriteRenderer.color = Color.red;
        }
    }

    void OnTriggerExit2D(){
        if(TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer)){
            spriteRenderer.color = Color.white;
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(Vector3.Distance(transform.position, other.transform.position) < 0.5f){
            Destroy(this.gameObject);
        }
    }
}