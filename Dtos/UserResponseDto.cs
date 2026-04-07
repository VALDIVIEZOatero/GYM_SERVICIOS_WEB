namespace ApiGimnasio.Dtos
{
    public class UserResponseDto
{
    public int Id{get;set;}
    public string UserName{get;set;}="";
    public string Email{get;set;}="";

    public string? Telefono{get;set;}
    public bool IsActive{get;set;}

    public List<string?> Roles{get;set;}= new List<string?>();
}
}