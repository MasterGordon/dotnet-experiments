using System.Numerics;
using static SDL2.SDL;

class Frontend : IFrontend
{
    public void Init()
    {
        var conntectPacket = new ConnectPacket("Gordon");
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
            if (e.key.keysym.scancode is
                SDL_Scancode.SDL_SCANCODE_A or SDL_Scancode.SDL_SCANCODE_D or SDL_Scancode.SDL_SCANCODE_W or SDL_Scancode.SDL_SCANCODE_S)
            {
                var movement = ctx.FrontendGameState.movementInput;
                if (movement.Length() > 0)
                    movement = Vector2.Normalize(movement);
                ctx.Backend.ProcessPacket(new MovePacket("Gordon", movement));
            }
            if (e.key.keysym.scancode == SDL_Scancode.SDL_SCANCODE_ESCAPE)
            {
                System.Environment.Exit(0);
            }
        }

        ctx.Renderer.Clear();
        ctx.Renderer.SetColor(255, 0, 0, 255);
        ctx.GameState.PlayerPositions.ForEach(player =>
        {
            ctx.Renderer.DrawRect(player.position.X, player.position.Y, 10, 10);
        });
        ctx.Renderer.Present();
    }
}