using Ejercicio24.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio24.controls
{
    public class DataBase
    { 
    readonly SQLiteAsyncConnection database;

    public DataBase(string pathdb)
    {
            database = new SQLiteAsyncConnection(pathdb);
            database.CreateTableAsync<VideoModel>().Wait();
    }

    public Task<List<VideoModel>> ObtenerVideos()
    {
        return database.Table<VideoModel>().ToListAsync();
    }

    public Task<VideoModel> ObtenerVideo(int codigo)
    {
        return database.Table<VideoModel>()
            .Where(i => i.codigo == codigo)
            .FirstOrDefaultAsync();
    }

    public Task<int> GuardarVideos(VideoModel videos)
    {
        if (videos.codigo != 0)
        {
            return database.UpdateAsync(videos);
        }
        else
        {
            return database.InsertAsync(videos);
        }
    }

    public Task<int> EliminarVideo(VideoModel videos)
    {
        return database.DeleteAsync(videos);
    }
}
}
