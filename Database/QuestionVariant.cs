//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuestionVariant
    {
        public int id { get; set; }
        public int question { get; set; }
        public int variant { get; set; }
        public bool isCorrect { get; set; }
    
        public virtual Question Question1 { get; set; }
        public virtual Variant Variant1 { get; set; }
    }
}
