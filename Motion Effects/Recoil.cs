using UnityEngine;
public class Recoil : MonoBehaviour
{
    public Vector3 basePosition;
    [Header("Damping")]
    [Tooltip("How quickly the arms move with the recoil")]
    public float PositionDampTime;
    [Tooltip("How quickly the arms rotate with the recoil")]
    public float RotationDampTime;
    [Space]
    [Tooltip("How quickly the recoil moves back to zero")]
    public float returningMoveDamp;
    [Tooltip("How quickly the recoil rotates back to zero")]
    public float returningRotDamp;
    [Space(10)]
    [Tooltip("The intensity of the recoil rotation")]
    public Vector3 RecoilRotation;
    [Tooltip("The intensity of the recoil movement")]
    public Vector3 RecoilKickBack;
    public float multiplier;


    [Space]
    [Space(10)]
    private Vector3 CurrentRecoilRotation;
    private Vector3 CurrentRecoilPosition;

    private Vector3 RotationOutput;

    public void SetBasePosition(Vector3 v)
    {
        basePosition = v;
        //CurrentRecoilPosition = basePosition;
    }

    void FixedUpdate()
    {
        CurrentRecoilPosition = Vector3.Slerp(CurrentRecoilPosition, basePosition, returningMoveDamp * Time.deltaTime);
        CurrentRecoilRotation = Vector3.Slerp(CurrentRecoilRotation, Vector3.zero, returningRotDamp * Time.deltaTime);




        //Position setting
        transform.localPosition = Vector3.Slerp(transform.localPosition, CurrentRecoilPosition, PositionDampTime * Time.fixedDeltaTime);

        //Rotation setting
        RotationOutput = Vector3.Slerp(RotationOutput, CurrentRecoilRotation, RotationDampTime * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(RotationOutput);
    }

    public void Fire()
    {
        CurrentRecoilPosition += new Vector3(Random.Range(-RecoilKickBack.x, RecoilKickBack.x), Random.Range(-RecoilKickBack.y, RecoilKickBack.y), RecoilKickBack.z) * multiplier;

        CurrentRecoilRotation += new Vector3(RecoilRotation.x, Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z)) * multiplier;
    }

    public void Fire(RecoilParameters parameters)
    {
        RotationDampTime = parameters.RotationDampTime;
        returningRotDamp = parameters.returningRotDamp;

        CurrentRecoilRotation += new Vector3(parameters.RecoilRotation.x, Random.Range(-parameters.RecoilRotation.y, parameters.RecoilRotation.y), Random.Range(-parameters.RecoilRotation.z, parameters.RecoilRotation.z)) * multiplier;
    }
}

[System.Serializable]
public class RecoilParameters
{
    [Header("Damping")]
    [Tooltip("How quickly the arms rotate with the recoil")]
    public float RotationDampTime;
    [Space]
    [Tooltip("How quickly the recoil rotates back to zero")]
    public float returningRotDamp;
    [Space(10)]
    [Tooltip("The intensity of the recoil rotation")]
    public Vector3 RecoilRotation;
}