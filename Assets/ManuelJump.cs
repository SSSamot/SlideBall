using UnityEngine;

public class ManuelJump : MonoBehaviour
{
    public float Jump = 5f;

    private Vector2 swipeStartPosition;
    private Vector2 swipeEndPosition;
    public float minSwipeDistance = 50f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                swipeStartPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                swipeEndPosition = touch.position;
                CheckSwipe();
            }
        }
    }

    void CheckSwipe()
    {
        float swipeDistance = Vector2.Distance(swipeStartPosition, swipeEndPosition);

        if (swipeDistance >= minSwipeDistance)
        {
            if (swipeEndPosition.y > swipeStartPosition.y) // Swipe vers le haut
            {
                BallBehaviour.instance.GetComponent<Rigidbody>().velocity += new Vector3(0, Jump, 0);
            }
        }
    }
}
