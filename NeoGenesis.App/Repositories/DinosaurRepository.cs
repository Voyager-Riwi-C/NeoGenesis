using NeoGenesis.App.Data;

namespace NeoGenesis.App.Repositories;

public class DinosaurRepository
{
    //readonly -> es para que una vez que se ejecute no se pueda modificar la bd
    private readonly AppDbContext db;
    
    public  DinosaurRepository(AppDbContext db)
    {
        //Asignarle el valor traido a la variable declarada
        this.db = db;
    }
    
    //OBTENER TODOS
}





