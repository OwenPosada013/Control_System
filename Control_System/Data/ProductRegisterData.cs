using Control_System.Models;
using System.Data;
using System.Data.SqlClient;

namespace Control_System.Data
{
    public class ProductRegisterData
    {
        private readonly string conexion;

        public ProductRegisterData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task<List<ProductRegister>> ListProductsRegisters()
        {
            List<ProductRegister> productRegisters = new List<ProductRegister>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_listProductsRegister", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        productRegisters.Add(new ProductRegister
                        {
                            IdProductRegister = Convert.ToInt32(reader["IdProductRegister"]),
                            Name = reader["Name"].ToString()!,
                            Price = (decimal)reader["Price"],
                            Cant = (int)reader["Cant"],
                            TypeProduct = reader["TypeProduct"].ToString()!,
                            Provider = reader["Provider"].ToString()!
                        });
                    }
                }
            }

            return productRegisters;
        }

        public async Task<ProductRegister> GetProductRegister(int Id)
        {
            ProductRegister objeto = new ProductRegister();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_getProductRegister", con);
                cmd.Parameters.AddWithValue("@IdProductRegister", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        objeto = new ProductRegister
                        {
                            IdProductRegister = Convert.ToInt32(reader["IdProductRegister"]),
                            Name = reader["Name"].ToString()!,
                            Price = (decimal)reader["Price"],
                            Cant = (int)reader["Cant"],
                            TypeProduct = reader["TypeProduct"].ToString()!,
                            Provider = reader["Provider"].ToString()!
                        };
                    }
                }
            }
            return objeto;
        }

        public async Task<bool> Create(ProductRegister objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_createProductRegister", con);
                cmd.Parameters.AddWithValue("@Name", objeto.Name);
                cmd.Parameters.AddWithValue("@Price", objeto.Price);
                cmd.Parameters.AddWithValue("@Cant", objeto.Cant);
                cmd.Parameters.AddWithValue("@TypeProduct", objeto.TypeProduct);
                cmd.Parameters.AddWithValue("@Provider", objeto.Provider);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public async Task<bool> Update(ProductRegister objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_updateProductRegister", con);
                cmd.Parameters.AddWithValue("@IdProductRegister", objeto.IdProductRegister);
                cmd.Parameters.AddWithValue("@Name", objeto.Name);
                cmd.Parameters.AddWithValue("@Price", objeto.Price);
                cmd.Parameters.AddWithValue("@Cant", objeto.Cant);
                cmd.Parameters.AddWithValue("@TypeProduct", objeto.TypeProduct);
                cmd.Parameters.AddWithValue("@Provider", objeto.Provider);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public async Task<bool> Delete(int id)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_deleteProductRegister", con);
                cmd.Parameters.AddWithValue("@IdProductRegister", id);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}