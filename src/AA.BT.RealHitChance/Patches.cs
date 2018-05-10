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

using AA.BT.RealHitChance;
using Harmony;
using System;
using System.Collections.Generic;

namespace RealHitChance
{
	[HarmonyPatch(typeof(BattleTech.UI.CombatHUDWeaponSlot), "SetHitChance", new Type[] { typeof(float) })]
	public static class CombatHUDWeaponSlotHitChancePatch
	{
		/// <summary> Adjust hit chance displayed in UI for correction function applied to to-hit rolls. </summary>
		[HarmonyPrefix]
		public static void Prefix(ref float chance)
		{
			// ideally we'd want to check if (BattleTech.AttackDirector.AttackSequence.UseWeightedHitNumber == true)
			// but currently it is always true

			chance = HitChanceUtils.InverseRollCorrection(chance);
		}

		/// <summary> Cap displayed hit chance at 100% instead of 95% </summary>
		[HarmonyTranspiler]
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			foreach (var inst in instructions)
			{
				if (95f.Equals(inst.operand))
				{
					inst.operand = 100f;
				}
			}
			return instructions;
		}
	}
}
