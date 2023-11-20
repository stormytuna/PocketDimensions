using System.Collections.Generic;
using SubworldLibrary;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace PocketDimensions.Common;

public abstract class PocketDimensionSubworld : Subworld
{
	public PocketDimensionOptions CurrentOptions { get; set; }

	public override int Width => CurrentOptions.Width;
	public override int Height => CurrentOptions.Height;

	public override bool ShouldSave => true;
	public override bool NoPlayerSaving => false;

	public override string Name => CurrentOptions.Name;

	public override List<GenPass> Tasks => new() {
		new ExampleGenPass()
	};

	public override void OnLoad() {
		Main.dayTime = true;
		Main.time = 27000;
	}
}

public class DiamondSubworld : PocketDimensionSubworld
{
	public override void Load() {
		CurrentOptions = new PocketDimensionOptions(0, 0, "Unused_Diamond");
	}
}

public class AmberSubworld : PocketDimensionSubworld
{
	public override void Load() {
		CurrentOptions = new PocketDimensionOptions(0, 0, "Unused_Amber");
	}
}

public class RubySubworld : PocketDimensionSubworld
{
	public override void Load() {
		CurrentOptions = new PocketDimensionOptions(0, 0, "Unused_Ruby");
	}
}

public class EmeraldSubworld : PocketDimensionSubworld
{
	public override void Load() {
		CurrentOptions = new PocketDimensionOptions(0, 0, "Unused_Emerald");
	}
}

public class SapphireSubworld : PocketDimensionSubworld
{
	public override void Load() {
		CurrentOptions = new PocketDimensionOptions(0, 0, "Unused_Sapphire");
	}
}

public class TopazSubworld : PocketDimensionSubworld
{
	public override void Load() {
		CurrentOptions = new PocketDimensionOptions(0, 0, "Unused_Topaz");
	}
}

public class AmethystSubworld : PocketDimensionSubworld
{
	public override void Load() {
		CurrentOptions = new PocketDimensionOptions(0, 0, "Unused_Amethyst");
	}
}

/*
 * Taken from https://github.com/jjohnsnaill/SubworldLibrary/wiki/Home/4fb96b2178fc1b696a08f3f27eae9cc713d671bc#examples
 */
public class ExampleGenPass : GenPass
{
	//TODO: remove this once tML changes generation passes
	public ExampleGenPass() : base("Terrain", 1) { }

	protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
		progress.Message = "Generating terrain"; // Sets the text displayed for this pass
		Main.worldSurface = Main.maxTilesY - 42; // Hides the underground layer just out of bounds
		Main.rockLayer = Main.maxTilesY; // Hides the cavern layer way out of bounds
		for (int i = 0; i < Main.maxTilesX; i++) {
			for (int j = Main.maxTilesY / 2; j < Main.maxTilesY; j++) {
				progress.Set((j + i * Main.maxTilesY) / (float)(Main.maxTilesX * Main.maxTilesY)); // Controls the progress bar, should only be set between 0f and 1f
				Tile tile = Main.tile[i, j];
				tile.HasTile = true;
				tile.TileType = TileID.Dirt;
			}
		}
	}
}