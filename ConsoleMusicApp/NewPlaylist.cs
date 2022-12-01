namespace ConsoleMusicApp
{
    internal class NewPlaylist
    {
        public static void CreatedPlaylist()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Enter new playlist name");
                ApplicationOne.PlayListName = Console.ReadLine();

                Console.WriteLine("{0} was successfully Created", ApplicationOne.PlayListName.ToUpper());

                bool checkplay = true;
                while (checkplay)
                {
                    Console.WriteLine("Enter new Id");
                    int enterID = Convert.ToInt32(Console.ReadLine());

                    foreach (var msc in ApplicationOne.tracks)
                    {
                        if (enterID == msc.Id)
                        {

                            ApplicationOne.list.Add(msc);
                            ApplicationOne.list.ForEach(newplaylist => Console.WriteLine($"{newplaylist.Id} {newplaylist.Track}"));

                        }


                    }
                    Console.WriteLine("Press 1 to add more \n Press any key to exit");
                    var moremusic = Console.ReadLine();
                    if (moremusic == "1")
                    {
                        checkplay = true;
                    }
                    else
                    {
                        Environment.Exit(100);
                        break;
                    }



                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
