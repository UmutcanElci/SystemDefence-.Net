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

        int lastForwardSlash = str.LastIndexOf("/");

        if (index < lastForwardSlash)
        {
            return "";
        }
        return str.Substring(index);

    }

}
