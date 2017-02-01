using RimWorld;
using System;
using UnityEngine;
using Verse;

namespace AlienRace
{
	public class GraphicGetterAlienBody
	{
		public static Graphic GetNakedBodyGraphicAlien(BodyType bodyType, Shader shader, Color skinColor, string userpath, Vector2 drawsize)
		{
			bool flag = bodyType == BodyType.Undefined;
			if (flag)
			{
				Log.Error("Getting naked body graphic with undefined body type.");
				bodyType = BodyType.Male;
			}
			string str = "Naked_" + bodyType.ToString();
			string path = userpath + str;
			return GraphicDatabase.Get<Graphic_Multi>(path, shader, drawsize, skinColor);
		}
	}
}
