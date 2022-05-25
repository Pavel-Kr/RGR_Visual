using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RGR_Visual.Views
{
    public partial class QueryEditor : Window
    {
        public QueryEditor()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
