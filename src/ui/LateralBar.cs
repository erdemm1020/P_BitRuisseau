using System.Collections.ObjectModel;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace BitRuisseau.Ui;

// barre de gauche avec les deux onglets
public class LateralBar : FrameView
{
    public ListView Menu { get; } = new ListView();

    public LateralBar()
    {
        Title = "Menu latéral";

        ObservableCollection<string> tabs = new ObservableCollection<string>();
        tabs.Add("Ma médiathèque");
        tabs.Add("Explorer");
        Menu.SetSource(tabs);

        // La liste remplit tout le cadre
        Menu.Width = Dim.Fill();
        Menu.Height = Dim.Fill();

        // index du premier onglet sélectionné par défaut
        Menu.SelectedItem = 0;

        Add(Menu);
    }
}