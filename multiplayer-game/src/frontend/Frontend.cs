using System.Numerics;
using static SDL2.SDL;

class Frontend : IFrontend
{
    private string playerName = "Player";

    public void Init()
    {
        this.playerName = Context.Get().IsHost ? "Host" : "Client";
        var conntectPacket = new ConnectPacket(playerName);
        Context.Get().Backend.ProcessPacket(conntectPacket);
    }

    public void Process()
    {
        var ctx = Context.Get();
        while (SDL_PollEvent(out var e) != 0)
        {
            if (e.type == SDL_EventType.SDL_QUIT)
            {
                System.Environment.Exit(0);
            }
            if (e.type == SDL_EventType.SDL_KEYDOWN && e.key.repeat == 0)
            {
                var movementInput = ctx.FrontendGameState.movementInput;
                if (e.key.keysym.scancode == SDL_Scancode.SDL_SCANCODE_A)
                {
                    movementInput.X -= 1;
                }
                if (e.key.keysym.scancode == SDL_Scancode.SDL_SCANCODE_D)
                {
                    movementInput.X += 1;
                }
                if (e.key.keysym.scancode == SDL_Scancode.SDL_SCANCODE_W)
                {
                    movementInput.Y -= 1;
                }
                if (e.key.keysym.scancode == SDL_Scancode.SDL_SCANCODE_S)
                {
                    movementInput.Y += 1;
                }
                ctx.FrontendGameState.movementInput = movementInput;
            }
            if (e.type == SDL_EventType.SDL_KEYUP && e.key.repeat == 0)
            {
                var movementInput = ctx.FrontendGameState.movementInput;
                if (e.key.keysym.scancode == SDL_Scancode.SDL_SCANCODE_A)
                {
                    movementInput.X += 1;
                }
                if (e.key.keysym.scancode == SDL_Scancode.SDL_SCANCODE_D)
                {
                    movementInput.X -= 1;
                }
                if (e.key.keysym.scancode == SDL_Scancode.SDL_SCANCODE_W)
                {
                    movementInput.Y += 1;
                }
                if (e.key.keysym.scancode == SDL_Scancode.SDL_SCANCODE_S)
                {
                    movementInput.Y -= 1;
                }
                ctx.FrontendGameState.movementInput = movementInput;
            }
            if (
                e.key.keysym.scancode
                    is SDL_Scancode.SDL_SCANCODE_A
                        or SDL_Scancode.SDL_SCANCODE_D
                        or SDL_Scancode.SDL_SCANCODE_W
                        or SDL_Scancode.SDL_SCANCODE_S
                && e.key.repeat == 0
                && e.type is SDL_EventType.SDL_KEYDOWN or SDL_EventType.SDL_KEYUP
            )
            {
                if (e.key.repeat == 1)
                    continue;
                var movement = ctx.FrontendGameState.movementInput;
                if (movement.Length() > 0)
                    movement = Vector2.Normalize(movement);
                ctx.Backend.ProcessPacket(new MovePacket(playerName, movement));
            }
            if (e.key.keysym.scancode == SDL_Scancode.SDL_SCANCODE_ESCAPE)
            {
                System.Environment.Exit(0);
            }
        }

        ctx.Renderer.Clear();
        ctx.GameState.PlayerPositions.ForEach(player =>
        {
            if (player.name == playerName)
                ctx.Renderer.SetColor(0, 0, 255, 255);
            else
                ctx.Renderer.SetColor(255, 0, 0, 255);
            ctx.Renderer.DrawRect(player.position.X, player.position.Y, 10, 10);
        });
        ctx.Renderer.Present();
    }
}
