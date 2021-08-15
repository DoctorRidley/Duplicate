using System;

namespace Duplicate
{
	public class Check_Sum
	{
		public string file_name { get; private set; }

		public byte[] file_hash { get; private set; }

		public Check_Sum() => (file_name, file_hash) = ("", new byte[0]);

		public Check_Sum(string file, byte[] hash) => (file_name, file_hash) = (file, hash);
	}
}
