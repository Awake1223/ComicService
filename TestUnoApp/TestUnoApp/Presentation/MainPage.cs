public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.DataContext<MainModel>((page, vm) => page
            .NavigationCacheMode(NavigationCacheMode.Required)
            .Background(Theme.Brushes.Background.Default)
            .Content(new Grid()
                .SafeArea(SafeArea.InsetMask.VisibleBounds)
                .RowDefinitions("Auto,*")
                .Children(
                    new NavigationBar().Content(() => vm.Title),
                    new StackPanel()
                        .Grid(row: 1)
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        .VerticalAlignment(VerticalAlignment.Center)
                        .Spacing(16)
                        .Children(
                            new Button()
                                .Content("Test GET /user")
                                .Command(() => vm.TestGetUsersCommand),
                            new Button()
                                .Content("Test POST /user")
                                .Command(() => vm.TestCreateUserCommand),
                            new TextBox()
                                .Text(x => x.Binding(() => vm.Name).Mode(BindingMode.TwoWay))
                                .PlaceholderText("Username"),
                            new TextBox()
                                .Text(x => x.Binding(() => vm.Email).Mode(BindingMode.TwoWay))
                                .PlaceholderText("Email"),
                            new ListView()
                                .ItemsSource(x => x.Binding(() => vm.Users))
                                .Height(200)
                                .Width(300)
                        ))));
    }
}
