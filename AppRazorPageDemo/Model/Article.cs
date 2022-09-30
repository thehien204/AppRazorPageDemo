using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppRazorPageDemo.Model;

public class Article
{
    [Key]
    public int Id { get; set; }
    [DisplayName("Tiêu đề")]
    [StringLength(255)]
    [Required]
    [Column(TypeName = "nvarchar(255)")]
    public string Title { get; set; }
    
    [Column(TypeName = "ntext")]
    public string Content { get; set; }
    [DisplayName("Ngày tạo")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime Created { get; set; }
    
}