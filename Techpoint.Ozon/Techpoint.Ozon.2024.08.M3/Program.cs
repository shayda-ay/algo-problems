using System;
using System.Collections;
using System.IO;

/*
 * ProductID
 */
public class Program {
    public class Product {
        public uint Id;
        public string Name;
        public uint TimeStart;
        public uint? TimeEnd = null;
        public Product(uint id, string name, uint timeStart) {
            Id = id;
            Name = name;
            TimeStart = timeStart;
        }
        public void SetTimeEnd(uint timeEnd) {
            TimeEnd = timeEnd;
        }
    }
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        uint t = uint.Parse(input.ReadLine());
        while (t > 0) {
            uint n = uint.Parse(input.ReadLine());

            uint i = 1;
            var products = new Product[n];
            var hashById = new Dictionary<uint, List<uint>>();
            var hashByName = new Dictionary<string, List<uint>>();

            while (i <= n) {
                var line = input.ReadLine().Split(' ');
                if (line[0] == "CHANGE") {
                    uint Id = uint.Parse(line[2]);
                    if (hashById.ContainsKey(Id)) {
                        var lastIndexById = hashById[Id].LastOrDefault();
                        var lastProductByIndex = products[lastIndexById - 1];
                        if (lastProductByIndex is not null && lastProductByIndex.Name != line[1] && !lastProductByIndex.TimeEnd.HasValue) {
                            lastProductByIndex.SetTimeEnd(i - 1);
                        }
                    }

                    if (hashByName.ContainsKey(line[1])) {
                        var lastIndexByName = hashByName[line[1]].LastOrDefault();
                        var lastProductByIndex = products[lastIndexByName - 1];
                        if (lastProductByIndex is not null && !lastProductByIndex.TimeEnd.HasValue) {
                            if (lastProductByIndex.Id != Id) {
                                lastProductByIndex.SetTimeEnd(i - 1);
                                products[i - 1] = new Product(Id, line[1], i);

                                AddToHashById(Id, i, hashById);
                                AddToHashByName(line[1], i, hashByName);
                            }
                        } else {
                            products[i - 1] = new Product(Id, line[1], i);
                            AddToHashById(Id, i, hashById);
                            AddToHashByName(line[1], i, hashByName);
                        }
                    } else {
                        products[i - 1] = new Product(Id, line[1], i);
                        AddToHashById(Id, i, hashById);
                        AddToHashByName(line[1], i, hashByName);
                    }
                } else if (line[0] == "GET") {
                    uint time = uint.Parse(line[2]);
                    uint Id = uint.Parse(line[1]);
                    if (hashById.ContainsKey(Id)) {
                        Product find = null;
                        foreach (var it in hashById[Id]) {
                            var productByIndex = products[it - 1];
                            if (productByIndex != null && productByIndex.TimeStart <= time && (productByIndex.TimeEnd == null || productByIndex.TimeEnd >= time)) {
                                find = productByIndex;
                                break;
                            }
                        }
                        if (find is not null) {
                            output.WriteLine(find.Name);
                        } else {
                            output.WriteLine("404");
                        }
                    } else {
                        output.WriteLine("404");
                    }
                }
                i++;
            }
            t--;
        }
    }
    private static void AddToHashById(uint id, uint index, Dictionary<uint, List<uint>> hashById) {
        if (!hashById.ContainsKey(id)) {
            hashById.Add(id, new List<uint>() { index });
        } else {
            hashById[id].Add(index);
        }
    }
    private static void AddToHashByName(string name, uint index, Dictionary<string, List<uint>> hashByName) {
        if (!hashByName.ContainsKey(name)) {
            hashByName.Add(name, new List<uint>() { index });
        } else {
            hashByName[name].Add(index);
        }
    }
}


/* 
 * Вариант на без индексов не укладывается в ограничение по скорости
 * 
using System;
using System.Diagnostics;
using System.IO;


public class Program {
    public class Product {
        public string Id;
        public string Name;
        public uint TimeStart;
        public uint? TimeEnd = null;
        public Product(string id, string name, uint timeStart) {
            Id = id;
            Name = name;
            TimeStart = timeStart;
        }
        public void SetTimeEnd(uint timeEnd) {
            TimeEnd = timeEnd;
        }
    }
    public static void Main(string[] args) {
        using var input = new StreamReader(Console.OpenStandardInput());
        using var output = new StreamWriter(Console.OpenStandardOutput());

        uint t = uint.Parse(input.ReadLine());
        while (t > 0) {
            uint n = uint.Parse(input.ReadLine());
            uint i = 1;
            var products = new List<Product>();
            while (i <= n) {
                var line = input.ReadLine().Split(' ');
                if (line[0] == "CHANGE") {
                    var lastById = products.Where(x => x.Id == line[2] && x.Name != line[1] && !x.TimeEnd.HasValue).LastOrDefault();
                    if (lastById is not null) {
                        lastById.SetTimeEnd(i - 1);
                    }

                    var byName = products.Where(x => x.Name == line[1]).LastOrDefault();
                    if (byName is not null && !byName.TimeEnd.HasValue) {
                        if (byName.Id != line[2]) {
                            byName.SetTimeEnd(i - 1);
                            products.Add(new Product(line[2], line[1], i));
                        }
                    } else {
                        products.Add(new Product(line[2], line[1], i));
                    }
                } else if (line[0] == "GET") {
                    uint time = uint.Parse(line[2]);
                    var find = products.Where(x => x.Id == line[1] && x.TimeStart <= time && (x.TimeEnd == null || x.TimeEnd >= time)).FirstOrDefault();
                    if (find is not null) {
                        output.WriteLine(find.Name);
                    } else {
                        output.WriteLine("404");
                    }
                }
                i++;
            } 
            t--;
        } 
    }
}*/