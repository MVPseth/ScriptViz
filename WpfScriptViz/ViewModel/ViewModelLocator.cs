/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ScriptViz"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace ScriptViz.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainWindowViewModel>();

            SimpleIoc.Default.Register<ScriptVisualizerViewModel>();
            SimpleIoc.Default.Register<MoveListViewModel>();
            SimpleIoc.Default.Register<HitboxEffectsesViewModel>();
        }

        public MainWindowViewModel Main_VM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }

        public ScriptVisualizerViewModel Visualizer_VM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ScriptVisualizerViewModel>();
            }
        }

        public MoveListViewModel MoveList_VM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MoveListViewModel>();
            }
        }

        public HitboxEffectsesViewModel HitboxEffectses_VM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HitboxEffectsesViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}