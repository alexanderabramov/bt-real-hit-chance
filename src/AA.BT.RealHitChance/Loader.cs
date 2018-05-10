﻿#region license
// Copyright 2018 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Refer to LICENSE for more information.
#endregion license

using Harmony;
using System.Reflection;

namespace RealHitChance
{
	public static class Loader
	{
		// This will hopefully be called by BTModLoader
		public static void Init()
		{
			var harmony = HarmonyInstance.Create("aa.battletech.realhitchance");
			harmony.PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}