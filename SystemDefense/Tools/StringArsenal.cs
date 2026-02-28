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

        if (index == -1 || index == 0)
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

    public string CleanFormat(string user, string content)
    {
        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(content))
        {
            return "";
        }

        if (content.All(Char.IsDigit))
        {
            return "Secure Content...";
            // Need a more complex way to format it
        }
        user = user.Trim().ToLower();
        content = content.Trim().ToLower().Replace(" ", "-");

        string datestr = DateTime.Now.ToString("dd.MM.yyyy");


        return $"-->[{datestr}] {user} {content}";
    }

    public string SafeFileCreate(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return "";
        }

        try
        {
            str = FindExtension(str);
            str = str.ToLower().Trim();
            return str.Replace(" ", "");
        }
        catch (ArgumentException)
        {
            return "";
        }
    }

}
