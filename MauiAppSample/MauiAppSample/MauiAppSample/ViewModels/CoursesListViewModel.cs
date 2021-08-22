using MauiAppSample.Models;
using MauiAppSample.Services.Interfaces;
using MauiAppSample.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.ViewModels
{
    public class CoursesListViewModel : ViewModelBase
    {
        public CoursesListViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            LoadData();
        }

        private ObservableCollection<Course> courses = new ObservableCollection<Course>();
        public ObservableCollection<Course> Courses
        {
            get
            {
                return courses;
            }
            set
            {
                courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }

        private void LoadData()
        {
            var coursesList = new List<Course>()
            {
                new (".NET Core", "A Microsoft revolucionou o desenvolvimento de aplicações com o .NET Core, a plataforma ASP.NET Core foi totalmente reescrita do zero, é 100% open-source e é uma das mais rápidas do mundo, inclusive superando o NodeJS ...", 0.8),
                new ("EF Core", "A Microsoft revolucionou o desenvolvimento de aplicações com o .NET Core e reescreveu do zero o Entity Framework na versão Core, que está muito mais poderoso e performático. Neste curso você vai aprender os fundamentos ...", 0.5),
                new ("Arquitetura de Software", "O curso de Arquitetura de Software foi criado para lhe preparar para dar um grande passo, se tornar um arquiteto de software. Um arquiteto de software antes de mais nada deve ser um ótimo desenvolvedor ...", 0.0),
                new ("DevOps", "O curso de DevOps é uma jornada à cultura DevOps guiada por uma série de conceitos, ensinamentos e conselhos de um profissional da área com mais de 30 anos de experiência de mercado. ...", 0.4),
            };

            Courses = new ObservableCollection<Course>(coursesList);
        }
    }
}
