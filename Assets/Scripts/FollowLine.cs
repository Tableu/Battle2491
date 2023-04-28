using UnityEngine;

public class FollowLine : MonoBehaviour
{
    public LineRenderer Line;
    public float Speed;
    private int posIndex;
    private int maxIndex;
    // Start is called before the first frame update
    void Start()
    {
        posIndex = 0;
        maxIndex = Line.positionCount;
    }

    private void FixedUpdate()
    {
        if (posIndex < maxIndex)
        {
            Vector2 pos = Line.GetPosition(posIndex);
            transform.position = Vector2.MoveTowards(transform.position, pos, Speed);
            
            transform.LookAt(pos);
            transform.right = pos - (Vector2)transform.position;
            if (transform.position.Equals(pos))
            {
                posIndex++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
