using System;
using System.Collections.Generic;
using System.Linq;
using lab1.Tasks;
using lab1.Helpers;
using System.Xml.Linq;

namespace lab1;
internal class Program
{
	static void Main(string[] args)
	{
		var app = new Helpers.ApplicationRunner();
		app.run(args);
	}
}
