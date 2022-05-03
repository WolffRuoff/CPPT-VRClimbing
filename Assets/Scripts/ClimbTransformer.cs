/************************************************************************************
Copyright : Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.

Your use of this SDK or tool is subject to the Oculus SDK License Agreement, available at
https://developer.oculus.com/licenses/oculussdk/

Unless required by applicable law or agreed to in writing, the Utilities SDK distributed
under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
ANY KIND, either express or implied. See the License for the specific language governing
permissions and limitations under the License.
************************************************************************************/

using Oculus.Interaction.Grab;
using UnityEngine;

namespace Oculus.Interaction
{
    /// <summary>
    /// A Transformer that moves the oculus camera in a 1-1 fashion inverted with the GrabPoint.
    /// Updates transform the target in such a way as to maintain the target's
    /// local positional and rotational offsets from the GrabPoint.
    /// </summary>
    public class ClimbTransformer : MonoBehaviour, ITransformer
    {

        private IGrabbable _grabbable;
        private GameObject lHand;
        private GameObject rHand;
        private GameObject currentHand;
        private Vector3 initialHandPos;
        private GameObject player;

        public void Initialize(IGrabbable grabbable)
        {
            _grabbable = grabbable;
            lHand = GameObject.FindGameObjectWithTag("LHandAnchor");
            rHand = GameObject.FindGameObjectWithTag("RHandAnchor");
            player = GameObject.FindGameObjectWithTag("Player");
        }

        public void BeginTransform()
        {
            SetGrabbingHand();
            initialHandPos = currentHand.transform.position;

            Destroy(this.gameObject.GetComponent<Outline>());

            Outline outline;

            // TODO: clean up switch statement section below (added for wayfinding)
            switch(_grabbable.Transform.gameObject.name) {
                case "E1":
                    outline = GameObject.Find("E2").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E2":
                    outline = GameObject.Find("E3").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E3":
                    outline = GameObject.Find("E4").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E4":
                    outline = GameObject.Find("E5").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E5":
                    outline = GameObject.Find("E6").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E6":
                    outline = GameObject.Find("E7").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E7":
                    outline = GameObject.Find("E8").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E8":
                    outline = GameObject.Find("E9").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E9":
                    outline = GameObject.Find("E10").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E10":
                    outline = GameObject.Find("E11").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E11":
                    outline = GameObject.Find("E12").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E12":
                    outline = GameObject.Find("E13").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E13":
                    outline = GameObject.Find("E14").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E14":
                    outline = GameObject.Find("E15").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "E15":
                    outline = GameObject.Find("E16").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M1":
                    outline = GameObject.Find("M2").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M2":
                    outline = GameObject.Find("M3").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M3":
                    outline = GameObject.Find("M4").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M4":
                    outline = GameObject.Find("M5").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M5":
                    outline = GameObject.Find("M6").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M6":
                    outline = GameObject.Find("M7").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M7":
                    outline = GameObject.Find("M8").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M8":
                    outline = GameObject.Find("M9").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M9":
                    outline = GameObject.Find("M10").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M10":
                    outline = GameObject.Find("M11").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M11":
                    outline = GameObject.Find("M12").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M12":
                    outline = GameObject.Find("M13").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "M13":
                    outline = GameObject.Find("M14").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "H1":
                    outline = GameObject.Find("H2").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "H2":
                    outline = GameObject.Find("H3").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "H3":
                    outline = GameObject.Find("H4").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "H4":
                    outline = GameObject.Find("H5").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "H5":
                    outline = GameObject.Find("H6").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "H6":
                    outline = GameObject.Find("H7").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "H7":
                    outline = GameObject.Find("H8").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "H8":
                    outline = GameObject.Find("H9").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "H9":
                    outline = GameObject.Find("H10").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                case "H10":
                    outline = GameObject.Find("H11").AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.yellow;
                    outline.OutlineWidth = 50f;
                    break;
                default:
                    break;
            }

        }

        public void UpdateTransform()
        {
            Vector3 worldOffsetFromGrab = initialHandPos - currentHand.transform.position;

            player.transform.position += worldOffsetFromGrab;
            currentHand.transform.position = initialHandPos;
        }

        public void EndTransform() {
        }

        private void SetGrabbingHand()
        {
            foreach (GameObject hand in GameObject.FindGameObjectsWithTag("GrabInteractor"))
            {
                if (hand.GetComponent<IHandGrabInteractor>().HandGrabApi.transform.GetPose().Equals(_grabbable.GrabPoints[0])) {
                    if (hand.name.Contains("Left"))
                    {
                        currentHand = lHand;
                    }
                    else
                    {
                        currentHand = rHand;
                    }
                }
                else
                {
                    Debug.Log("Unselecting " + hand.name);
                    hand.GetComponent<IInteractor>().Unselect();
                }
            }
        }
    }
}
