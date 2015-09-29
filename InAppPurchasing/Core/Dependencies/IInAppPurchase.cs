using System;

namespace InAppPurchasing
{
  public interface IInAppPurchase
  {
    void Init();
    bool ProductPurchased();
    void BuyProduct();
    void PurgeProducts();
  }
}