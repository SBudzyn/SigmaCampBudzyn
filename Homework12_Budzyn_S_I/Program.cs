namespace Homework12
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var writer = new FileWriter(Data.Path);
            var clients = new List<TicketOffice>() { new TicketOffice(writer, 1), new TicketOffice(writer, 2), new TicketOffice(writer, 3), new TicketOffice(writer, 4), new TicketOffice(writer, 5), new TicketOffice(writer, 6), new TicketOffice(writer, 7) };
            clients.ForEach(o => o.OfficeOvercrowded += Handle_OfficeOvercrowded);
            RailwayStation station = new(6, 8, new RandomClientGenerator(new ClientsDirector(new RandomClientBuilder(6, 8))), clients.ToArray());
            station.Start();
            Console.ReadLine();
            station.Stop();
        }

        private static void Handle_OfficeOvercrowded(TicketOffice office)
        {
            Random random = new Random();
            
            office.ChangeOfficeStatus((OfficeStatus)random.Next(0, 3));
        }
    }
}