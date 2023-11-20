using PocketDimensions.Content;
using Terraria;
using Terraria.ModLoader;

namespace PocketDimensions.Common.Commands;

public class ChangeOptions : ModCommand
{
	public override void Action(CommandCaller caller, string input, string[] args) {
		if (Main.LocalPlayer.HeldItem.ModItem is ResonantShard resonantShard) {
			int width = int.Parse(args[0]);
			int height = int.Parse(args[1]);
			string name = args[2];
			resonantShard.options = new PocketDimensionOptions(width, height, name);

			Main.NewText($"Updated options! Width: {width}, Height: {height}, Name: {name}");
		}
	}

	public override string Command => "changeOptions";
	public override CommandType Type => CommandType.Chat;
}