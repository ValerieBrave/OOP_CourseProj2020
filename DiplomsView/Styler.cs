using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DiplomsDB.Models;

namespace DiplomsView
{
    public static class Styler
    {
        public static void dipExpanderStyle(Expander expander)
        {
            expander.FontSize = 16;
            expander.FontFamily = new FontFamily("Yu Gothic UI");
            expander.Content = new Grid();
            expander.HorizontalAlignment = HorizontalAlignment.Stretch;
            ((Grid)expander.Content).Height = 120;
            ((Grid)expander.Content).ColumnDefinitions.Add(new ColumnDefinition());
            ((Grid)expander.Content).ColumnDefinitions.Add(new ColumnDefinition());
            ((Grid)expander.Content).RowDefinitions.Add(new RowDefinition());
            ((Grid)expander.Content).RowDefinitions.Add(new RowDefinition());
            ((Grid)expander.Content).RowDefinitions.Add(new RowDefinition());
            ((Grid)expander.Content).ShowGridLines = true;
        }
        public static void dipExpanderContent(Expander expander, Diplom diplom)
        {
            expander.Header = diplom.Topic + ", "+", "+diplom.Form+ ", " + diplom.Student_name+ ", " + diplom.Order_id;
            TextBlock supervisor = new TextBlock() { Text = "Руководитель: " + diplom.Supervisor_id };
            TextBlock comission = new TextBlock() { Text = "Комиссия: " + diplom.Comission_id };
            TextBlock reviewer = new TextBlock() { Text = "Рецензент: " + diplom.Reviewer_id };
            TextBlock setter = new TextBlock() { Text = "Нормоконтролер: " + diplom.Setter_id };
            TextBlock speciality = new TextBlock() { Text = "Специальность: " + diplom.Speciality_id };
            TextBlock chairman = new TextBlock() { Text = "Председатель: " + diplom.Chairman_id };
            supervisor.FontSize = 14;
            comission.FontSize = 14;
            reviewer.FontSize = 14;
            setter.FontSize = 14;
            speciality.FontSize = 14;
            chairman.FontSize = 14;
            Grid.SetColumn(supervisor, 0);
            Grid.SetRow(supervisor, 0);
            Grid.SetColumn(comission, 1);
            Grid.SetRow(comission, 0);
            Grid.SetColumn(reviewer, 0);
            Grid.SetRow(reviewer, 1);
            Grid.SetColumn(setter, 1);
            Grid.SetRow(setter, 1);
            Grid.SetColumn(speciality, 0);
            Grid.SetRow(speciality, 2);
            Grid.SetColumn(chairman, 1);
            Grid.SetRow(chairman, 2);
            ((Grid)expander.Content).Children.Add(supervisor);
            ((Grid)expander.Content).Children.Add(comission);
            ((Grid)expander.Content).Children.Add(reviewer);
            ((Grid)expander.Content).Children.Add(setter);
            ((Grid)expander.Content).Children.Add(speciality);
            ((Grid)expander.Content).Children.Add(chairman);
        }
    }
}
