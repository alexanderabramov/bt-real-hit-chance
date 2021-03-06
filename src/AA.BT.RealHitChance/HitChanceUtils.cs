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

using System;

namespace AA.BT.RealHitChance
{
	public static class HitChanceUtils
	{
		/// <summary>
		/// Inverse function for AttackDirector.AttackSequence.GetCorrectedRoll
		/// Generated by https://www.wolframalpha.com/input/?i=InverseFunction(((x*1.6-0.8)%5E3%2B0.5)%2F2%2Bx%2F2)
		/// </summary>
		public static float InverseRollCorrection(float chance)
		{
			double x = chance;
			double tmp = Math.Pow(2.44949 * Math.Sqrt(13824 * x * x - 13824 * x + 3581) - 288 * x + 144, 1.0d / 3.0d);
			double result = 0.5d - 0.0946417 * tmp + 0.859877 / tmp;
			return (float)result;
		}
	}
}
