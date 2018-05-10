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

using BattleTech;
using System;
using System.Reflection;
using System.Runtime.Serialization;
using Xunit;

namespace AA.BT.RealHitChance.UnitTests
{
	public class HitChanceUtilsTests
	{
		private AttackDirector.AttackSequence noninstance;
		private MethodInfo getCorrectedRoll;

		private float GetCorrectedRoll(float roll)
		{
			if (getCorrectedRoll == null)
			{
				Type t = typeof(AttackDirector.AttackSequence);
				noninstance = (AttackDirector.AttackSequence)FormatterServices.GetSafeUninitializedObject(t);
				getCorrectedRoll = t.GetMethod("GetCorrectedRoll", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			return (float)getCorrectedRoll.Invoke(noninstance, new Object[] { roll, null });
		}

		[Fact]
		public void HitChanceInversionIsCorrect()
		{
			for (float roll = 0; roll <= 1f; roll += 0.01f)
			{
				float corrected = GetCorrectedRoll(roll);
				float decorrected = HitChanceUtils.InverseRollCorrection(roll);
				float recorrected = GetCorrectedRoll(decorrected);
				float redecorrected = HitChanceUtils.InverseRollCorrection(corrected);

				Assert.Equal(roll, recorrected, 5);
				Assert.Equal(roll, redecorrected, 5);
			}
		}
	}
}
