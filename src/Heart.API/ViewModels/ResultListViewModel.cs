namespace Heart.API.ViewModels
{
    public class ResultListViewModel
    {
        public string Message {get; set;}
        public bool Sucess { get; set; }
        public dynamic Data { get; set; }
        public int UsersQuantity { get; set;}
    }
}