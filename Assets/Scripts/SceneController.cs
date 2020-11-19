using UnityEngine;

namespace Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {
        public enum GameState
        {
            inBalloon,
            isWalking
        }

        public GameState gameState;
        public Transform OvrCamRig;
        public Transform OutAnchor;
        public Transform BasketAnchor;

        public Transform CharacterCont;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                switch (gameState)
                {
                    case GameState.inBalloon:
                    {
                        Debug.Log("inBaolon to isWalking");

                        CharacterCont.gameObject.SetActive(false);
                        CharacterCont.position = OutAnchor.position;
                        CharacterCont.gameObject.SetActive(true);
                        Debug.Log(OutAnchor.position);
                        OvrCamRig.parent = CharacterCont;
                        OvrCamRig.localPosition = Vector3.zero;
                        OvrCamRig.rotation = Quaternion.Euler(0,0,0);
                        OvrCamRig.GetComponent<OVRScreenFade>().FadeIn();
                        gameState = GameState.isWalking;
                        break;
                    }

                    case GameState.isWalking:
                    {
                        Debug.Log("isWalkling to inBaolon");
                        OvrCamRig.parent = BasketAnchor.parent;
                        OvrCamRig.GetComponent<OVRScreenFade>().FadeIn();
                        OvrCamRig.position = BasketAnchor.position;
                        OvrCamRig.rotation = Quaternion.Euler(0,0,0);
                        CharacterCont.gameObject.SetActive(false);
                        gameState = GameState.inBalloon;

                        break;

                    }

                }
            }

        }
    }
}
