
//string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string path = @"C:\Dados\";
string file = "arquivo.txt";

if (!Directory.Exists(path))
{
    Directory.CreateDirectory(path);
}

if (File.Exists(path + file)){

    StreamReader sr = new StreamReader(path + file);
    string line = sr.ReadToEnd();
    Console.Clear();
    Console.WriteLine(line);
    sr.Close();

    line += Console.ReadLine();
    StreamWriter sw = new StreamWriter(path + file);
    sw.WriteLine(line);
    sw.Close();
    
    
    Console.Clear();
    
    StreamReader sr2 = new StreamReader(path + file);

    Console.WriteLine(sr2.ReadToEnd());

    var retorno = File.ReadLines(path + file).ElementAt(2) ;

    Console.WriteLine(retorno);

    Console.ReadKey();

    int item = 0;

    foreach(string linha in File.ReadLines(path + file)){
        item++;
        if(item == 3)
        {
            Console.WriteLine(linha);
        }
    }
}
