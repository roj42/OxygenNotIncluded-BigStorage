using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CaiLib.Logger
{
	// Token: 0x0200000C RID: 12
	public static class Logger
	{
		// Token: 0x06000016 RID: 22 RVA: 0x00002470 File Offset: 0x00000670
		public static void LogInit()
		{
            string message = string.Format("{0} <<-- CaiLib -->> Loaded [ {1} ] with version {2}", Logger.Timestamp(), Logger.GetModName(), Assembly.GetExecutingAssembly().GetName().Version);
            Console.WriteLine(message);
            //using (StreamWriter writer = File.CreateText("BigStorageLog.txt"))
            //{
            //    writer.WriteLine(message);
            //}
        }

		// Token: 0x06000017 RID: 23 RVA: 0x0000249C File Offset: 0x0000069C
		public static void Log(string message)
		{
            string logline = string.Concat(new string[]
                {
                        Logger.Timestamp(),
                        " <<-- ",
                        Logger.GetModName(),
                        " -->> ",
                        message
                });
            Console.WriteLine(logline);

            //using (StreamWriter writer = File.AppendText("BigStorageLog.txt"))
            //{
            //    writer.WriteLine(logline);
            //}
        }

		// Token: 0x06000018 RID: 24 RVA: 0x000024D4 File Offset: 0x000006D4
		private static string Timestamp()
		{
			return System.DateTime.UtcNow.ToString("[HH:mm:ss.fff]");
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000024F8 File Offset: 0x000006F8
		private static string GetModName()
		{
			if (Logger._modName != string.Empty)
			{
				return Logger._modName;
			}
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string name = executingAssembly.GetName().Name;
			Type type = executingAssembly.GetExportedTypes().FirstOrDefault((Type p) => p.GetInterfaces().Contains(typeof(IModInfo)));
			if (type == null)
			{
				return name;
			}
			object obj = Activator.CreateInstance(type);
			PropertyInfo property = type.GetProperty("Name");
			object obj2 = (property != null) ? property.GetValue(obj, null) : null;
			Logger._modName = ((obj2 == null) ? name : obj2.ToString());
			return Logger._modName;
		}

		// Token: 0x04000004 RID: 4
		private static string _modName = string.Empty;
	}
}
