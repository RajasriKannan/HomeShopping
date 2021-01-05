using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


namespace HomeShopping.DAL
{
    public class Log
    {
        static string path = @"C:\Users\VenkatRaji\Desktop\DOT NET\WebApp\Log.txt";
        public static string GetLayer(Layers layer)
        {
            switch (layer)
            {
                case Layers.BLL:
                    return "Business Logic Layer";
                case Layers.DAL:
                    return "Data Access Layer";
                case Layers.Presentation:
                    return "Presentation Layer";
                default:
                    return "Out Of All Layers";
            }
        }


        public static void WriteLog(string Message)
        {
            StreamWriter streamWriter = File.AppendText(path);
            streamWriter.WriteLine(Message);
            streamWriter.Flush();
            streamWriter.Close();

            ReadLog();
        }

        public static void ReadLog()
        {
            StreamReader streamReader = new StreamReader(path);
            streamReader.Read();
            streamReader.Close();
        }

        public static void Error(Layers layer, Exception exception)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(DateTime.Now.ToShortDateString().ToString() +
                          " " +
                          DateTime.Now.ToLongTimeString().ToString() +
                          " ==> ");
            stringBuilder.Append(layer);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(exception.GetType().Name);
            stringBuilder.Append("\t");
            stringBuilder.Append(exception.Message);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(exception.StackTrace);
            stringBuilder.Append(Environment.NewLine);

            Exception innerException = exception.InnerException;
            while (innerException != null)
            {
                stringBuilder.Append(DateTime.Now.ToShortDateString().ToString() +
                          " " +
                          DateTime.Now.ToLongTimeString().ToString() +
                          " ==> ");
                stringBuilder.Append(layer);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(innerException.GetType().Name);
                stringBuilder.Append("\t");
                stringBuilder.Append(innerException.Message);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(innerException.StackTrace);
                stringBuilder.Append(Environment.NewLine);
                innerException = innerException.InnerException;
            }

            WriteLog(stringBuilder.ToString());
        }
    }

    public enum Layers
    {
        Presentation,
        BLL,
        DAL
    };
}