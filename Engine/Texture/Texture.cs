using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Voxelized.Engine.Textures;

public class Texture {
  private readonly int _handle;

  public Texture(int glHandle) {
    _handle = glHandle;
  }

  public static Texture LoadFromFile(string path) {
    int handle = GL.GenTexture();

    GL.ActiveTexture(TextureUnit.Texture0);
    GL.BindTexture(TextureTarget.Texture2D, handle);

    Image<Rgba32> image = Image.Load<Rgba32>(path);
    image.Mutate(x => x.Flip(FlipMode.Vertical));

    var pixels = new List<byte>(4 * image.Width * image.Height);

    for(short y=0; y<image.Height; y++) {
      var row = image.GetPixelRowSpan(y);

      for(short x=0; x<image.Width; x++) {
        pixels.Add(row[x].R);
        pixels.Add(row[x].G);
        pixels.Add(row[x].B);
        pixels.Add(row[x].A);
      }
    }

    GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0,
      PixelFormat.Rgba, PixelType.UnsignedByte, pixels.ToArray());

    GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

    return new Texture(handle);
  }

  public void Use(TextureUnit unit) {
    GL.ActiveTexture(unit);
    GL.BindTexture(TextureTarget.Texture2D, _handle);
  }

  public int GetHandle() {
    return _handle;
  }
}