using UnityEngine;

public class ManuelJump : MonoBehaviour
{
    private Vector2 swipeStartPosition;
    private Vector2 swipeEndPosition;

    public float Jump = 6f;
    public float minSwipeDistance = 50f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            
            if (touch.phase == TouchPhase.Began && !QTE_Manager.instance.isInJumpBoost)
            {
                swipeStartPosition = touch.position;
                
            }
            


            if (touch.phase == TouchPhase.Moved)
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
                

                    if (IsBallOnFloor())
                    {

                        BallBehaviour.instance.GetComponent<Rigidbody>().velocity += new Vector3(0, Jump, 0);
                    }

            }
        }
    }

    
    bool IsBallOnFloor()
    {
        Collider[] colliders = Physics.OverlapSphere(BallBehaviour.instance.transform.position, BallBehaviour.instance.transform.localScale.x / 2f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Floor"))
            {
                return true;
            }

        }
        return false;
    }
}
