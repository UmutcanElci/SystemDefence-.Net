// See https://aka.ms/new-console-template for more information

using Tests;
using Tools;

Console.WriteLine("Hello, World!");

var str = new StringArsenal();

List<string> list = new List<string>();


list.Add("file/new_file/a.txt");

str.FindExtension(list);

