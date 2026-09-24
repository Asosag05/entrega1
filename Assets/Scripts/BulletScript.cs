using UnityEngine;

public class Bullet : MonoBehaviour
{
    int speed = 10;
    float maxLifeTime = 3;
    public Vector3 targetVector;
    Meteorite meteoro;

    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    void Update()
    {
        transform.Translate(targetVector * speed * Time.deltaTime, Space.World);
    }

  private void OnTriggerEnter2D(Collider2D other)
  {
      if (other.gameObject.tag == "Enemy"){
        meteoro = other.gameObject.GetComponent<Meteorite>();
        if(meteoro != null)
            meteoro.Die();
        else 
          Destroy(other.gameObject);
          
        Destroy(gameObject);
        ScoreManager.Instance.AddPoint();
      }
  }
}

