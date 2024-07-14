//Task 1 

using System.Text;
using System.Text.RegularExpressions;

int[] arr = {1, 2, 3, 5 };
int lngth =  arr.Length;
for (int i = 0; i < lngth / 2; i++) 
{
    int tmp = arr[i];
    arr[i] = arr[lngth - i - 1];
    arr[lngth - i - 1] = tmp;
}
foreach (var i in arr)
{
    Console.WriteLine(i);
}


//Task 2

string inputText = "I love listening to k-pop and watching youtube every day";
string[] filterDPRK = { "K-pop", "YouTube", "love" };
foreach (var word in filterDPRK)
{
    string filteringWord = $@"\b{word}\b";
    string mask = new string('*', word.Length);
    inputText = Regex.Replace(inputText, filteringWord, mask, RegexOptions.IgnoreCase);
}
Console.WriteLine(inputText);


//Task 3

int charAmount = 6;
Random random = new Random();
StringBuilder sb = new StringBuilder("");
for (int i = 0; i < charAmount; i++)
{
    char generetedChar = (char)random.Next(256);
    sb.Append(generetedChar);
}
string result = sb.ToString();
Console.WriteLine(result);


//Task 4

int[] startArr = {0, 8, 2, 3, 4, 5, 6, 7, 1, 10, 11, 12, 13, 14, 15 };
int n = startArr.Length;
int lostElement = 0;
int sumStartArr=0;
int sum= n * (n+1) / 2;
for (int i = 0; i < n; i++) 
{
    sumStartArr += startArr[i];
}
lostElement = sum  - sumStartArr;
Console.WriteLine(lostElement);


//Task 5

string inputDNA = "AGCT";

int CompressDNA(string DNA)
{
    if (DNA.Length != 4) 
    { 
        Console.WriteLine("It's not a valid DNA string");
        return 0;
    }
    int codeDNA = 0;
    int chrCode = 0;
    int n = 1000;
    foreach (char c in DNA) 
    {
        switch (c)
        {
            case 'A': 
                chrCode = 1;
                break;
            case 'G':
                chrCode = 2;
                break;
            case 'C':
                chrCode = 3;
                break;
            case 'T':
                chrCode = 4;
                break;
        }
        codeDNA = codeDNA + chrCode * n;
        n /= 10;
    }
    return codeDNA;
}

string DecompressDNA(int codeDNA)
{
    if (codeDNA < 1110 || codeDNA >= 10000)
    {
        Console.WriteLine("Invalid codeDNA value");
        return ""; 
    }

    int n = 1000;
    string DNA = "";

    while (n >= 1)
    {
        int digit = codeDNA / n;
        switch (digit)
        {
            case 1:
                DNA += 'A';
                break;
            case 2:
                DNA += 'G';
                break;
            case 3:
                DNA += 'C';
                break;
            case 4:
                DNA += 'T';
                break;
        }

        codeDNA %= n;
        n /= 10;
    }

    return DNA;
}
Console.WriteLine(CompressDNA(inputDNA));
Console.WriteLine(DecompressDNA(CompressDNA(inputDNA)));


//Task 6

string EncryptString(string input, string key)
{
    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
    byte[] keyBytes = Encoding.UTF8.GetBytes(key);

    for (int i = 0; i < inputBytes.Length; i++)
    {
        inputBytes[i] = (byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
    }

    return Convert.ToBase64String(inputBytes);
}

string DecryptString(string input, string key)
{
    byte[] inputBytes = Convert.FromBase64String(input);
    byte[] keyBytes = Encoding.UTF8.GetBytes(key);

    for (int i = 0; i < inputBytes.Length; i++)
    {
        inputBytes[i] = (byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
    }

    return Encoding.UTF8.GetString(inputBytes);
}

string key = "keykey";
Console.WriteLine(EncryptString(inputText, key));
Console.WriteLine(DecryptString(EncryptString(inputText, key), key));