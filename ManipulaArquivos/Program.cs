using ManipulaArquivos;

string path = @"C:\DadosEstoque\";
string file = "productsTeste.txt";

Product CreateProduct()
{
    Console.WriteLine("informe um id:");
    int id = int.Parse(Console.ReadLine());

    Console.WriteLine("Informe a descrição do produto:");
    string description = Console.ReadLine();

    Console.WriteLine("Informe o preço do produto:");
    double price = double.Parse(Console.ReadLine());

    Console.WriteLine("Informe a quantidade disponível:");
    int quantity = int.Parse(Console.ReadLine());

    return new Product(id, description, price, quantity);
}

void ShowAll(List<Product> recievedList)
{
    foreach (Product product in recievedList)
    {
        Console.WriteLine(product.ToString());
    }
}

bool CheckIfExists(string p, string f)
{
    if (!Directory.Exists(p))
    {
        Directory.CreateDirectory(p);
    }
    if (!File.Exists(p + f))
    {
        File.Create(p + f);
    }

    return true;
}

void SaveFile(List<Product> l, string p, string f)
{
    if (CheckIfExists(p, f))
    {
        StreamWriter sw = new(p + f);
     
        foreach (var item in l)
        {

            sw.WriteLine(item.ToString());
        }

        sw.Close();
    }

}


List<Product> LoadFile(string p, string f)
{
    List<Product> l = new();
    if (CheckIfExists(p, f))
    {
        string[] data;

        foreach (var linha in File.ReadAllLines(p + f))
        {
            data = linha.Split(";");
            l.Add(new Product(int.Parse(data[0]), data[1], double.Parse(data[2]), int.Parse(data[3])));
        }
    }
    return l;
}

Console.WriteLine(">>> CADASTRO DE PRODUTOS<<<");

//List<Product> products = new();

//products.Add(CreateProduct());

List<Product> products2 = new(LoadFile(path, file));

products2.Add(CreateProduct());

SaveFile(products2, path, file);

ShowAll(products2);



