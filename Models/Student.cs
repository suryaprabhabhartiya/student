using System.ComponentModel.DataAnnotations;

public class Student  
{
    [Key]
    public string Id { get; set; } = "";
    public string stuName { get; set; } = "";
    public string fName { get; set; } = "";
    public string Mname { get; set; } = "";
    public string DOB { get; set; } = "";

    public string Mnumber { get; set; } = "";
}