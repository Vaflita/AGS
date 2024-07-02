using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App;
using Domain;
using Npgsql;
using NpgsqlTypes;

namespace UI
{
    public partial class VehicleBaseForm : Form
    {
        DB db = new();
        int numberVb;
        public VehicleBaseForm(int id)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(216, 216, 216);
            var vehbas = db.GetVehicleBases();
            foreach (var vb in vehbas)
            {
                if (vb.Id == id) numberVb = id;
            }
            label2.Text = $"Автобаза №{numberVb}";
        }

        private void CreateColumsVehicle()
        {
            dataGridView1.Columns.Add("name", "Модель");
            dataGridView1.Columns.Add("price", "Тип");
            dataGridView1.Columns.Add("dosage", "Тип топлива");
            dataGridView1.Columns.Add("pack_quantity", "Текущий уровень топлива");
        }
        private void CreateColumsGasStation()
        {
            dataGridView1.Columns.Add("name", "Название");
            dataGridView1.Columns.Add("address", "Адрес");
            dataGridView1.Columns.Add("status", "Статус");
            dataGridView1.Columns.Add("fuel_type", "Тип топлива");
            dataGridView1.Columns.Add("available_quantity", "Доступное количество");
            dataGridView1.Columns.Add("price_per_liter", "Цена за литр");
        }

        private void ReadSingleRowVehicle(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetInt32(3));
        }
        private void ReadSingleRowGasStation(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4), record.GetDouble(5));
        }

        private void RefreshDataGridVehicle(DataGridView dgv)
        {
            dgv.Rows.Clear();

            var command = new NpgsqlCommand($"select v.model, v.type, v.fuel_type, v.current_fuel_level" +
                $" from vehicles v" +
                $" where v.vehiclebase_id = @num", db.GetConection());
            command.Parameters.Add("@num", NpgsqlDbType.Integer).Value = numberVb;

            db.OpenConection();

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowVehicle(dgv, reader);
            }
            reader.Close();
        }
        private void RefreshDataGridGasStation(DataGridView dgv)
        {
            dgv.Rows.Clear();

            var command = new NpgsqlCommand($"select g.name, g.address, g.status, f.fuel_type, f.available_quantity, f.price_per_liter" +
                 $" from gas_stations g, fuel_at_stations f" +
                 $" where g.gas_station_id = f.gas_station_id", db.GetConection());

            db.OpenConection();

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowGasStation(dgv, reader);
            }
            reader.Close();
        }
        private void RefreshDataGridLowFuel(DataGridView dgv)
        {
            dgv.Rows.Clear();

            var command = new NpgsqlCommand($"select v.model, v.type, v.fuel_type, v.current_fuel_level" +
                $" from vehicles v" +
                $" where v.vehiclebase_id = @num and v.current_fuel_level <= 30", db.GetConection());
            command.Parameters.Add("@num", NpgsqlDbType.Integer).Value = numberVb;

            db.OpenConection();

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRowVehicle(dgv, reader);
            }
            reader.Close();
            db.CloseConection();
        }
        private void VehicleBaseForm_Load(object sender, EventArgs e)
        {
            CreateColumsVehicle();
            RefreshDataGridVehicle(dataGridView1);
        }
        private void lowFuelButton_Click(object sender, EventArgs e)
        {
            RefreshDataGridLowFuel(dataGridView1);
        }

        private void allButton_Click(object sender, EventArgs e)
        {
            RefreshDataGridVehicle(dataGridView1);
        }
        private void allAzsButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            CreateColumsGasStation();
            RefreshDataGridGasStation(dataGridView1);
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            //var vehicles = db .GetVehicles();
            var vehicleBases = db.GetVehicleBases();
            var gasStations = db.GetGasStations();
            var fuelAtStaion = db.GetFuelAtStations();
            //var contract = db.GetContracts();

            var str = new StringBuilder();

            var veb = vehicleBases.Where(v => v.Id == numberVb).ToList();
            foreach (var vb in veb)
            {
                foreach (var veh in vb.Vehicles)
                {
                    if (veh.CurrentFuelLevel <= 30)
                    {
                        var suitableGasStations = gasStations
                            .Where(gs => gs.Status == "open"
                                && vb.Contracts.Contains(gs.Id))
                            .ToList();
                        foreach (var gs in suitableGasStations)
                        {
                            foreach (var fuelgs in gs.FuelAtStation)
                            {
                                if (fuelgs.FuelType == veh.FuelType)
                                suitableGasStations = suitableGasStations
                                    .Where(gs => fuelgs.FuelType == veh.FuelType)
                                    .OrderBy(gs => fuelgs.PricePerLiter)
                                    .ToList();
                            }
                        }

                        if (suitableGasStations.Any())
                        {
                            var selectedGasStation = suitableGasStations.First(); // Выбор оптимальной АЗС
                            str.Append($"Машина {veh.Id} ({veh.Model}) поехала заправляться в {selectedGasStation.Name} \n");
                            var command = new NpgsqlCommand($"UPDATE vehicles " +
                                $"SET current_fuel_level = 100 " +
                                $"WHERE vehicle_id = @id", db.GetConection());
                            command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = veh.Id;

                            db.OpenConection();

                            NpgsqlDataReader reader = command.ExecuteReader();
                            reader.Close();

                            db.CloseConection();

                            veh.CurrentFuelLevel = 100;
                        }
                        else
                        {
                            str.Append($"Нет подходящей заправки {veh.Id} ({veh.Model}) \n");
                        }
                    }
                    else str.Append($"Заправка для  {veh.Id} ({veh.Model}) не требуется\n");
                }
            }

            MessageBox.Show(str.ToString());
        }

        
    }
}
