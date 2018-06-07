using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using ChatAppTdd.AuthModule;
using ChatAppTdd.Repository;

namespace ChatAppTdd.Droid.AuthModule
{
    [Activity(Label = "ChatAppTdd.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            View view = LayoutInflater.Inflate(Resource.Layout.AuthorizationLayout, null, false);
            

            //Initializing Viper      
            AuthorizationView authView = view as AuthorizationView;
            authView.InitializeAuthView();




            /*   DetailedInfoFacadeView detailedInfoView = view as DetailedInfoFacadeView;
               string entityId = Intent.GetStringExtra(EntityId_ExtraKey);
               IDetailsPresenter presenter = new DetailedInfoPresenter(detailedInfoView, new DetailedInfoInteractor(RepositoryFactory.service, entityId), new DetailedInfoRouter(this));
               detailedInfoView.InitializeView(presenter, entityId == "TempEntityId");*/
            IAuthPresenter authPresenter = new AuthPresenter(authView, new AuthRouter(this));
            IAuthInteractor authInteractor = new AuthInteractor(new UserDataService(), authPresenter);
            SetContentView(view);



        }
    }
}

