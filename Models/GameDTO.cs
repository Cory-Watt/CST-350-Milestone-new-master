namespace Milestone.Models
{
    public class GameDTO
    {
        public int Id { get; set; }

        public int ButtonState { get; set; }
        public bool Live { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Visited { get; set; }
        public int Neighbors { get; set; }
        public string ImageName { get; set; }
        public bool Flagged { get; set; }
        public DateTime SaveDateTime { get; internal set; }

        public GameDTO() { }

        public GameDTO(int id, int buttonState)
        {
            // Setting default values
            Id = id;
            Row = -1;
            Column = -1;
            Visited = false;
            Live = false;
            Neighbors = 0;
            ButtonState = buttonState;
        }

    }
}
