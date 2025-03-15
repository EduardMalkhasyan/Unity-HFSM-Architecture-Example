using Sirenix.OdinInspector;
using Sirenix.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{
    public class CreditCard : MonoBehaviour
    {
        [SerializeField] private Button linkButton;
        [SerializeField] private TextMeshProUGUI creatorNameText;
        [SerializeField] private TextMeshProUGUI creatorWorkText;
        [SerializeField, ReadOnly] private string link;

        public void Setup(string creatorName, string creatorWork, string link = null)
        {
            creatorNameText.text = creatorName;
            creatorWorkText.text = creatorWork;

            linkButton.gameObject.SetActive(link != null);

            if (link.IsNullOrWhitespace() == false)
            {
                this.link = link;

                linkButton.onClick.AddListener(() =>
                {
                    Application.OpenURL(this.link);
                });
            }
            else
            {
                linkButton.gameObject.SetActive(false);
            }
        }

        public void UpdateWorkName(string creatorWork)
        {
            creatorWorkText.text = creatorWork;
        }
    }
}
