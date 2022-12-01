namespace ConsoleMusicApp
{
    internal class ApplicationOne
    {

        public static string? PlayListName;

        private static readonly Random rng = new();

        public static List<Tracklist> list = new();

        public static int myid = 0;

        public static List<Tracklist> tracks = new List<Tracklist>{
            new Tracklist {Id = 1, Track ="Ms Jackson", Artist ="Outkast" },
            new Tracklist {Id = 2, Track ="Hey ya", Artist ="Outkast" },
            new Tracklist {Id = 3, Track ="Stronger", Artist ="Kanye West"},
            new Tracklist {Id = 4, Track ="Power", Artist ="Kanye West"},
            new Tracklist {Id = 5,Track ="Outside", Artist ="BNXN" },
            new Tracklist {Id = 6,Track ="Tadow", Artist ="Masego" },

        };

        public static void WelcomeMsg()
        {
            Console.WriteLine("\n*----------Pineapple Music----------*\n What would you like to do?");
            Console.WriteLine("\n1. Show Current Tracklist\n2. Add to Tracklist\n3. Remove from Playlist" +
                "\n4. Edit Track from Playlist\n5. Shuffle Tracklist\n6. Arrange Tracklist\n7. Create a new playlist");
            NextAction();
        }

        public static void NextAction()
        {
        returnHere:
            var userSelection = Convert.ToInt32(Console.ReadLine());
            switch (userSelection)
            {
                case 1:
                    ShowPlayList();
                    break;
                case 2:
                    AddToTracklist();
                    break;
                case 3:
                    RemoveFromTracklist();
                    break;
                case 4:
                    EditTracklist();
                    break;
                case 5:
                    ShuffleTracklist();
                    break;
                case 6:
                    ArrangeTracklist();
                    break;
                case 7:
                    NewPlaylist.CreatedPlaylist();
                    break;
                case 8:
                    Environment.Exit(100);
                    break;
                default:
                    Console.WriteLine("Incorrect Input, Try Again");
                    break;
            }
            goto returnHere;
        }

        static List<Tracklist> GetMusic()
        {
            return tracks;
        }



        public static void ShowPlayList()
        {
            GetMusic().ForEach(music => Console.WriteLine($"Music id {music.Id} Track name: {music.Track} Artist: {music.Artist}"));
            WelcomeMsg();
        }

        public static void AddToTracklist()
        {
            try
            {
            Console.WriteLine("Input Song to be Added to the playlist\nAdd Song Name");
            var addedSong = Console.ReadLine();
            Console.WriteLine("Add the Artist Name");
            var addedArtist = Console.ReadLine();
            tracks.Add(new Tracklist { Artist = addedArtist, Track = addedSong, Id = tracks.Last().Id + 1 });
            ShowPlayList();
            WelcomeMsg();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch
            {
                Console.WriteLine("Invalid");
            }
        }

        public static void RemoveFromTracklist()
        {
            try
            {
            GetMusic().ForEach(music => Console.WriteLine($"Music id {music.Id} Track name: {music.Track} Artist: {music.Artist}"));
            Console.WriteLine("\nEnter music ID to remove");
            int removetrack = Convert.ToInt32(Console.ReadLine());
            var firstMatch = GetMusic().First(s => s.Id == removetrack);
            GetMusic().Remove(firstMatch);
            ShowPlayList();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch
            {
                Console.WriteLine("Invalid");
            }
        }

        public static void EditTracklist()
        {
            try { 
            GetMusic().ForEach(music => Console.WriteLine($"Music id {music.Id} Track name: {music.Track} Artist: {music.Artist}"));
            Console.WriteLine("\nEnter music ID to Edit");
            int trackId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter new track name");
            var newTrack = Console.ReadLine();
            Console.WriteLine("Enter new artist name");
            var newArtist = Console.ReadLine();

            var editsongs = GetMusic().FirstOrDefault(edit => edit.Id == trackId);
            if (editsongs != null)
            {
                editsongs.Track = newTrack;
                editsongs.Artist = newArtist;

            }
            Console.WriteLine("Sucessfully updated");

            ShowPlayList();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch
            {
                Console.WriteLine("Invalid");
            }
        }

        public static void ShuffleTracklist()
        {
            try { 
            int lastIndex = tracks.Count() - 1;
            while (lastIndex > 0)
            {
                Tracklist tempValue = tracks[lastIndex];
                int randomTrack = new Random().Next(0, lastIndex);
                tracks[lastIndex] = tracks[randomTrack];
                tracks[randomTrack] = tempValue;
                lastIndex--;
                ShowPlayList();
            }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch
            {
                Console.WriteLine("Invalid");
            }
        }
        public static void ArrangeTracklist()
        {
            ShowPlayList();
            tracks.Sort();
            ShowPlayList();
        }


    }
}
