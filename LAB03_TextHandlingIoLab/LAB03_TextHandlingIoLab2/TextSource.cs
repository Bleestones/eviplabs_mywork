namespace LAB03_TextHandlingIoLab2
{
    public class TextSource
    {
        public static string ShortTextWithEmails => @"Ez egy rövid szöveg,
amiben e-mail címek is vannak, olyan mint valaki@example.com,
és nagyfonok@nagyceg.example.com, itt.es.ott@bme.hu, valamint info@bkk.hu.";
        public static string ShortTextWithPhoneNumbers => @"Ebben pedig telefonszámok vannak,
úgy mint +36701234567 és +1-202-555-0114, de nem 12345 vagy 12-345.
A 06201237654 sem túl nyerő, mert bár sokan használják, külföldről mást jelent.
A +36201234567 egy mobil szám, míg a +3614633702 egy vezetékes.";
        public static string ShortTextForMusicBox => @"Ma mi megyünk a fához az öreg dóm mellett, hogy szóval tartsuk a látogatókat.";
        public static string ShortTextForDates => @"Itt meg dátumok vannak, mint a 2019-08-22, a 2018/08/31, de a 2017-13-12 már hibás,
mint ahogy az 1980-05-35 és a 128-05-123 is.";
        // https://en.wikipedia.org/wiki/Open_Location_Code
        public static string ShortTextForPlusCodes => @"Itt Plus Code-ok szerepelnek, mint a 8FVXF3F5+6X, a 8FRVWV5J+JH, a 7Q622X5W+PF,
a 8FVXF3H5+GPX, 8FVXG28V+2C, 7J3XWRJP+J8, de ha egy közeli várost adunk meg, akkor a G3M2+RJ, Budapest is és a F3F5+6X Budapest is helyes.
Viszont az alábbiak hibásak: 8FVXF1F5+6X, 8BVXF3F5+6X, 8F0XF3FO+6X, mert érvénytelen karaktereket is tartalmaznak.";
    }
}
