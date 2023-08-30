using System.Text.Json;

var board = new char[][] {
    new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
    new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
    new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
    new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
    new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
    new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
    new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
    new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
    new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
};


var solution = new Solution();
var result = solution.IsValidSudoku(board);
string resultJson = JsonSerializer.Serialize(result);
Console.WriteLine(resultJson);
Console.ReadLine();

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        var hashes = Enumerable.Range(1, board.Length)
            .Select(n => new HashSet<char>());

        var rowHashes = hashes.ToArray();
        var columnHashes = hashes.ToArray();
        var boxHashes = hashes.ToArray();

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board.Length; j++)
            {
                if (board[i][j] == '.')
                {
                    continue;
                }

                if (!char.IsDigit(board[i][j]))
                {
                    return false;
                }

                if (rowHashes[i].Contains(board[i][j]) 
                    || columnHashes[j].Contains(board[i][j])
                    || boxHashes[GetBoxIndex(i, j)].Contains(board[i][j]))
                {
                    return false;
                }

                rowHashes[i].Add(board[i][j]);
                columnHashes[j].Add(board[i][j]);
                boxHashes[GetBoxIndex(i, j)].Add(board[i][j]);
            }
        }

        return true;
    }

    public int GetBoxIndex(int i, int j)
    {
        var rowBoxesAccumulator = (i / 3) * 3;
        var colBoxes = (j / 3);

        return rowBoxesAccumulator + colBoxes;
    }
}