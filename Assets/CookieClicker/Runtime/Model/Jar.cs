using System;

namespace CookieClicker.Runtime.Model
{
	public class Jar
	{
		public int AutoclickerPrice { get; }
		public int Amount { get; private set; }
		float timePassed;
		public bool isAutoclickerPurchased;

		public Jar()
		{
		}

		public Jar(int autoclickerPrice)
		{
			AutoclickerPrice = autoclickerPrice;
		}

		public bool IsEmpty()
		{
			return Amount == 0;
		}

		public void Add()
		{
			Amount++;
		}

		public void OneSecondHasPassed()
		{
			Add();
		}

		public void SecondsHavePassed(float f)
		{
			if (!isAutoclickerPurchased)
				return;

			timePassed += f;
			var cookiesToAdd = (int)timePassed;
			Amount += cookiesToAdd;
			timePassed -= cookiesToAdd;
		}

		public void PurchaseAutoclicker()
		{
			if (Amount < AutoclickerPrice)
			{
				throw new InvalidOperationException();
			}

			Amount -= AutoclickerPrice;
			isAutoclickerPurchased = true;
		}
	}
}
