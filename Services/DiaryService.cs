using Microsoft.Data.SqlClient;


namespace RadzenComponents.Services
{
    public class DiaryService
    {
        private readonly string connectionString = "Data Source = PC-ABLASCO; initial Catalog = IECSDB_GASHOGAR; Trusted_Connection = yes; Pooling = true;TrustServerCertificate=true";
        public IQueryable<Diary> GetDiaries()
        {
            return (IQueryable<Diary>)ExecuteSqlSelect();
        }

        private IEnumerable<Diary> ExecuteSqlSelect()
        {
            var response = new List<Diary>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = $@"select top 1000
                        d.Id as Id
                        ,d.id_a as IdA
                        ,d.Date as Date
                        ,d.Asiento as Asiento
                        ,d.Type as Type
                        ,d.SubCta as SubCta
                        ,d.Description  as Description
                        ,d.PtsDebe  as PtsDebe
                        ,d.PtsHaber  as PtsHaber
                        ,d.RegistryDate  as RegistryDate
                        ,d.IdCashWallet  as IdCashWallet
                        from descDiary d
                        order by id desc";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            response.Add(new Diary
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                IdA = Convert.ToInt32(reader["IdA"]),
                                Date = Convert.ToDateTime(reader["Date"]),
                                Asiento = Convert.ToString(reader["Asiento"]),
                                Type = Convert.ToInt32(reader["Type"]),
                                SubCta = Convert.ToString(reader["SubCta"]),
                                Description = Convert.ToString(reader["Description"]),
                                PtsDebe = Convert.ToInt32(reader["PtsDebe"]),
                                PtsHaber = Convert.ToInt32(reader["PtsHaber"]),
                                RegistryDate = Convert.ToDateTime(reader["RegistryDate"]),
                                IdCashWallet = Convert.ToInt32(reader["IdCashWallet"]),
                            });
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return response;
        }
    }

    public class Diary
    {
        public int Id { get; set; }
        public int IdA { get; set; }
        public DateTime? Date { get; set; }
        public string? Asiento { get; set; }
        public int? Type { get; set; }
        public string? SubCta { get; set; }
        public string? Description { get; set; }
        public decimal? PtsDebe { get; set; }
        public decimal? PtsHaber { get; set; }
        public DateTime? RegistryDate { get; set; }
        public int? IdCashWallet { get; set; }
    }

    public class CashWallet
    {
        public int Id { get; set; }
        public int IdInvoice { get; set; }
        public DateTime? EmisionDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string? Ref { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}