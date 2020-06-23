using UnityEngine;

public class Ball : MonoBehaviour {
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballAudio;

    [SerializeField] float randomFactor = 0.2f;


    // state
    Vector2 paddleToBallVec;
    bool launched = false;

    // cached component reference
    AudioSource myAudioSource;
    Rigidbody2D rb;


    void Start() {
        paddleToBallVec = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!launched) {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (launched) {
            Vector2 velocityTweak = new Vector2(
                Random.Range(0f, randomFactor),
                Random.Range(0f, randomFactor)
            );
            Debug.Log(velocityTweak);
            var clip = ballAudio[Random.Range(0, ballAudio.Length)];
            myAudioSource.PlayOneShot(clip);
            rb.velocity += velocityTweak;

        }
    }

    private void LaunchOnClick() {
        if (Input.GetMouseButtonDown(0)) {
            launched = true;
            Rigidbody2D body = GetComponent<Rigidbody2D>();
            body.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle() {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVec;
    }
}
