public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}

        var l3 = new[] { 'A', 'A', 'A', 'A', 'A'};
        var l4 = new[] { 'B', 'B', 'B', 'B', 'B'};
        select = [1, 2, 1, 2, 1, 2, 1, 2, 1, 2];
        var charResult = ListSelector(l3, l4, select);
        Console.WriteLine("<char[]>{" + string.Join(", ", charResult) + "}"); // <char[]>{A, B, A, B, A, B, A, B, A, B}

    }
    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        List<int> result = new List<int>();
        int index1 = 0, index2 = 0;

        foreach (int s in select)
        {
            if (s == 1) {
                if (index1 < list1.Length) {
                    result.Add(list1[index1++]);
                }
            }
            else if (s == 2) {
                if (index2 < list2.Length) {
                    result.Add(list2[index2++]);
                }
            }
        }
        return result.ToArray();
    }


    private static char[] ListSelector(char[] list1, char[] list2, int[] select)
    {
        char[] charResult = new char[select.Length];
        int index1 = 0, index2 = 0;


        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1) {
                charResult[i] = list1[index1++]; 
            }
            else if (select[i] == 2) {
                charResult[i] = list2[index2++];
            }
        }
        return charResult;
    }
}