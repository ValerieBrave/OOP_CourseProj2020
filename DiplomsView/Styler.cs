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
            //expander.HorizontalAlignment = HorizontalAlignment.Stretch;
            ((Grid)expander.Content).Height = 120;
            ((Grid)expander.Content).HorizontalAlignment = HorizontalAlignment.Stretch;
            ((Grid)expander.Content).ColumnDefinitions.Add(new ColumnDefinition());
            ((Grid)expander.Content).ColumnDefinitions.Add(new ColumnDefinition());
            ((Grid)expander.Content).ColumnDefinitions.Add(new ColumnDefinition());
            ((Grid)expander.Content).RowDefinitions.Add(new RowDefinition());
            ((Grid)expander.Content).RowDefinitions.Add(new RowDefinition());
            ((Grid)expander.Content).RowDefinitions.Add(new RowDefinition());
            
        }
        public static void dipExpanderContent(Expander expander, Diplom diplom)
        {
            expander.Header = new TextBlock();

            ((TextBlock)expander.Header).Text = '[' + diplom.Order_id + ']'
                + '-' + diplom.Form
                + '-' + diplom.Speciality_id
                + "-студ.-" + diplom.Student_name
                + "-рук. -" + diplom.Supervisor_id;
            ((TextBlock)expander.Header).Height = 50;
            TextBlock reviewer = new TextBlock() { Text = "Рецензент: " + diplom.Reviewer_id, Margin=new Thickness(20,10,10,10) };
            TextBlock comission = new TextBlock() { Text = "Комиссия: " + diplom.Comission_id, Margin = new Thickness(20, 10, 10, 10) };
            TextBlock setter = new TextBlock() { Text = "Нормоконтролер: " + diplom.Setter_id, Margin = new Thickness(20, 10, 10, 10) };
            TextBlock chairman = new TextBlock() { Text = "Председатель: " + diplom.Chairman_id, Margin = new Thickness(20, 10, 10, 10) };
            TextBlock deadline = new TextBlock() { Text = "Срок предоставления: " + (diplom.Deadline.Equals(DateTime.MinValue) ? "" : diplom.Deadline.ToString()), Margin = new Thickness(20, 10, 10, 10) };
            TextBlock exam = new TextBlock() { Text = "Защита: " + (diplom.ExamDate.Equals(DateTime.MinValue)? "": diplom.ExamDate.ToString()), Margin = new Thickness(20, 10, 10, 10) };
            TextBlock topic = new TextBlock() { Text = "Тема: " + diplom.Topic, Margin = new Thickness(20, 10, 10, 10) };
            TextBlock queue = new TextBlock() { Text = "Очередь: " + (diplom.Date_position ==0? "" : diplom.Date_position.ToString()), Margin = new Thickness(20, 10, 10, 10) };
            TextBlock mark = new TextBlock() { Text = "Оценка: " + (diplom.Mark==0? "": diplom.Mark.ToString()), Margin = new Thickness(20, 10, 10, 10) };
            comission.FontSize = 14;
            reviewer.FontSize = 14;
            setter.FontSize = 14;
            chairman.FontSize = 14;
            deadline.FontSize = 14;
            exam.FontSize = 14;
            topic.FontSize = 14;
            queue.FontSize = 14;
            mark.FontSize = 14;
            Grid.SetColumn(reviewer, 0);
            Grid.SetRow(reviewer, 0);
            Grid.SetColumn(comission, 0);
            Grid.SetRow(comission, 1);
            Grid.SetColumn(setter, 0);
            Grid.SetRow(setter, 2);
            Grid.SetColumn(chairman, 1);
            Grid.SetRow(chairman, 0);
            Grid.SetColumn(deadline, 1);
            Grid.SetRow(deadline, 1);
            Grid.SetColumn(exam, 1);
            Grid.SetRow(exam, 3);
            Grid.SetColumn(topic, 2);
            Grid.SetRow(topic, 0);
            Grid.SetColumn(queue, 2);
            Grid.SetRow(queue, 1);
            Grid.SetColumn(mark, 2);
            Grid.SetRow(mark, 2);
            
            ((Grid)expander.Content).Children.Add(reviewer);
            ((Grid)expander.Content).Children.Add(comission);
            ((Grid)expander.Content).Children.Add(setter);
            ((Grid)expander.Content).Children.Add(chairman);
            ((Grid)expander.Content).Children.Add(deadline);
            ((Grid)expander.Content).Children.Add(exam);
            ((Grid)expander.Content).Children.Add(topic);
            ((Grid)expander.Content).Children.Add(queue);
            ((Grid)expander.Content).Children.Add(mark);
        }
        public static void catalogListItem(Grid grid, Supervisor sup)
        {
            grid.Width = 350;
            //grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.Height = 90;
            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(40, GridUnitType.Star);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(30, GridUnitType.Star);
            ColumnDefinition c3 = new ColumnDefinition();
            c3.Width = new GridLength(30, GridUnitType.Star);
            grid.ColumnDefinitions.Add(c1);
            grid.ColumnDefinitions.Add(c2);
            grid.ColumnDefinitions.Add(c3);
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ShowGridLines = true;
            TextBlock sup_name = new TextBlock();
            Grid.SetColumn(sup_name, 0);
            sup_name.Text = sup.Supervisor_id;
            Button edit = new Button();
            Grid.SetColumn(edit, 1);
            edit.Content = "Изменить";
            Button del = new Button();
            Grid.SetColumn(del, 2);
            del.Content = "Удалить";
            
            grid.Children.Add(sup_name);
            grid.Children.Add(edit);
            grid.Children.Add(del);
        }
        public static void catalogListItem(Grid grid, Order or)
        {
            grid.Width = 350;
            //grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.Height = 90;
            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(40, GridUnitType.Star);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(30, GridUnitType.Star);
            ColumnDefinition c3 = new ColumnDefinition();
            c3.Width = new GridLength(30, GridUnitType.Star);
            grid.ColumnDefinitions.Add(c1);
            grid.ColumnDefinitions.Add(c2);
            grid.ColumnDefinitions.Add(c3);
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ShowGridLines = true;
            TextBlock sup_name = new TextBlock();
            Grid.SetColumn(sup_name, 0);
            sup_name.Text = or.Order_id;
            Button edit = new Button();
            Grid.SetColumn(edit, 1);
            edit.Content = "Изменить";
            Button del = new Button();
            Grid.SetColumn(del, 2);
            del.Content = "Удалить";

            grid.Children.Add(sup_name);
            grid.Children.Add(edit);
            grid.Children.Add(del);
        }
        public static void catalogListItem(Grid grid, Comission com)
        {
            grid.Width = 350;
            //grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.Height = 90;
            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(40, GridUnitType.Star);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(30, GridUnitType.Star);
            ColumnDefinition c3 = new ColumnDefinition();
            c3.Width = new GridLength(30, GridUnitType.Star);
            grid.ColumnDefinitions.Add(c1);
            grid.ColumnDefinitions.Add(c2);
            grid.ColumnDefinitions.Add(c3);
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ShowGridLines = true;
            TextBlock sup_name = new TextBlock();
            Grid.SetColumn(sup_name, 0);
            sup_name.Text = com.Comission_id;
            Button edit = new Button();
            Grid.SetColumn(edit, 1);
            edit.Content = "Изменить";
            Button del = new Button();
            Grid.SetColumn(del, 2);
            del.Content = "Удалить";

            grid.Children.Add(sup_name);
            grid.Children.Add(edit);
            grid.Children.Add(del);
        }
        public static void catalogListItem(Grid grid, Reviewer rev)
        {
            grid.Width = 350;
            //grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.Height = 90;
            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(40, GridUnitType.Star);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(30, GridUnitType.Star);
            ColumnDefinition c3 = new ColumnDefinition();
            c3.Width = new GridLength(30, GridUnitType.Star);
            grid.ColumnDefinitions.Add(c1);
            grid.ColumnDefinitions.Add(c2);
            grid.ColumnDefinitions.Add(c3);
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ShowGridLines = true;
            TextBlock sup_name = new TextBlock();
            Grid.SetColumn(sup_name, 0);
            sup_name.Text = rev.Reviewer_id;
            Button edit = new Button();
            Grid.SetColumn(edit, 1);
            edit.Content = "Изменить";
            Button del = new Button();
            Grid.SetColumn(del, 2);
            del.Content = "Удалить";

            grid.Children.Add(sup_name);
            grid.Children.Add(edit);
            grid.Children.Add(del);
        }
        public static void catalogListItem(Grid grid, DiplomsDB.Models.Setter st)
        {
            grid.Width = 350;
            //grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.Height = 90;
            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(40, GridUnitType.Star);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(30, GridUnitType.Star);
            ColumnDefinition c3 = new ColumnDefinition();
            c3.Width = new GridLength(30, GridUnitType.Star);
            grid.ColumnDefinitions.Add(c1);
            grid.ColumnDefinitions.Add(c2);
            grid.ColumnDefinitions.Add(c3);
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ShowGridLines = true;
            TextBlock sup_name = new TextBlock();
            Grid.SetColumn(sup_name, 0);
            sup_name.Text = st.Setter_id;
            Button edit = new Button();
            Grid.SetColumn(edit, 1);
            edit.Content = "Изменить";
            Button del = new Button();
            Grid.SetColumn(del, 2);
            del.Content = "Удалить";

            grid.Children.Add(sup_name);
            grid.Children.Add(edit);
            grid.Children.Add(del);
        }
        public static void catalogListItem(Grid grid, Speciality spec)
        {
            grid.Width = 350;
            //grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.Height = 90;
            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(40, GridUnitType.Star);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(30, GridUnitType.Star);
            ColumnDefinition c3 = new ColumnDefinition();
            c3.Width = new GridLength(30, GridUnitType.Star);
            grid.ColumnDefinitions.Add(c1);
            grid.ColumnDefinitions.Add(c2);
            grid.ColumnDefinitions.Add(c3);
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ShowGridLines = true;
            TextBlock sup_name = new TextBlock();
            Grid.SetColumn(sup_name, 0);
            sup_name.Text = spec.Speciality_id;
            Button edit = new Button();
            Grid.SetColumn(edit, 1);
            edit.Content = "Изменить";
            Button del = new Button();
            Grid.SetColumn(del, 2);
            del.Content = "Удалить";

            grid.Children.Add(sup_name);
            grid.Children.Add(edit);
            grid.Children.Add(del);
        }
        public static void catalogListItem(Grid grid, Chairman cha)
        {
            grid.Width = 350;
            //grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            grid.Height = 90;
            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(40, GridUnitType.Star);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(30, GridUnitType.Star);
            ColumnDefinition c3 = new ColumnDefinition();
            c3.Width = new GridLength(30, GridUnitType.Star);
            grid.ColumnDefinitions.Add(c1);
            grid.ColumnDefinitions.Add(c2);
            grid.ColumnDefinitions.Add(c3);
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ShowGridLines = true;
            TextBlock sup_name = new TextBlock();
            Grid.SetColumn(sup_name, 0);
            sup_name.Text = cha.Chairman_id;
            Button edit = new Button();
            Grid.SetColumn(edit, 1);
            edit.Content = "Изменить";
            Button del = new Button();
            Grid.SetColumn(del, 2);
            del.Content = "Удалить";

            grid.Children.Add(sup_name);
            grid.Children.Add(edit);
            grid.Children.Add(del);
        }
    }
}
