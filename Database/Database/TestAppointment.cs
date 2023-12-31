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
    
    public partial class TestAppointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestAppointment()
        {
            this.ExecutionAttempts = new HashSet<ExecutionAttempt>();
        }
    
        public int id { get; set; }
        public int test { get; set; }
        public int student { get; set; }
        public int responsibleBy { get; set; }
        public System.DateTime time { get; set; }
        public System.DateTime endTime { get; set; }
        public int executionTime { get; set; }
        public int numberOfAttempts { get; set; }
    
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExecutionAttempt> ExecutionAttempts { get; set; }
        public virtual Student Student1 { get; set; }
        public virtual Test Test1 { get; set; }
    }
}
