[AttributeUsage(AttributeTargets.Method)]
class OnECSEvent : Attribute
{
    public EventPriority Priority = EventPriority.Normal;
}

class OnTickEvent : OnECSEvent
{
}

struct TickEvent
{
    public int Tick;
}

class OnKeyDownEvent : OnECSEvent
{
    public SDL2.SDL.SDL_Scancode? Scancode;
}

class KeyEvent
{
    public SDL2.SDL.SDL_Scancode Scancode;
    public bool Canceled;
}

class OnKeyUpEvent : OnECSEvent
{
    public SDL2.SDL.SDL_Scancode? Scancode;
}

class OnMouseButtonDownEvent : OnECSEvent
{
    public SDL2.SDL.SDL_Scancode? Scancode;
}
