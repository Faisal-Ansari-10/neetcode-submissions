public class TimeMap {
    private readonly Dictionary<string, List<(string value, int timestamp)>> _store = [];

    public TimeMap() {}

    public void Set(string key, string value, int timestamp) {
        if (!_store.TryGetValue(key, out var list)) {
            list = new List<(string, int)>();
            _store[key] = list;
        }
        list.Add((value, timestamp));
    }

    public string Get(string key, int timestamp) {
    if (!_store.TryGetValue(key, out var list))
        return "";

    string result = "";
    int lo = 0, hi = list.Count - 1;

    while (lo <= hi)
    {
        int mid = lo + (hi - lo) / 2;

        if (list[mid].timestamp <= timestamp)
        {
            result = list[mid].value;
            lo = mid + 1;
        }
        else
        {
            hi = mid - 1;
        }
    }

    return result;
}
}
