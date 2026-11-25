using BitRuisseau.Ui;
using Terminal.Gui.App;

using IApplication app = Application.Create();
app.Init();

using MainPage page = new MainPage();

app.Run(page);
