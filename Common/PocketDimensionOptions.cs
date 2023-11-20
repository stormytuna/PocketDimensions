using System;
using Terraria.ModLoader.IO;

namespace PocketDimensions.Common;

public class PocketDimensionOptions : TagSerializable
{
	public int Width { get; init; }
	public int Height { get; init; }
	public string Name { get; init; }

	public PocketDimensionOptions(int width, int height, string name) {
		Width = width;
		Height = height;
		Name = name;
	}

	public PocketDimensionOptions(TagCompound tag) {
		Width = tag.GetInt(nameof(Width));
		Height = tag.GetInt(nameof(Height));
		Name = tag.GetString(nameof(Name));
	}

	public static readonly Func<TagCompound, PocketDimensionOptions> DESERIALIZER = tag => new PocketDimensionOptions(tag);

	public TagCompound SerializeData() =>
		new TagCompound {
			{ nameof(Width), Width },
			{ nameof(Height), Height },
			{ nameof(Name), Name }
		};
}