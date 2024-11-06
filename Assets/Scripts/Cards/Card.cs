using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public int CardID { get; private set; }
    public bool IsFlipped { get; private set; } = false;
    private bool isMatched = false;

    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            // If pointer is over UI, do nothing to avoid interacting with 3D objects
            return;
        }

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    OnTouch();
                }
            }
        }
    #endif

        // Check if there are any touches
        if (Input.touchCount > 0)
        {
            Debug.Log("touch");
            Touch touch = Input.GetTouch(0);

            // Check if this is the start of a touch
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Perform raycast to detect touch on objects with colliders
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.gameObject == gameObject)
                    {
                        // Call custom touch handler or any other code
                        OnTouch();
                    }
                }
            }
        }
    }

    public void OnTouch()
    {
        GameManager.Instance.audioManager.PlayCardFlipAudio();
        Debug.Log("Clicked" + CardID);
        if (!isMatched && !IsFlipped)
        {
            GameMechanics.Instance.OnCardSelected(this);
        }
    }

    public void Initialize(int id)
    {
        CardID = id;
    }

    public IEnumerator FlipCard(bool faceup,float delay)
    {
        
        if (!faceup)
        {
            yield return new WaitForSeconds(delay);
        }
        IsFlipped = !IsFlipped;
        GetComponent<Animator>().SetBool("Flip",IsFlipped);
        //transform.Rotate(0, 180, 0);
    }

    public IEnumerator SetMatched()
    {
        yield return new WaitForSeconds(0.2f);
        isMatched = true;
        GetComponent<Animator>().SetBool("Destroyed", true);
        //Destroy(this.gameObject);
    }
}