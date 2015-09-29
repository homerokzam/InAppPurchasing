using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace InAppPurchasing
{
  public partial class App : Application
  {
    public App ()
    {
      InitializeComponent ();

      // The root page of your application
      MainPage = new InAppPurchasing.MainPage();
    }

    protected override void OnStart ()
    {
      // Handle when your app starts
      var dp = DependencyService.Get<IInAppPurchase> ();
      dp.Init ();
    }

    protected override void OnSleep ()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume ()
    {
      // Handle when your app resumes
    }
  }
}