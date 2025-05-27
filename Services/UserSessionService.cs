#nullable enable
namespace EventEaseApp.Services
{
    public class UserSessionService
    {
        public string? CurrentUser { get; private set; }

        // Track registrations: key = event name, value = attending status
        private readonly Dictionary<string, bool> _eventAttendance = new();

        public void SetUser(string username)
        {
            CurrentUser = username;
        }

        public void RegisterForEvent(string eventName)
        {
            _eventAttendance[eventName] = true; // Default to attending
        }

        public void ToggleAttendance(string eventName)
        {
            if (_eventAttendance.ContainsKey(eventName))
                _eventAttendance[eventName] = !_eventAttendance[eventName];
        }

        public bool IsAttending(string eventName)
        {
            return _eventAttendance.TryGetValue(eventName, out var attending) && attending;
        }

        public IEnumerable<string> RegisteredEvents => _eventAttendance.Keys;

        public IEnumerable<(string EventName, bool Attending)> GetEventAttendance()
            => _eventAttendance.Select(kvp => (kvp.Key, kvp.Value));
    }
}
