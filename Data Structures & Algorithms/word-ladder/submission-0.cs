public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        Queue<string> q = new();
        HashSet<string> words = new(wordList);

        if (!words.Contains(endWord))
            return 0;

        int level = 1;
        q.Enqueue(beginWord);
        words.Remove(beginWord);

        while (q.Count > 0) {
            int size = q.Count;

            for (int k = 0; k < size; k++) {
                var word = q.Dequeue();

                if (word == endWord)
                    return level;

                var sb = new StringBuilder(word);

                for (int i = 0; i < word.Length; i++) {
                    char original = sb[i];

                    for (int j = 0; j < 26; j++) {
                        sb[i] = (char)('a' + j);

                        string nextWord = sb.ToString();

                        if (words.Remove(nextWord))
                            q.Enqueue(nextWord);
                    }

                    sb[i] = original;
                }
            }

            level++;
        }

        return 0;
    }
}