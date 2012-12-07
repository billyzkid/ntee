using System;
using System.Collections.Generic;
using System.IO;

namespace ntee
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			try
			{
				if (args.Length >= 1)
				{
					bool help = false;
					bool append = false;
					List<string> files = new List<string>();

					foreach (string arg in args)
					{
						if (arg == "/?")
							help = true;
						else if (arg.Equals("/A", StringComparison.InvariantCultureIgnoreCase) || arg.Equals("/APPEND", StringComparison.InvariantCultureIgnoreCase))
							append = true;
						else
							files.Add(arg);
					}

					if (help)
					{
						Console.WriteLine("Echos and redirects standard input to one or more files.");
						Console.WriteLine();
						Console.WriteLine("NTEE /APPEND file1 [file2] [file3]...");
						Environment.Exit(0);
					}
					else
					{
						int bytesRead;
						var buffer = new char[100];
						var outputs = new List<TextWriter>();

						outputs.Add(Console.Out);

						foreach (string file in files)
							outputs.Add(new StreamWriter(file, append));

						do
						{
							bytesRead = Console.In.ReadBlock(buffer, 0, buffer.Length);
							outputs.ForEach(o => o.Write(buffer, 0, bytesRead));

						} while (bytesRead == buffer.Length);

						outputs.ForEach(o => o.Close());
						Environment.Exit(0);
					}
				}
				else
				{
					Console.WriteLine("Invalid number of parameters");
					Environment.Exit(1);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Environment.Exit(1);
			}
		}
	}
}