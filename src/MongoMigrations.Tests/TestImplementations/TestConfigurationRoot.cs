using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace MongoMigrations.Tests.TestImplementations
{
	public class TestConfigurationRoot : IConfigurationRoot
	{
		private readonly Dictionary<string, string> _values;

		public TestConfigurationRoot(params KeyValuePair<string, string>[] values)
		{
			_values = values.ToDictionary(v => v.Key, v => v.Value);
		}

		public IConfigurationSection GetSection(string key)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<IConfigurationSection> GetChildren()
		{
			throw new System.NotImplementedException();
		}

		public IChangeToken GetReloadToken()
		{
			throw new System.NotImplementedException();
		}

		public string this[string key]
		{
			get { return _values[key]; }
			set
			{
				if (_values.ContainsKey(key)) _values[key] = value;
				else _values.Add(key, value);
			}
		}

		public void Reload()
		{
			throw new System.NotImplementedException();
		}
	}
}