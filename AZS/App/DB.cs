using Npgsql;
using System.Data;
using Domain;

namespace App
{
    public class DB
    {
        NpgsqlConnection connection = new NpgsqlConnection(
            $"Server=localhost; " +
            $"port=5432; " +
            $"user id=postgres; " +
            $"Database=postgres; " +
            $"password=123123; " +
            $"database=postgres");

        public void OpenConection() // Открываем соединение 
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void CloseConection() // Закрываем соединение
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public NpgsqlConnection GetConection() //Получаем соединение
        {
            return connection;
        }

        public List<Vehicle> GetVehicles()
        {
            var table = new DataTable();
            var adapter = new NpgsqlDataAdapter();
            var command = new NpgsqlCommand("select * from vehicles p", GetConection());

            OpenConection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            CloseConection();

            return table.AsEnumerable()
                .Select(row => new Vehicle(
                    (int)row[0],
                    (string)row[1],
                    (string)row[2],
                    (string)row[3],
                    (int)row[4],
                    (int)row[5]
                ))
                .ToList();
        }     
        public List<VehicleBase> GetVehicleBases()
        {
            var table = new DataTable();
            var adapter = new NpgsqlDataAdapter();
            var command = new NpgsqlCommand("select * from vehicle_bases", GetConection());

            OpenConection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            CloseConection();

            List<VehicleBase> vehbas = table.AsEnumerable()
                .Select(row => new VehicleBase(
                    (int)row[0],
                    (string)row[1],
                    (string)row[2],
                    new List<Vehicle>(),
                    new List<int>(),
                    null
                ))
                .ToList();

            var opers = GetOperators();
            var vehicles = GetVehicles();
            var conts = GetContracts();

            foreach (var vb in vehbas)
            {
                foreach (var veh in vehicles)
                {
                    if (veh.BaseId == vb.Id)
                    {
                        vb.Vehicles.Add(veh);
                    }
                }
                foreach (var cont in conts)
                {
                    if (cont.BaseId == vb.Id)
                    {
                        vb.Contracts.Add(cont.GasStationId);
                    }
                }
                foreach (var oper in opers)
                {
                    if (oper.BaseId == vb.Id)
                    {
                        vb.Operator = oper;
                    }
                }
            }
            return vehbas;
        }
        public List<Operator> GetOperators()
        {
            var table = new DataTable();
            var adapter = new NpgsqlDataAdapter();
            var command = new NpgsqlCommand("select * from operators", GetConection());

            OpenConection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            CloseConection();

            return table.AsEnumerable()
                .Select(row => new Operator(
                    (int)row[0],
                    (string)row[1],
                    (string)row[2],
                    (int)row[3]
                ))
                .ToList();
        }
        public List<Contract> GetContracts()
        {
            var table = new DataTable();
            var adapter = new NpgsqlDataAdapter();
            var command = new NpgsqlCommand("select * from contracts", GetConection());

            OpenConection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            CloseConection();

            return table.AsEnumerable()
                .Select(row => new Contract(
                    (int)row[0],
                    (int)row[1],
                    (int)row[2]
                ))
                .ToList();
        }
        public List<GasStation> GetGasStations()
        {
            var table = new DataTable();
            var adapter = new NpgsqlDataAdapter();
            var command = new NpgsqlCommand("select * from gas_stations", GetConection());

            OpenConection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            CloseConection();

            List<GasStation> gass = table.AsEnumerable()
                .Select(row => new GasStation(
                    (int)row[0],
                    (string)row[1],
                    (string)row[2],
                    (string)row[3],
                    new List<FuelAtStation>(),
                    new List<int>()
                ))
                .ToList();

            var fuels = GetFuelAtStations();
            var conts = GetContracts();

            foreach (var gas in gass)
            {
                foreach (var fuel in fuels)
                {
                    if (fuel.GasStationId == gas.Id)
                    {
                        gas.FuelAtStation.Add(fuel);
                    }
                }
                foreach (var cont in conts)
                {
                    if (cont.BaseId == gas.Id)
                    {
                        gas.Contracts.Add(cont.BaseId);
                    }
                }
            }
            return gass;
        }
        public List<FuelAtStation> GetFuelAtStations()
        {
            var table = new DataTable();
            var adapter = new NpgsqlDataAdapter();
            var command = new NpgsqlCommand("select * from fuel_at_stations", GetConection());

            OpenConection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            CloseConection();

            return table.AsEnumerable()
                .Select(row => new FuelAtStation(
                    (int)row[0],
                    (int)row[1],
                    (string)row[2],
                    (int)row[3],
                    (double)row[4]
                ))
                .ToList();
        }
    }
}