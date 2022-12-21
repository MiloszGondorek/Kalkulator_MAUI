namespace kalkulator;

public partial class History : ContentPage
{
	public History()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Data z = new Data();
        Label[] texts = new Label[5] { wynik_1, wynik_2, wynik_3, wynik_4, wynik_5 };
        double[,] numbers = z.getX();
        char[] chars = z.getChar();
        for (int i = 0; i < 5; i++)
        {
            if (chars[i]!='@')
                texts[i].Text = (i+1).ToString()+". "+numbers[i, 0].ToString() + " " + chars[i].ToString() + " " + numbers[i, 1].ToString() + " = " + numbers[i, 2].ToString();
        }
    }
}