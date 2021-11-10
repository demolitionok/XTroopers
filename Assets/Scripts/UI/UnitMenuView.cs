using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitMenuView : View
{
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private GameObject heroPanelPrefab;

    private JsonSaver _jsonSaver;
    private Hero[] _heroesToShow;
    
    public override void Init()
    {
        _jsonSaver = new JsonSaver();
        backButton.onClick.AddListener(ViewManager.ShowLast);
    }

    private void GeneratePanels()
    {
        foreach (var hero in _heroesToShow)
        {
            var panel = Instantiate(heroPanelPrefab, gameObject.transform);
            panel.GetComponent<RectTransform>().pivot = Vector2.down;
            panel.GetComponent<HeroPanel>().Init(hero);
        }
    }

    private Hero TestHero()
    {
        var stats = new PlayerStats(new Stat(1), new Stat(1), new Stat(1));
        return new Hero(stats, 10, "bebriq", HeroType.Riffler);
    }

    public override void Show()
    {
        base.Show();
        //var saveData = _jsonSaver.Load();
        _heroesToShow = new Hero[1];//saveData.heroes.ToArray();
        
        _heroesToShow[0] = TestHero();
        GeneratePanels();
    }
}
