using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ExpController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Exptxt;
    [SerializeField] private TextMeshProUGUI Leveltxt;
    [SerializeField] private int Level;
    public float CurrentEXP;
    [SerializeField] private float TargetEXP;
    [SerializeField] private Image EXPprocessBar;
    
    void Update()
    {   
        Exptxt.text = CurrentEXP + " / " + TargetEXP;
        xpController();
    }
    public void xpController(){
        Leveltxt.text = "Level : " + Level.ToString();
        EXPprocessBar.fillAmount = (CurrentEXP / TargetEXP);
        if(CurrentEXP >=TargetEXP){
            CurrentEXP = CurrentEXP - TargetEXP;
            TargetEXP *=2;
            Level++;
        }
    }
}
