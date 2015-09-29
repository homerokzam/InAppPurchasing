using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InAppPurchasing
{
  public partial class MainPage : ContentPage
  {
    public MainPage ()
    {
      InitializeComponent ();
    }

    public void OnButtonPesquisarClicked(object sender, EventArgs e)
    {
      var dp = DependencyService.Get<IInAppPurchase> ();
      if (dp.ProductPurchased ())
        DisplayAlert ("Valid", "Produto já foi comprado", "Ok");
      else
        DisplayAlert ("Invalid", "Produto NÃO foi comprado", "Ok");
    }

    public void OnButtonComprarClicked(object sender, EventArgs e)
    {
      var dp = DependencyService.Get<IInAppPurchase> ();
      dp.BuyProduct ();
    }

    public void OnButtonPurgeProductsClicked(object sender, EventArgs e)
    {
      var dp = DependencyService.Get<IInAppPurchase> ();
      dp.PurgeProducts ();
    }
  }
}