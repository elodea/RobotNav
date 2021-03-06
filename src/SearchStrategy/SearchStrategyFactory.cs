﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotNav
{
	public static class SearchStrategyFactory
	{
		public static SearchStrategy Create(string filename, string method, string popSize, string mutRate, string fitMulti, string diversity, string elite, string deepeningInc)
		{
			method = method.ToUpper();

			GAOpts opts = new GAOpts(popSize, mutRate, fitMulti, diversity, elite, deepeningInc);

			switch (method)
			{
				case "DFS":
					return new DFSStrategy(MapFactory.CreateFMap(filename), "DFS");
				case "GBFS":
					return new GBFSStrategy(MapFactory.CreateFMap(filename), "GBFS");
				case "AS":
					return new ASStrategy(MapFactory.CreateFMap(filename), MapFactory.CreateFMap(filename), "A*");
				case "ASFS":
					return new ASFSStrategy(MapFactory.CreateFMap(filename), MapFactory.CreateFMap(filename), "A* Fast Stack");
				case "CUS1":
				case "GA":
					return new GAStrategy(MapFactory.CreateFMap(filename), "Genetic Algorithm", opts);
				case "CUS2":
				case "JPS":
					return new JPSStrategy(MapFactory.CreateFMap(filename), MapFactory.CreateFMap(filename), "JPS");
				case "BFS":
				default:
					return new BFSStrategy(MapFactory.CreateFMap(filename), "BFS");
			}
		}
	}
}
