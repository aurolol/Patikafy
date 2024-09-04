using Patikafy;
using System.Threading.Channels;

List<Singer> singers = new List<Singer>
{
    new Singer() { FullName = "Ajda Pekkan", MusicType = "Pop", OutYear = 1968, AlbumSales = 20},
    new Singer() { FullName = "Sezen Aksu", MusicType = "Türk Halk Müziği / Pop", OutYear = 1971, AlbumSales = 10 },
    new Singer() { FullName = "Funda Arar", MusicType = "Pop", OutYear = 1999, AlbumSales = 3 },
    new Singer() { FullName = "Sertab Erener", MusicType = "Pop", OutYear = 1994, AlbumSales = 5 },
    new Singer() { FullName = "Sıla", MusicType = "Pop", OutYear = 2009, AlbumSales = 3 },
    new Singer() { FullName = "Serdar Ortaç", MusicType = "Pop", OutYear = 1994, AlbumSales = 10 },
    new Singer() { FullName = "Tarkan", MusicType = "Pop", OutYear = 1992, AlbumSales = 40 },
    new Singer() { FullName = "Hande Yener", MusicType = "Pop", OutYear = 1999, AlbumSales = 7 },
    new Singer() { FullName = "Hadise", MusicType = "Pop", OutYear = 2005, AlbumSales = 5 },
    new Singer() { FullName = "Gülben Ergen", MusicType = "Pop / Türk Halk Müziği", OutYear = 1997, AlbumSales = 10 },
    new Singer() { FullName = "Neşet Ertaş", MusicType = "Türk Halk Müziği / Türk Sanat Müziği", OutYear = 1960, AlbumSales = 2 }
};

var startWithS = singers.Where(x => x.FullName.StartsWith('S'));

Console.WriteLine("↓ Adı 'S' ile başlayan şarkıcılar ↓\n");

foreach (var singer in startWithS)
{
    Console.WriteLine(singer.FullName);
}

var albumSales = singers.Where(x => x.AlbumSales > 10);

Console.WriteLine("\n↓ Albüm satışları 10 milyon'un üzerinde olan şarkıcılar ↓\n");

foreach (var item in albumSales)
{
    Console.WriteLine($"{item.FullName} şarkıcının yaptığı albüm satışı -> {item.AlbumSales}");
}

var groupByYear = singers.Where(x => x.OutYear < 2000 && x.MusicType.Contains("Pop"))
                         .OrderBy(x => x.FullName)
                         .GroupBy(x => x.OutYear);

Console.WriteLine("\n↓ 2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar ↓\n");

foreach (var item in groupByYear)
{
    Console.WriteLine(item.Key);
    
    foreach (var singer in item)
    {
        Console.WriteLine(singer.FullName);
    }
}

Console.WriteLine("\n↓ En çok albüm satan şarkıcı ↓\n");

var mostSelling = singers.OrderByDescending(x => x.FullName).FirstOrDefault();

Console.WriteLine(mostSelling.FullName);

Console.WriteLine("\n↓ En yeni çıkış yapan şarkıcı ve en eski çıkış yapan şarkıcı ↓\n");

var bestDebut = singers.OrderByDescending(x => x.OutYear).FirstOrDefault();

Console.WriteLine($"En yeni çıkış yapan şarkıcı -> {bestDebut.FullName}");

var oldestDebut = singers.OrderBy(x => x.OutYear).FirstOrDefault();

Console.WriteLine($"En eski çıkış yapan şarkıcı -> {oldestDebut.FullName}");