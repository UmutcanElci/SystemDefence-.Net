namespace Tools;

public class StringArsenal
{



    public string FindExtension(string str)
    {
        // First find the lastvalue on the string array with lastIndexOf functions
        // Then take the extension like .pdf or .cs or .png etc....

        if (string.IsNullOrEmpty(str))
        {
            return "";
        }

        int index = str.LastIndexOf(".");

        if (index == -1)
        {
            return "";
        }
        // In Windows \\ 
        int lastForwardSlash = str.LastIndexOf("/");

        if (index < lastForwardSlash)
        {
            return "";
        }
        return str.Substring(index);

    }


    public string FindFileName(string str)
    {
        // Only take the name of the file like text.txt etc

        if (string.IsNullOrEmpty(FindExtension(str)))
        {
            return "";
        }

        int lastForwardSlash = str.LastIndexOf("/");

        return str.Substring(lastForwardSlash + 1);
    }

    public string CleanFormat(List<string> list)
    {

        return "";
    }

}
