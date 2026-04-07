namespace ApiGimnasio.Dtos
{
    public class RegisterDto
{
    public string UserName{get;set;}="";
    public string Email{get;set;}="";
    public string Password{get;set;}="";
    public string? Telefono{get;set;}
    public int RolId{get;set;}
}
}