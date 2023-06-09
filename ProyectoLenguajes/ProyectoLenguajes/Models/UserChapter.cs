﻿using System;
using System.Collections.Generic;

namespace ProyectoLenguajes.Models;

public partial class UserChapter
{
    public int idUser { get; set; }

    public int idChapter { get; set; }

    public DateTime? reviewTime { get; set; }

    public int? stars { get; set; }

    public string? review { get; set; }

    public virtual CHAPTER idChapterNavigation { get; set; } = null!;

    public virtual ACCOUNT idUserNavigation { get; set; } = null!;
}
