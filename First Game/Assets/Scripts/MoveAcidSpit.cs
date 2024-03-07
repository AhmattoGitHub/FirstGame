using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAcidSpit : MonoBehaviour
{
    private bool m_isDescending = false;
    private float m_launchHeight = 15;

    [SerializeField]
    private GameObject m_playerObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(this.transform.position, m_playerObject.transform.position) >= m_launchHeight)
        {
            m_isDescending=true;
            float xDistanceBetweenCursorAndSpit = Mathf.Abs(this.transform.position.x - TestPlayerPowersManager.Instance.GetClickPosition().x);

            if (this.transform.position.x != TestPlayerPowersManager.Instance.GetClickPosition().x)
                this.transform.Translate(new Vector2(xDistanceBetweenCursorAndSpit, 0));
        }
    }

    private void FixedUpdate()
    {
        if (!m_isDescending)
            LaunchToSky();
        else
            DescendFromSky();
    }

    private void LaunchToSky()
    {
        this.transform.Translate(Vector2.up * m_launchHeight * Time.fixedDeltaTime);
    }

    private void DescendFromSky()
    {
        this.transform.Translate(Vector2.down * m_launchHeight * Time.fixedDeltaTime);
    }
}
