using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;

public class SoliderHUD : MonoBehaviour
{
    
    public Slider Slider_HP;
    public Image SliderImage_Hp;
    public TextMeshProUGUI Text_HP;
    private BaseObject Parent;
    public void Init(BaseObject parent)
    {
        Parent = parent;
        var camp = parent.GetBaseObjectCamp();
        SliderImage_Hp.color = Commmon_Color.HPBarColor(Parent,camp);
    }

    public void UpdatgeHP(float CurHP,float MaxHP)
    {
        Slider_HP.value = CurHP / MaxHP;
        Text_HP.text = string.Format("%d/%d", CurHP, MaxHP);
    }
    
    private void LateUpdate()
    {
        this.transform.forward = Camera.main.transform.forward;
    }
}