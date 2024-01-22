using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
     public GameObject player;
    [SerializeField]
    private GameObject interactText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //description: Will update the player's display text to show the stored string inside an interacted item, then set the string to active for a period in time
   public IEnumerator UpdateText(string itemText)
    {
        Text text = interactText.GetComponent<Text>();
        text.text = itemText;
        //reads the stored text in the interacted item
        interactText.SetActive(true);
        yield return new WaitForSeconds(5);
        interactText.SetActive(false);
        //turns on the object for a handful of seconds 
    }
}
