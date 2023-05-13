using System.Diagnostics.Metrics;

namespace Composite
{
    public abstract class SongComponent
    {
        public string Name { get; set; }

        public SongComponent(string name)
        {
            Name = name;
        }

        public virtual void Play() { }
        public virtual void Add(SongComponent component) { }
        public virtual void Remove(SongComponent component) { }
    }

    public class Song : SongComponent
    {
        public Song(string name) : base(name)
        {
        }

        public override void Play()
        {
            Console.WriteLine("Playing song: " + Name);
        }
    }

    public class SongGroup : SongComponent
    {
        private List<SongComponent> songComponents;

        public SongGroup(string name) : base(name)
        {
            songComponents = new List<SongComponent>();
        }

        public override void Play()
        {
            Console.WriteLine("Playing song group: " + Name);
            foreach (SongComponent songComponent in songComponents)
            {
                songComponent.Play();
            }
        }

        public override void Add(SongComponent songComponent)
        {
            songComponents.Add(songComponent);
        }

        public override void Remove(SongComponent songComponent)
        {
            songComponents.Remove(songComponent);
        }
    }

    class Client
    {
        public static void ClientCode(SongComponent sc)
        {
            sc.Play();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SongComponent everySong = new SongGroup("All Songs");
            SongComponent rockMusic = new SongGroup("Rock Music");
            SongComponent popMusic = new SongGroup("Pop Music");
            SongComponent metalMusic = new SongGroup("Metal Music");

            SongComponent metallica = new SongGroup("Metallica");
            metallica.Add(new Song("Enter Sandman"));
            metallica.Add(new Song("Master of Puppets"));

            SongComponent popIdols = new SongGroup("Pop Idols");
            popIdols.Add(new Song("Britney Spears - Toxic"));
            popIdols.Add(new Song("Justin Bieber - Let me love you"));

            rockMusic.Add(new Song("Led Zeppelin - Stairway to Heaven"));
            rockMusic.Add(new Song("AC/DC - Thunderstruck"));
            rockMusic.Add(metallica);

            metalMusic.Add(new Song("Slipknot - Duality"));
            metalMusic.Add(new Song("Iron Maiden - Fear of the Dark"));

            popMusic.Add(new Song("Michael Jackson - Beat It"));
            popMusic.Add(popIdols);

            everySong.Add(rockMusic);
            everySong.Add(popMusic);
            everySong.Add(metalMusic);



            Client.ClientCode(everySong);
            Console.WriteLine();
            Client.ClientCode(new Song("Britney Spears - Toxic"));

            Console.ReadLine();
        }
    }
}

//Playing song group: All Songs
//Playing song group: Rock Music
//Playing song: Led Zeppelin - Stairway to Heaven
//Playing song: AC / DC - Thunderstruck
//Playing song group: Metallica
//Playing song: Enter Sandman
//Playing song: Master of Puppets
//Playing song group: Pop Music
//Playing song: Michael Jackson - Beat It
//Playing song group: Pop Idols
//Playing song: Britney Spears - Toxic
//Playing song: Justin Bieber - Let me love you
//Playing song group: Metal Music
//Playing song: Slipknot - Duality
//Playing song: Iron Maiden - Fear of the Dark

//Playing song: Britney Spears - Toxic




// Эквивалентный пример кода для создания плейлиста с песнями без использования паттерна Composite:

//    public class Song
//    {
//        public string Name { get; set; }

//        public Song(string name)
//        {
//            Name = name;
//        }

//        public void Play()
//        {
//            Console.WriteLine("Playing song: " + Name);
//        }
//    }

//    public class Playlist
//    {
//        public string Name { get; set; }
//        private List<Song> songs;

//        public Playlist(string name)
//        {
//            Name = name;
//            songs = new List<Song>();
//        }

//        public void AddSong(Song song)
//        {
//            songs.Add(song);
//        }

//        public void RemoveSong(Song song)
//        {
//            songs.Remove(song);
//        }

//        public void Play()
//        {
//            Console.WriteLine("Playing playlist: " + Name);
//            foreach (Song song in songs)
//            {
//                song.Play();
//            }
//        }
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        //В этом примере мы создали класс Song для представления песни и класс Playlist
//        //для представления плейлиста. Класс Playlist содержит список песен songs.
//        //Мы можем использовать эти классы для создания плейлиста с песнями:

//        Playlist myPlaylist = new Playlist("My Playlist");

//        myPlaylist.AddSong(new Song("Led Zeppelin - Stairway to Heaven"));
//        myPlaylist.AddSong(new Song("AC/DC - Thunderstruck"));
//        myPlaylist.AddSong(new Song("Slipknot - Duality"));
//        myPlaylist.AddSong(new Song("Iron Maiden - Fear of the Dark"));

//        myPlaylist.Play();

//    }
//}

