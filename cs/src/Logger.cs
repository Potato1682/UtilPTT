using System;

namespace UtilPTT
{
    /// <summary>
    /// ログ出力を管理します。
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Infoログをコマンドラインに出力します。
        /// </summary>
        /// <param name="log">ログ内容。</param>
        public static void Info(string log)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[INFO] ");
            Console.ResetColor();
            Console.WriteLine(log);
        }

        /// <summary>
        /// Warningログをコマンドラインに出力します。
        /// </summary>
        /// <param name="log">ログ内容。</param>
        public static void Warn(string log)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[WARN] ");
            Console.ResetColor();
            Console.WriteLine(log);
        }

        /// <summary>
        /// Errorログをコマンドラインに出力します。
        /// </summary>
        /// <param name="log">ログ内容。</param>
        public static void Error(string log)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[!ERROR!] ");
            Console.ResetColor();
            Console.WriteLine(log);
        }
    }
}
