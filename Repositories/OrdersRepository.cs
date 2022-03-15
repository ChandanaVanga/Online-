using Dapper;
using Online.Models;
using Online.Utilities;

namespace Online.Repositories;

public interface IOrdersRepository
{
   // Task<Orders> Create(Orders Item);
    Task Update(Orders Item);
    Task Delete(long OrderId);
    Task<List<Orders>> GetList();
    Task<Orders> GetById(long OrderId);

    Task<List<Orders>> GetListByCustomerId(long CustomerId);
}

public class OrdersRepository : BaseRepository, IOrdersRepository
{
    public OrdersRepository(IConfiguration config) : base(config)
    {

    }

    // public async Task<Orders> Create(Orders Item)
    // {
    //     var query = $@"INSERT INTO {TableNames.hardware} (name, mac_address, type,
    //     user_employee_number) VALUES (@Name, @MacAddress, @Type, @UserEmployeeNumber) 
    //     RETURNING *";

    //     using (var con = NewConnection)
    //         return await con.QuerySingleAsync<Orders>(query, Item);
    // }

    
    public async Task Delete(long OrderId)
    {
        var query = $@"DELETE FROM {TableNames.orders} WHERE order_id = @OrderId";

        using (var con = NewConnection)
            await con.ExecuteAsync(query, new { OrderId });
    }

    

    public async Task<List<Orders>> GetList()
    {
        var query = $@"SELECT * FROM {TableNames.orders}";

        using (var con = NewConnection)
            return (await con.QueryAsync<Orders>(query)).AsList();
    }

   
    public async Task<Orders> GetById(long OrderId)
    {
        var query = $@"SELECT * FROM {TableNames.orders} 
        WHERE order_id = @OrderId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Orders>(query, new { OrderId });
    }

    public async Task Update(Orders Item)
    {
        var query = $@"UPDATE {TableNames.orders} SET order_id = @OrderId, status = @Status, 
        order_id = @OrederId";

        using (var con = NewConnection)
            await con.ExecuteAsync(query, Item);
    }

    public async Task<List<Orders>> GetListByCustomerId(long CustomerId)
    {
        var query = $@"SELECT o.* FROM {TableNames.customer} c 
        LEFT JOIN {TableNames.orders} o ON c.customer_id = o.customer_id 
        WHERE c.customer_id = @CustomerId";

        // LEFT JOIN {TableNames.guest} g ON g.id = s.guest_id 

        using (var con = NewConnection)
            return (await con.QueryAsync<Orders>(query, new { CustomerId })).AsList();
    }
}