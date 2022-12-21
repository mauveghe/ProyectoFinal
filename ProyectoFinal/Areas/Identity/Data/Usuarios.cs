using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProyectoFinal.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Usuarios class
public class Usuarios : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string nombre { get; set; }
    [PersonalData]
    [Column(TypeName = "nvarchar(12 )")]
    public string Cedula { get; set; }
}

