using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Svg.Skia;
using System;

namespace testphotos.Usercontrols
{
    public partial class CustomSvgButton : UserControl
    {
        public static readonly StyledProperty<string> SourceProperty =
            AvaloniaProperty.Register<CustomSvgButton, string>(nameof(Source));

        public static readonly StyledProperty<string> HitTestPathProperty =
            AvaloniaProperty.Register<CustomSvgButton, string>(nameof(HitTestPath));

        public string Source
        {
            get => GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public string HitTestPath
        {
            get => GetValue(HitTestPathProperty);
            set => SetValue(HitTestPathProperty, value);
        }

        public CustomSvgButton()
        {
            InitializeComponent();
            this.PointerPressed += OnPointerPressed;
            this.PropertyChanged += CustomSvgButton_PropertyChanged;
        }

        private void CustomSvgButton_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == SourceProperty)
            {
                var svgImage = this.FindControl<Image>("svgImage");

                if (svgImage == null)
                {
                    Console.WriteLine("svgImage is null.");
                    return;
                }

                string uri = $"avares://testphotos/Assets/{Source}";

                /*try
                {
                    var assetUri = new Uri(uri);
                    var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
                    if (assets != null && assets.Exists(assetUri))
                    {
                        using (var assetStream = assets.Open(assetUri))
                        {
                            var svgSource = new SvgSource();
                            svgSource.Load(assetStream);
                            svgImage.Source = new SvgImage
                            {
                                Source = svgSource
                            };
                        }
                    }
                    else
                    {
                        Console.WriteLine("Asset not found or AssetLoader is null.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading image: {ex.Message}");
                }*/
            }
        }

        private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            var point = e.GetPosition(this);

            if (PathGeometry.Parse(HitTestPath).FillContains(point))
            {
                Click?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler? Click;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}