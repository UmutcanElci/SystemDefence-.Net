namespace Tools;

public class StringArsenal
{

    // First find the lastvalue on the string array with lastIndexOf functions
    // Then take the extension like .pdf or .cs or .png etc....

    public void FindExtension(List<string> str)
    {

        string value = str[0];

        int index = value.LastIndexOf(".");

        Console.WriteLine(value.Substring(index));
    }

}
