#region license
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
using RealHitChance;
using System;
using Xunit;

namespace AA.BT.RealHitChance.UnitTests
{
	public class HitChancePatchTests
	{
		[Fact]
		public void CapsAt100()
		{
			var original = AccessTools.Method(typeof(BattleTech.UI.CombatHUDWeaponSlot), "SetHitChance", new Type[] { typeof(float) });
			Assert.NotNull(original);

			var transpiler = AccessTools.Method(typeof(CombatHUDWeaponSlotHitChancePatch), "Transpiler");
			Assert.NotNull(transpiler);

			var harmony = HarmonyInstance.Create("aa.battletech.realhitchance.tests");
			harmony.Patch(original, null, null, new HarmonyMethod(transpiler));

			var sut = TestableObjectFactory.Create<BattleTech.UI.CombatHUDWeaponSlot>();
			sut.HitChanceText = TestableObjectFactory.Create<TMPro.TextMeshProUGUI>();
			sut.SetHitChance(1.01f);
			Assert.Equal("100%", sut.HitChanceText.text);
		}
	}
}
