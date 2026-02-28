// See https://aka.ms/new-console-template for more information

using Tests;
using Tools;

Console.WriteLine("Hello, World!");

var str = new StringArsenal();

string value = "file/new_file/a.txt";

string result1 = str.FindExtension(value);
Console.WriteLine("extension : " + result1);

string result2 = str.FindFileName(value);
Console.WriteLine("file name : " + result2);
