using System.Web;

namespace Nov2Epub
{
    class Text2XhtmlConverter
    {
        static string srcFileName = @"C:\Users\saube_000\Desktop\パラレル.txt";
        static string dstFileNeme = @"C:\Users\saube_000\Desktop\パラレル.xhtml";

        public static void Convert2Xhtml()
        {
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            var outputLines="";
            
            //全行を取得する
            var lines = System.IO.File.ReadAllLines(srcFileName, enc);
            foreach (var line in lines)
            {
                var outLine = HttpUtility.HtmlEncode(line); //"&<>などを変換する
                if (line.Length != 0)               //文字があれば
                {
                    if (IsTalkLine(line) != true)   //会話文でなければ通常p
                    {
                        outLine = @"<p>" + outLine;
                    }
                    else                            //会話文であればclass=talk
                    {
                        outLine = @"<p class=""talk"">" + outLine;
                    }
                    outLine = outLine + "</p>\n";  //pタグ追加
                }
                else　   //空行であればbrタグを入れる
                {
                    outLine = "<br />\n";
                }
                //書き込む
                outputLines += outLine;
                
            }
            System.IO.File.AppendAllText(dstFileNeme, outputLines, enc);


        }
        //会話文かを判定する
        static bool IsTalkLine(string line)
        {
            bool ret = false;

            if((line.StartsWith("「")==true          //カギ括弧で開始なら
                ||(line.StartsWith("『")==true)))
            {
                ret=true;
            }

            return ret;
        }
    }
}
