using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertPacks.Models
{

	public class FoundryWorld
	{
		public string title { get; set; }
		public string id { get; set; }
		public string system { get; set; }
		public string description { get; set; }
		public string coreVersion { get; set; }
		public FoundryWorldCompatibility compatibility { get; set; }
		public string systemVersion { get; set; }
		public FoundryWorldPack[] packs { get; set; }
	}

	public class FoundryWorldCompatibility
	{
		public string minimum { get; set; }
		public string verified { get; set; }
		public string maximum { get; set; }
	}

	public class FoundryWorldPack
	{
		public string type { get; set; }
		public string label { get; set; }
		public string name { get; set; }
		public string path { get; set; }
		public string system { get; set; }
		public bool _private { get; set; }
		public FoundryWorldFlags flags { get; set; }
	}

	public class FoundryWorldFlags
	{
	}

}
