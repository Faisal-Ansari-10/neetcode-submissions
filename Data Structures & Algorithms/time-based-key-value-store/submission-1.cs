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
        if (!_store.TryGetValue(key, out var list)) {
            return "";
        }

        int lo = 0, hi = list.Count - 1;

        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            int value = list[mid].timestamp;
            if (timestamp == value)
                return list[mid].value;
            if (timestamp > value)
                lo = mid + 1;
            else
                hi = mid - 1;
        }

        return hi >= 0 ?list[hi].value : "";
    }
}
