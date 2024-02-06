namespace Oxide.Logging
{
    public struct LogEvent
    {
        private const int GENERIC_ID = 0;
        private const string GENERIC_NAME = "Generic";

        public int Id { get; }

        public string Name { get; }

        public LogEvent()
        {
            Id = GENERIC_ID;
            Name = GENERIC_NAME;
        }

        public LogEvent(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static LogEvent Generic { get; } = new LogEvent(GENERIC_ID, GENERIC_NAME);

        public override string ToString() => $"{Id}:{Name}";
    }
}
