using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginConfig
/// </summary>
public class LoginConfig
{
    public LoginConfig()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public static string Temizle(string Metin)
    {
        string ifade = Metin;
        ifade = ifade.Replace("'","");
        ifade = ifade.Replace(">","");
        ifade = ifade.Replace("<","");
        ifade = ifade.Replace(",","");
        ifade = ifade.Replace("!","");
        ifade = ifade.Replace("=", "");
        ifade = ifade.Replace("%", "");
        ifade = ifade.Replace("[", "");
        ifade = ifade.Replace("]", "");
        ifade = ifade.Replace("{", "");
        ifade = ifade.Replace("}", "");

        return ifade;
    }

}