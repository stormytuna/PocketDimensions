using PocketDimensions.Content;
using SubworldLibrary;
using Terraria;
using Terraria.ModLoader;

namespace PocketDimensions.Common.Commands;

public class EnterSubworld : ModCommand
{
	public override void Action(CommandCaller caller, string input, string[] args) {
		if (Main.LocalPlayer.HeldItem.ModItem is ResonantShard resonantShard) {
			ModContent.GetInstance<RubySubworld>().CurrentOptions = resonantShard.Options;
			SubworldSystem.Enter<RubySubworld>();
		}
	}

	public override string Command => "enterSubworld";
	
	public override CommandType Type => CommandType.Chat;
}