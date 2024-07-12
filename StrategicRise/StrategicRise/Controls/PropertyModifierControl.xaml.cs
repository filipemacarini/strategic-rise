namespace StrategicRise.Controls;

public partial class PropertyModifierControl : ContentPage
{
	public PropertyModifierControl()
	{
		InitializeComponent();

		LbTitle.Text = DimensionTitle;
		LbNumber.Text = Number.ToString();
		UpdateArrows();
	}

    public static readonly BindableProperty DimensionTitleProperty =
        BindableProperty.Create(
            nameof(DimensionTitle),
            typeof(string),
            typeof(PropertyModifierControl),
            defaultValue: "Default",
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (PropertyModifierControl)bindable;
                control.LbTitle.Text = (string)newValue;
            });

    public static readonly BindableProperty NumberProperty =
        BindableProperty.Create(
            nameof(Number),
            typeof(int),
            typeof(PropertyModifierControl),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (PropertyModifierControl)bindable;
                control.LbNumber.Text = newValue.ToString();
                control.UpdateArrows();
            });

    public static readonly BindableProperty RatioProperty =
        BindableProperty.Create(
            nameof(Ratio),
            typeof(int),
            typeof(PropertyModifierControl),
            defaultValue: 1);

    public static readonly BindableProperty MinimumProperty =
        BindableProperty.Create(
            nameof(Minimum),
            typeof(int),
            typeof(PropertyModifierControl),
            defaultValue: 0);

    public static readonly BindableProperty MaximumProperty =
        BindableProperty.Create(
            nameof(Maximum),
            typeof(int),
            typeof(PropertyModifierControl),
            defaultValue: 10);

	public string DimensionTitle
	{
		get => (string)GetValue(DimensionTitleProperty);
		set => SetValue(DimensionTitleProperty, value);
	}

	public int Number
	{
		get => (int)GetValue(NumberProperty);
		set => SetValue(NumberProperty, value);
	}

	public int Ratio
	{
		get => (int)GetValue(RatioProperty);
		set {
			if (value < 0) SetValue(RatioProperty, 0);
			else SetValue(RatioProperty, value);
		}
	}

	public int Minimum
	{
		get => (int)GetValue(MinimumProperty);
		set => SetValue(MinimumProperty, value);
	}

	public int Maximum
	{
		get => (int)GetValue(MaximumProperty);
		set => SetValue(MaximumProperty, value);
	}

	public void UpdateArrows()
	{
		ImgArrowLeft.IsVisible = Number > Minimum;
		ImgArrowRight.IsVisible = Number < Maximum;
	}

	public void Remove(object sender, TappedEventArgs e) =>
		Number -= Ratio;

	public void Add(object sender, TappedEventArgs e) =>
		Number += Ratio;
}