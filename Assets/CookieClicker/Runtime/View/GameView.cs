using System;
using CookieClicker.Runtime.Model;
using CookieClicker.Runtime.Presenter;
using UnityEngine;

namespace CookieClicker.Runtime.View
{
	public class GameView : MonoBehaviour, IGameView
	{
		Jar jar;

		public void Initialize(Jar jar)
		{
			DomainEvents.CookieEarned += RefreshCounter;
			this.jar = jar;
			Refresh();
		}

		private void OnDestroy()
		{
			DomainEvents.CookieEarned -= RefreshCounter;
		}

		public void Refresh()
		{
			RefreshCounter(jar.Amount);
			FindFirstObjectByType<PurchaseAutoclickerButton>().Refresh(jar.Amount, jar.AutoclickerPrice);
		}

		private static void RefreshCounter(int amount)
		{
			FindFirstObjectByType<CookieCounter>().Refresh(amount);
		}
	}
}
