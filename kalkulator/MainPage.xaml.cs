namespace kalkulator;

public partial class MainPage : ContentPage
{
    double currentNumber = 0;
    double firstNumber = 0;

	string zeros= "";

	bool wrtieFraction = false;
	bool newCalculation = false;

	enum actionChars {none, plus, minus, divide, multiply};
	actionChars currentAction=actionChars.none;

	public MainPage()
	{
		InitializeComponent();
	}

	private void AddNumber(object sender, EventArgs e)
	{
		string c =((Button)sender).Text.ToString();
		if (newCalculation)
		{
            currentNumber = 0;
            firstNumber = 0;
            wrtieFraction = false;
			newCalculation = false;
            zeros = "";
            SetInput(currentNumber);
			currentAction=actionChars.none;
        }
		if (c == ".")
		{
			wrtieFraction= true;
			if (!input.Text.Contains(','))
			{
				zeros = ",";
				SetInput(currentNumber);
			}
		}
		else if (c == "00")
		{
			if (wrtieFraction)
			{
                zeros += "00";
            }
			else
			{
				currentNumber *= 100;
            }
            SetInput(currentNumber);
        }

		else
		{
			double number = double.Parse(c);
			if (wrtieFraction)
			{
				String[] currentNumberFraction = input.Text.Split(',');
				if(currentNumberFraction.Length == 2)
                {
                    double fraction= (number/Math.Pow(10,(currentNumberFraction[1].Length+1)));
					currentNumber += fraction;
				}
				else
                {
                    currentNumber += (number/10);
                }
				if (number == 0)
					zeros += "0";
				else
					zeros = "";
            }
			else
			{
				currentNumber *= 10;
				currentNumber += number;
			}
			SetInput(currentNumber);
		}
	}
	
	private void Clear(object sender, EventArgs e)
	{
		currentNumber= 0;
		firstNumber= 0;
		wrtieFraction = false;
        zeros = "";
        newCalculation = false;
        SetInput(currentNumber);
		currentAction = actionChars.none;
	}

	private void SetInput(double n)
	{
		input.Text = (Math.Round(n, 8)).ToString()+zeros;
	}
    private void SetInput(String s)
	{
		input.Text = s;
	}

    private void SetAction(object sender, EventArgs e)
	{		
		switch (((Button)sender).Text.ToString())
		{
			case "+":
				currentAction = actionChars.plus;
				break;

			case "-":
				currentAction = actionChars.minus;
				break;

			case "*":
				currentAction = actionChars.multiply;
				break;

			case "÷":
				currentAction = actionChars.divide;
				break;
		}
        if (currentAction != actionChars.none)
        {
			if (input.Text != "Nie dziel przez 0")
				firstNumber = double.Parse(input.Text);
			else
			firstNumber = 0;
            currentNumber = 0;
			wrtieFraction = false;
			newCalculation = false;
            zeros = "";
            SetInput(currentNumber);
		}
	}

	private void Result(object sender, EventArgs e)
	{
		CountResult();
    }

	private void CountResult()
	{
		double number = currentNumber;
		bool change = false;
		char charValue = ' ';
        switch (currentAction)
		{
			case actionChars.plus:
                number += firstNumber;
				charValue = '+';
                break;

			case actionChars.minus:
                number = firstNumber - currentNumber;
                charValue = '-';
                break;

			case actionChars.multiply:
                number *= firstNumber;
                charValue = '*';
                break;

			case actionChars.divide:
				if (currentNumber != 0)
				{
					number = firstNumber / currentNumber;
					charValue = '/';
				}
				else
				{
					SetInput("Nie dziel przez 0");
					change = true;
				}
                break;
        }
        wrtieFraction = false;
        Data.ChangeX((Math.Round(firstNumber, 8)), (Math.Round(currentNumber, 8)), (Math.Round(number, 8)), charValue);
        firstNumber = number;
		if(!change)
			SetInput(firstNumber);
        newCalculation = true;
    }
}

