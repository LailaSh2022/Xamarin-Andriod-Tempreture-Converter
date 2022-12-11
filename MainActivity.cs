using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;

namespace SWD607_FridayActivity_TempretureConverter_10_12_2022
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public string convertTo;
        public double num, result;
        TextView TempNum_txt,TempResult_txt;
        Button Convert_btn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            TempNum_txt = FindViewById<TextView>(Resource.Id.Temp_Num);
            Convert_btn = FindViewById<Button>(Resource.Id.Convert_btn);
            TempResult_txt = FindViewById<TextView>(Resource.Id.Result_txt);
            // Set the spinner
            Spinner spinner = FindViewById<Spinner>(Resource.Id.Tempreture_spr);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Temp_promp, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            Convert_btn.Click += Convert_btn_Click;
        }

        private void Convert_btn_Click(object sender, EventArgs e)
        {
            num = Convert.ToDouble(TempNum_txt.Text);
            switch (convertTo)
            {
                case "F to C":
                    {
                        result = (num * (9 / 5)) +32;
                        TempResult_txt.Text = Convert.ToString(result) + "C";
                        break;
                    }
                case "C to F":
                    {
                        result = (num - 32) * (5 / 9);
                        TempResult_txt.Text = Convert.ToString(result) + "F";
                        break;
                    }
                case "F to K":
                    {
                        result = (((num + 459.67) * 5) / 9);
                        TempResult_txt.Text = Convert.ToString(result) + "K";
                        break;
                    }
                case "K to F":
                    {
                        result = ((num * 9) / 5) - 459.67;
                        TempResult_txt.Text = Convert.ToString(result) + "F";
                        break;
                    }
                case "C to K":
                    {
                        result = num + 273.15;
                        TempResult_txt.Text = Convert.ToString(result) + "K";
                        break;
                    }
                case "K to C":
                    {
                        result = num - 273.15;
                        TempResult_txt.Text = Convert.ToString(result) + "C";
                        break;
                    }
                default:
                    {
                        Toast.MakeText(this, "Select Converter, Please!", ToastLength.Long).Show();
                        break;
                    }
            }
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            convertTo = (string)spinner.GetItemAtPosition(e.Position);
            string toast = string.Format("Selected currency is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}