using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace BitRuisseau.Ui;

// main page, a droite de la barre latérale
public class MainPage : Window
{
    private const int BarWidth = 24;

    private LateralBar lateralBar = new LateralBar();
    private FrameView content = new FrameView();

    private Label libraryView = new Label();
    private Label exploreView = new Label();

    public int CurrentTab { get; private set; }

    public MainPage()
    {
        Title = "BitRuisseau";

        BorderStyle = 0;
        //content.Border.Thickness.Top = 1;

        // config de barre latérale et du contenu
        lateralBar.X = 0;
        lateralBar.Y = 0;
        lateralBar.Width = BarWidth;
        lateralBar.Height = Dim.Fill();

        content.X = Pos.Right(lateralBar);
        content.Y = 0;
        content.Width = Dim.Fill();
        content.Height = Dim.Fill();

        libraryView.Text = "contenus audio";
        exploreView.Text = "contenu explorateur";
        content.Add(libraryView, exploreView);

        Add(lateralBar, content);

        // affiche l'onglet select quand on change de page dans la barre
        lateralBar.Menu.ValueChanged += (sender, e) => ShowTab(lateralBar.Menu.SelectedItem);

        ShowTab(0);
    }

    // affiche l'onglet demandée
    private void ShowTab(int? tab)
    {
        if (tab == 1)
        {
            CurrentTab = 1;
            content.Title = "Explorer";
        }
        else
        {
            CurrentTab = 0;
            content.Title = "Ma médiathèque";
        }

        // definition de la visibilité des deux affichages
        libraryView.Visible = CurrentTab == 0;
        exploreView.Visible = CurrentTab == 1;
    }
}