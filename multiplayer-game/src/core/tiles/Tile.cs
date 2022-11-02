using static SDL2.SDL;
using static SDL2.SDL_image;

class Tile
{
    public string Name { get; set; }
    public IntPtr Texture { get; set; }

    public Tile(string name, string textureName)
    {
        this.Name = name;

        var rl = Context.Get().ResourceLoader;
        var res = rl.LoadToIntPtr("assets." + textureName + ".png");
        var sdlBuffer = SDL_RWFromMem(res.ptr, res.size);
        var surface = IMG_Load_RW(sdlBuffer, 1);
        var texture = Context.Get().Renderer.CreateTextureFromSurface(surface);
        this.Texture = texture;
        SDL_FreeSurface(surface);
    }

    ~Tile()
    {
        SDL_DestroyTexture(this.Texture);
    }

    public void Render(int x, int y)
    {
        var renderer = Context.Get().Renderer;
        var scale = Context.Get().GameState.Settings.GameScale;
        var camera = Context.Get().FrontendGameState.Camera;
        renderer.DrawTexture(
            this.Texture,
            (x - (int)camera.position.X) * scale,
            (y - (int)camera.position.Y) * scale,
            16 * scale,
            16 * scale
        );
    }

    public bool IsSolid()
    {
        return true;
    }
}
