using System;
using System.IO;
using System.Reflection;
using CaiLib.Logger;
using Newtonsoft.Json;
namespace CaiLib.Config
{
	// Token: 0x0200000D RID: 13
	public class ConfigManager<T> where T : class, new()
	{

		public T Config { get; set; }
		public ConfigManager(string executingAssemblyPath = null, string configFileName = "Config.json")
		{
			if (executingAssemblyPath == null)
			{
				executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
			}
			this._executingAssemblyPath = executingAssemblyPath;
			this._configFileName = configFileName;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000025FC File Offset: 0x000007FC
		public T ReadConfig(System.Action postReadAction = null)
		{
			this.Config = Activator.CreateInstance<T>();
			string directoryName = Path.GetDirectoryName(this._executingAssemblyPath);
			if (directoryName == null)
			{
				CaiLib.Logger.Logger.Log(string.Concat(new string[]
				{
					"Error reading config file ",
					this._configFileName,
					" - cannot get directory name for executing assembly path ",
					this._executingAssemblyPath,
					"."
				}));
				return this.Config;
			}
			string path = Path.Combine(directoryName, this._configFileName);
			T config;
			try
			{
				using (StreamReader streamReader = new StreamReader(path))
				{
					config = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
				}
			}
			catch (Exception ex)
			{
				CaiLib.Logger.Logger.Log("Error reading config file " + this._configFileName + " with exception: " + ex.Message);
				return this.Config;
			}
			this.Config = config;
			if (postReadAction != null)
			{
				postReadAction();
			}
			return this.Config;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002708 File Offset: 0x00000908
		public bool SaveConfigToFile()
		{
			string directoryName = Path.GetDirectoryName(this._executingAssemblyPath);
			if (directoryName == null)
			{
				CaiLib.Logger.Logger.Log(string.Concat(new string[]
				{
					"Error reading config file ",
					this._configFileName,
					" - cannot get directory name for executing assembly path ",
					this._executingAssemblyPath,
					"."
				}));
				return false;
			}
			string path = Path.Combine(directoryName, this._configFileName);
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(path))
				{
					string value = JsonConvert.SerializeObject(this.Config, Formatting.Indented);
					streamWriter.Write(value);
				}
			}
			catch (Exception ex)
			{
				CaiLib.Logger.Logger.Log("Error writing to config file " + this._configFileName + " with exception: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x04000006 RID: 6
		private readonly string _executingAssemblyPath;

		// Token: 0x04000007 RID: 7
		private readonly string _configFileName;
	}
}
