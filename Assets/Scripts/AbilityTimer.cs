using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class AbilityTimer : MonoBehaviour, IPointerClickHandler
{
    public Image darkMask;
    private Image myButtonImage;
    private float abilityDuration, coolDownDuration, nextTimeForAbility, timeLeft;
    private bool pressed = false, coolDown = false;

    [SerializeField] private AbilityScript ability;
    [SerializeField] private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        Initialize(ability, player);
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed == true)
        {
            Timer();
        }
        if(coolDown == true)
        {
            CoolDown();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (nextTimeForAbility < Time.time)
        {
            AbilityStart();
        }
    }

    public void Initialize(AbilityScript selectedAbility, GameObject player)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>();
        myButtonImage.sprite = ability.sprite;
        abilityDuration = ability.duration;
        nextTimeForAbility = Time.time;
        coolDownDuration = ability.coolDown;
        darkMask.enabled = false;

        ability.Initialize(player);
    }

    public void Timer()
    {
        timeLeft = nextTimeForAbility - Time.time;
        darkMask.fillAmount = 1 - (timeLeft / abilityDuration);
        if (timeLeft < 0)
        {
            AbilityEnd();
        }
    }
    public void CoolDown()
    {
        timeLeft = nextTimeForAbility - Time.time;
        darkMask.fillAmount = (timeLeft / coolDownDuration);
        if (timeLeft < 0)
        {
            coolDown = false;
            darkMask.enabled = false;
        }
    }

    public void AbilityStart()
    {
        nextTimeForAbility = abilityDuration + Time.time;
        darkMask.enabled = true;
        ability.AbilityStart();
        pressed = true;
    }

    public void AbilityEnd()
    {
        nextTimeForAbility = Time.time + coolDownDuration;
        pressed = false;
        coolDown = true;
        ability.AbilityEnd();
    }
}
