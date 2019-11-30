using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class AbilityTimer : MonoBehaviour, IPointerClickHandler
{
    public Image darkMask;
    private Image myButtonImage;
    private float timerDuration;
    private float timeLeft;
    private bool pressed = false;

    [SerializeField] private AbilityScript ability;
    [SerializeField] private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        Initialize(ability, player);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AbilityStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed == true)
        {
            Timer();
        }
    }

    public void Initialize(AbilityScript selectedAbility, GameObject player)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>();
        myButtonImage.sprite = ability.sprite;
        timerDuration = ability.timer;
        ability.Initialize(player);
        darkMask.enabled = false;
    }

    public void Timer()
    {
        timeLeft -= Time.deltaTime;
        float roundedTimeLeft = Mathf.Round(timeLeft);
        darkMask.fillAmount = 1 - (timeLeft / timerDuration);
        if (timeLeft < 0)
        {
            AbilityEnd();
        }
    }

    public void AbilityStart()
    {
        timeLeft = timerDuration;
        darkMask.enabled = true;
        ability.AbilityStart();
        pressed = true;
    }

    public void AbilityEnd()
    {
        pressed = false;
        darkMask.enabled = false;
        myButtonImage.enabled = false;
        ability.AbilityEnd();
    }
}
