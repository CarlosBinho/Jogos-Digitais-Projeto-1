using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnguiaControler : MonoBehaviour
{

    public float         _moveSpeedEnguia = 5.0f;
    private Vector2      _enguiaDirection;
    private Rigidbody2D  _enguiaRB2D;

    public DetectionController _detectionArea;

    private SpriteRenderer     _spriteRenderer;

    private DetectionController _detectionController;



    // Start is called before the first frame update
    void Start()
    {
        _enguiaRB2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _detectionController = FindObjectOfType(typeof(DetectionController)) as DetectionController;
    }

    // Update is called once per frame
    void Update()
    {
        _enguiaDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        _detectionController.detectedObjs.RemoveAll(item => item == null);  // Remove qualquer referência nula da lista

        if (_detectionArea.detectedObjs.Count > 0)
        {
            Vector3 targetPosition = _detectionArea.detectedObjs[0].transform.position;

            _enguiaDirection = (targetPosition - transform.position).normalized;

            _enguiaRB2D.MovePosition(_enguiaRB2D.position + _enguiaDirection * _moveSpeedEnguia * Time.fixedDeltaTime);

            // Lógica para virar a sprite baseada na direção
            _spriteRenderer.flipX = _enguiaDirection.x < 0;

            if (_enguiaDirection.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if(_enguiaDirection.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
        }
    }

}
