using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying = false;
    private bool _isRecording = true;
    private PlayerMovement _playermovement;
    private Command _buttonLeft, _buttonRight;

    private void OnEnable()
    {
        EventBus.Subscribe(EventType.RECORD, Record);
        EventBus.Subscribe(EventType.REPLAY, Replay);
        _invoker = gameObject.AddComponent<Invoker>();
        _playermovement = FindObjectOfType<PlayerMovement>();

        _buttonLeft = new MoveLeft(_playermovement);
        _buttonRight = new MoveRight(_playermovement);

        _invoker.Record();
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(EventType.RECORD, Record);
        EventBus.Unsubscribe(EventType.REPLAY, Replay);
    }

    /*void Start()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        _playermovement = FindObjectOfType<PlayerMovement>();

        _buttonLeft = new MoveLeft(_playermovement);
        _buttonRight = new MoveRight(_playermovement);
    }
    */
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

    public void Record()
    {
        _isRecording = true;
        _isReplaying = false;
        _invoker.Record();
    }

    public void Replay()
    {
        _isRecording = false;
        _isReplaying = true;
        _invoker.Replay();
    }

    //void OnGUI()
    //{
    //    if(GUILayout.Button("Start Recording"))
    //    {
    //        _playermovement.ResetPosition();
    //        _isReplaying = false;
    //        _isRecording = true;
    //        _invoker.Record();
    //    }
    //    if(GUILayout.Button("Stop Recording"))
    //    {
    //        _playermovement.ResetPosition();
    //        _isRecording = false;
    //    }
    //    if(!_isRecording)
    //    {
    //        if (GUILayout.Button("Start Replay"))
    //        {
    //            _playermovement.ResetPosition();
    //            _isRecording = false;
    //            _isReplaying = true;
    //            _invoker.Replay();
    //        }
    //    }

    //}
}
