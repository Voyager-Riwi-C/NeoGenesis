using NeoGenesis.App.Data;

namespace NeoGenesis.App.Repositories;

public class DinosaurRepository
{
    //readonly -> es para que una vez que se ejecute no se pueda modificar la bd
    private readonly AppDbContext db;
    
    public  DinosaurRepository(AppDbContext db)
    {
        this.db = db;
    }
    
    //OBTENER TODOS
}





