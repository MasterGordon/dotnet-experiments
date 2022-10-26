using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

class Converter
{
    public static ValueType ParsePacket(byte[] bytes)
    {
        var jsonString = Encoding.UTF8.GetString(bytes);
        return ParsePacket(jsonString);
    }

    public static ValueType ParsePacket(string jsonString)
    {
        var parsedRaw = JObject.Parse(jsonString);
        var type = parsedRaw.GetValue("type");
        if (type == null)
        {
            throw new System.Exception("Packet has no type");
        }
        var packetType = type.Value<string>();
        return packetType switch
        {
            "move" => parsedRaw.ToObject<MovePacket>(),
            _ => throw new System.Exception("Unknown packet type")
        };
    }

    public static byte[] SerializePacket(ValueType packet)
    {
        var jsonString = JsonConvert.SerializeObject(packet);
        return Encoding.UTF8.GetBytes(jsonString);
    }
}
