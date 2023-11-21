using System.Collections.Generic;
using PocketDimensions.Common;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace PocketDimensions.Content;

public class ResonantShard : ModItem
{
	public PocketDimensionOptions Options { get; set; } = new(1000, 1000, "Test");

	public override void SaveData(TagCompound tag) {
		tag[nameof(PocketDimensionOptions)] = options;
	}

	public override void LoadData(TagCompound tag) {
		options = tag.Get<PocketDimensionOptions>(nameof(PocketDimensionOptions)) ?? new PocketDimensionOptions(0, 0, "");
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips) {
		int index = tooltips.FindIndex(tip => tip.Name == "Tooltip0");
		if (index < 0) {
			return;
		}

		tooltips.RemoveAt(index);
		tooltips.InsertRange(index, new List<TooltipLine> {
			new(Mod, "Tooltip0", $"Width: {options.Width}"),
			new(Mod, "Tooltip0", $"Height: {options.Height}"),
			new(Mod, "Tooltip0", $"Name: {options.Name}")
		});
	}
}