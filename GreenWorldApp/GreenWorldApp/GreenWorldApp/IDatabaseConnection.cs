using System;
using System.Collections.Generic;
using System.Text;

namespace GreenWorldApp
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
