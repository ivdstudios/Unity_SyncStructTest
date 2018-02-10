using UnityEngine;
using UnityEngine.Networking;

public class SyncStructTest : NetworkBehaviour
{
    #region Field

    [SyncVar]
    public Vector3 syncVector;

    [SyncVar]
    public Rect syncRect;

    #endregion Field

    #region Method

    protected void Update()
    {
        if (!base.isServer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.syncVector.x += 1;
            this.syncRect.x += 1;
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            this.syncVector = new Vector3(this.syncVector.x + 1,
                                          this.syncVector.y,
                                          this.syncVector.z);

            this.syncRect = new Rect(this.syncRect.x + 1,
                                     this.syncRect.y,
                                     this.syncRect.width,
                                     this.syncRect.height);
        }
    }

    protected void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width / 2, Screen.height / 2, 500, 500));
        GUILayout.Label("KEY 'Return' : Update Field Value.");
        GUILayout.Label("KEY 'Space'  : Update Struct Value.");
        GUILayout.Label("-");
        GUILayout.Label("Vector3  : " + this.syncVector.ToString());
        GUILayout.Label("Rect  : " + this.syncRect.ToString());
        GUILayout.EndArea();
    }


    #endregion Method
}