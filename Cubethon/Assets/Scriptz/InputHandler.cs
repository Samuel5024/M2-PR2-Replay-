using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying;
    private bool _isRecording;
    private PlayerMovement _playermovement;
    private Command _buttonLeft, _buttonRight;

    void Start()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        _playermovement = FindObjectOfType<PlayerMovement>();

        _buttonLeft = new MoveLeft(_playermovement);
        _buttonRight = new MoveRight(_playermovement);
    }
    void Update()
    {
        if(!_isReplaying && _isRecording)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                _invoker.ExecuteCommand(_buttonLeft);
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                _invoker.ExecuteCommand(_buttonRight);
            }
        }
    }

    void OnGUI()
    {
        if(GUILayout.Button("Start Recording"))
        {
            _playermovement.ResetPosition();
            _isReplaying = false;
            _isRecording = true;
            _invoker.Record();
        }
        if(GUILayout.Button("Stop Recording"))
        {
            _playermovement.ResetPosition();
            _isRecording = false;
        }
        if(!_isRecording)
        {
            if (GUILayout.Button("Start Replay"))
            {
                _playermovement.ResetPosition();
                _isRecording = false;
                _isReplaying = true;
                _invoker.Replay();
            }
        }

    }
}
