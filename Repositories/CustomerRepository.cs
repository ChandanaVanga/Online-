using Online.Models;
using Dapper;
using Online.Utilities;
using Online.Repositories;


namespace Online.Repositories;

public interface ICustomerRepository
{
    Task<Customer> Create(Customer Item);
    Task<bool> Update(Customer Item);
    // Task<bool> Delete(long EmployeeNumber);
    Task<Customer> GetById(long CustomerId);
    Task<List<Customer>> GetList();

}
public class CustomerRepository : BaseRepository, ICustomerRepository
{
    public CustomerRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Customer> Create(Customer Item)
    {
        var query = $@"INSERT INTO ""{TableNames.customer}"" 
        (customer_id, customer_name, gender, mobile_number, address) 
        VALUES (@CustomerId, @CustomerName, @Gender, @MobileNumber, @Address) 
        RETURNING *";

        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Customer>(query, Item);
            return res;
        }
    }

    // public async Task<bool> Delete(long CustomerId)
    // {
    //     var query = $@"DELETE FROM ""{TableNames.customer}"" 
    //     WHERE customer_id = @CustomerId";

    //     using (var con = NewConnection)
    //     {
    //         var res = await con.ExecuteAsync(query, new { CustomerId });
    //         return res > 0;
    //     }
    // }

    public async Task<Customer> GetById(long CustomerId)
    {
        var query = $@"SELECT * FROM ""{TableNames.customer}"" 
        WHERE customer_id = @CustomerId";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Customer>(query, new { CustomerId });
    }

    public async Task<List<Customer>> GetList()
    {
        // Query
        var query = $@"SELECT * FROM ""{TableNames.customer}""";

        List<Customer> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Customer>(query)).AsList(); // Execute the query
        // Close the connection

        // Return the result
        return res;
    }

    public async Task<bool> Update(Customer Item)
    {
        var query = $@"UPDATE ""{TableNames.customer}"" SET customer_id = @CustomerId, 
        customer_name = @CustomerName, gender = @Gender, mobile_number = @MobileNumber, 
        email = @Email, gender = @Gender WHERE customer_id = @CustomerId address = @Address";

        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }
}