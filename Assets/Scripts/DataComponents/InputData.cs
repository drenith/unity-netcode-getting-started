using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct InputData : IComponentData {
    public KeyCode forwardKey;
    public KeyCode backKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    public KeyCode upKey;

    public KeyCode resetKey;
}