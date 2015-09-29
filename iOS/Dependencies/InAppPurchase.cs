using System;

using Xamarin.Forms;
using Xamarin.InAppPurchase;

[assembly: Dependency(typeof(InAppPurchasing.iOS.Dependencies.InAppPurchase))]

namespace InAppPurchasing.iOS.Dependencies
{
  public class InAppPurchase : IInAppPurchase
  {
    public InAppPurchase ()
    {
    }

    //private string _productId = "magazine.subscription.duration1month";
    //private string _productId = "outlet_premium.nonrenewingsubscription.duration6months";
    //private string _productId = "outlet_premium.nonrenewingsubscription.duration3months";
    private string _productId = "savemoney.nonrenewingsubscription.duration3month";
    private InAppPurchaseManager _purchaseManager = null;

    #region IInAppPurchase implementation

    public void Init()
    {
      _purchaseManager = new InAppPurchaseManager ();
      _purchaseManager.SimulateiTunesAppStore = true;
      _purchaseManager.PublicKey = "ASDFASDFASDF";

      _purchaseManager.AutomaticPersistenceType = InAppPurchasePersistenceType.LocalFile;
      _purchaseManager.ShuffleProductsOnPersistence = false;
      _purchaseManager.RestoreProducts ();

      _purchaseManager.QueryInventory (new string[] {
        _productId,
      });

      _purchaseManager.ReceivedValidProducts += (products) => {
        Console.WriteLine("ReceivedValidProducts");
        foreach(InAppProduct product in products)
          Console.WriteLine(product.Description);
      };
    }

    public bool ProductPurchased()
    {
      if (!_purchaseManager.CanMakePayments) {
        throw new Exception ("Usuário não pode efetuar compra na AppleStore!");
      }
      //_purchaseManager.ProductPurchased (_productId);
      InAppProduct prod = _purchaseManager.FindProduct (_productId);
      return(prod.Purchased);
    }

    public void BuyProduct ()
    {
      InAppProduct prod = _purchaseManager.FindProduct (_productId);
      _purchaseManager.BuyProduct (prod, 5);
    }

    public void PurgeProducts ()
    {
      _purchaseManager.PurgeProducts ();
    }
    #endregion
  }
}