using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using _241712064_Mahesa_Penemuan_Ali_PerbaikanResponsi;

static class Program
{
    static int checks;
    static readonly List<string> results = new();
    const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

    static T Get<T>(FrmKasir form, string name) => (T)(form.GetType().GetProperty(name, Flags)?.GetValue(form)
        ?? form.GetType().GetField(name, Flags)!.GetValue(form)!);
    static void Assert(bool value, string label)
    {
        if (!value) throw new Exception("GAGAL: " + label);
        checks++;
    }
    static void Case(string label) { results.Add("LULUS: " + label); }
    static void Add(FrmKasir f, string service, string qty)
    {
        Get<ComboBox>(f, "cboLayanan").SelectedItem = service;
        Get<TextBox>(f, "txtJumlah").Text = qty;
        f.GetType().GetMethod("btnTambah_Click", Flags)!.Invoke(f, new object[] { f, EventArgs.Empty });
    }
    static List<Pesanan> Orders(FrmKasir f) => Get<List<Pesanan>>(f, "daftarPesanan");
    static void Total(FrmKasir f, int count, string value)
    {
        Assert(Orders(f).Count == count, "jumlah List " + count);
        Assert(Get<DataGridView>(f, "dgvPesanan").Rows.Count == count, "jumlah baris grid " + count);
        Assert(Get<Label>(f, "lblTotal").Text == value, "total " + value);
    }
    static FrmKasir NewForm()
    {
        var f = new FrmKasir();
        f.BindingContext = new BindingContext();
        f.CreateControl();
        f.GetType().GetMethod("FrmKasir_Load", Flags)!.Invoke(f, new object[] { f, EventArgs.Empty });
        return f;
    }
    static string Snapshot(FrmKasir f) => string.Join(";", Orders(f).Select(p =>
        $"{p.Layanan}|{p.Jumlah}|{p.Harga}|{p.Diskon}|{p.Subtotal}")) + Get<Label>(f, "lblTotal").Text;

    [STAThread]
    static int Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        if (args.Contains("--ui"))
        {
            using var visible = new FrmKasir();
            visible.Show();
            Add(visible, "Fotokopi", "150");
            Add(visible, "Print Warna", "12");
            Add(visible, "Jilid", "2");
            Add(visible, "Print Hitam Putih", "99");
            Add(visible, "Fotokopi", "50");
            Add(visible, "Print Hitam Putih", "1");
            Add(visible, "Fotokopi", "900");
            Total(visible, 4, "Rp 127.000");
            var expected = Snapshot(visible);
            int dialogs = 0;
            Get<Button>(visible, "btnBaru").Click += (_, _) =>
            {
                dialogs++;
                if (dialogs == 1)
                {
                    Assert(Snapshot(visible) == expected, "jawaban No mempertahankan seluruh data");
                    Total(visible, 4, "Rp 127.000");
                    Console.WriteLine("LULUS: Data uji 11, jawab No, 4 baris dan total Rp 127.000 tidak berubah.");
                }
                else if (dialogs == 2)
                {
                    Total(visible, 0, "Rp 0");
                    Assert(Get<ComboBox>(visible, "cboLayanan").SelectedIndex == -1 && Get<TextBox>(visible, "txtJumlah").Text == "", "input reset");
                    Assert(Get<ErrorProvider>(visible, "errInput").GetError(Get<TextBox>(visible, "txtJumlah")) == "", "error dibersihkan");
                    Console.WriteLine("LULUS: Data uji 12, jawab Yes, tabel kosong, total Rp 0, isian dan tanda error bersih.");
                }
            };
            Application.Run(visible);
            return 0;
        }
        try
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            using (var f = NewForm())
            {
                var combo = Get<ComboBox>(f, "cboLayanan");
                var qty = Get<TextBox>(f, "txtJumlah");
                var errors = Get<ErrorProvider>(f, "errInput");
                var grid = Get<DataGridView>(f, "dgvPesanan");
                Assert(f.Name == "FrmKasir", "nama form");
                Assert(combo.Items.Cast<string>().SequenceEqual(new[] { "Fotokopi", "Print Hitam Putih", "Print Warna", "Jilid" }), "array layanan");
                Assert(combo.DropDownStyle == ComboBoxStyle.DropDownList, "DropDownList");
                Assert(grid.ReadOnly && !grid.AllowUserToAddRows && !grid.AllowUserToDeleteRows, "grid read-only");
                Assert(ReferenceEquals(Get<BindingSource>(f, "bsPesanan").DataSource, Orders(f)), "List terhubung ke BindingSource");
                Assert(grid.Columns["Harga"].HeaderText == "Harga Satuan", "header Harga Satuan");
                Total(f, 0, "Rp 0");
                Case("Struktur form, array layanan, binding, dan tabel kosong");

                Add(f, "", "");
                Assert(errors.GetError(combo) != "" && errors.GetError(qty) != "", "dua ikon error kosong");
                Total(f, 0, "Rp 0");
                Case("Data uji 1: kedua isian kosong ditolak");
                Add(f, "Fotokopi", "abc");
                Assert(errors.GetError(qty) != "" && errors.GetError(combo) == "", "abc ditolak");
                Total(f, 0, "Rp 0");
                Case("Data uji 2: abc ditolak");
                foreach (var input in new[] { "0", "1500" })
                {
                    Add(f, "Fotokopi", input);
                    Assert(errors.GetError(qty) != "", input + " ditolak");
                    Total(f, 0, "Rp 0");
                }
                Case("Data uji 3: jumlah 0 dan 1500 ditolak");

                Add(f, "Fotokopi", "150");
                var photo = Orders(f)[0];
                Assert(photo.Harga == 300 && photo.Diskon == 4500 && photo.Subtotal == 40500, "Fotokopi 150");
                Total(f, 1, "Rp 40.500");
                Assert(combo.SelectedIndex == -1 && qty.Text == "" && errors.GetError(qty) == "" && errors.GetError(combo) == "", "isian dan error dibersihkan");
                Case("Data uji 4: Fotokopi 150, diskon 4.500, subtotal dan total 40.500");
                Add(f, "Print Warna", "12");
                Assert(Orders(f)[1].Diskon == 0 && Orders(f)[1].Subtotal == 18000, "Print Warna 12");
                Total(f, 2, "Rp 58.500");
                Case("Data uji 5: Print Warna 12, total 58.500");
                Add(f, "Jilid", "2");
                Assert(Orders(f)[2].Diskon == 0 && Orders(f)[2].Subtotal == 10000, "Jilid 2");
                Total(f, 3, "Rp 68.500");
                Case("Data uji 6: Jilid 2, total 68.500");
                Add(f, "Print Hitam Putih", "99");
                Assert(Orders(f)[3].Diskon == 0 && Orders(f)[3].Subtotal == 49500, "Print Hitam Putih 99");
                Total(f, 4, "Rp 118.000");
                Case("Data uji 7: Print Hitam Putih 99, total 118.000");
                Add(f, "Fotokopi", "50");
                Assert(ReferenceEquals(photo, Orders(f)[0]) && photo.Jumlah == 200 && photo.Diskon == 6000 && photo.Subtotal == 54000, "gabung Fotokopi 200");
                Total(f, 4, "Rp 131.500");
                Assert(grid.Rows[0].Cells["Jumlah"].Value.Equals(200), "grid memperbarui jumlah gabungan");
                Case("Data uji 8: Fotokopi digabung menjadi 200, tetap 4 baris, total 131.500");
                Add(f, "Print Hitam Putih", "1");
                Assert(Orders(f)[3].Jumlah == 100 && Orders(f)[3].Diskon == 5000 && Orders(f)[3].Subtotal == 45000, "batas diskon 99 + 1");
                Total(f, 4, "Rp 127.000");
                Case("Data uji 9: Print Hitam Putih menjadi 100, diskon 5.000, total 127.000");
                var before = Snapshot(f);
                Add(f, "Fotokopi", "900");
                Assert(errors.GetError(qty) != "" && Snapshot(f) == before, "gabungan 1100 tidak mengubah data");
                Total(f, 4, "Rp 127.000");
                Assert(qty.Text == "900" && combo.Text == "Fotokopi", "input gagal dipertahankan");
                Case("Data uji 10: gabungan 1100 ditolak, data dan total tidak berubah");
                foreach (var col in new[] { "Harga", "Diskon", "Subtotal" })
                {
                    Assert(grid.Columns[col].DefaultCellStyle.Format == "N0", "format " + col);
                    Assert(grid.Columns[col].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight, "rata kanan " + col);
                }
                Assert(grid.Rows[0].Cells["Diskon"].FormattedValue.Equals("6.000"), "pemisah ribuan Indonesia pada budaya en-US");
                Case("Format angka Indonesia dan rata kanan tetap benar pada Windows en-US");
            }

            foreach (var culture in new[] { "id-ID", "en-US" })
            {
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
                using var f = NewForm();
                foreach (var input in new[] { "", " ", "abc", "12abc", "-1", "0", "1.5", "1,5", "1001", "2147483647", "-2147483648", "99999999999999999999" })
                {
                    Add(f, "Fotokopi", input);
                    Assert(Get<ErrorProvider>(f, "errInput").GetError(Get<TextBox>(f, "txtJumlah")) != "", "input invalid " + input);
                    Total(f, 0, "Rp 0");
                }
                Case("Input kosong, huruf, negatif, pecahan, 1001, batas Integer, dan overflow ditolak pada " + culture);
            }
            var boundaries = new[] {
                ("Fotokopi", 300m, 29700m, 3000m, 27000m, 270000m),
                ("Print Hitam Putih", 500m, 49500m, 5000m, 45000m, 450000m),
                ("Print Warna", 1500m, 148500m, 15000m, 135000m, 1350000m),
                ("Jilid", 5000m, 495000m, 50000m, 450000m, 4500000m)
            };
            foreach (var (service, price, at99, discount100, at100, at1000) in boundaries)
            {
                using var f = NewForm();
                Add(f, service, "1");
                Assert(Orders(f)[0].Subtotal == price && Orders(f)[0].Diskon == 0, "batas 1 " + service);
                Add(f, service, "98");
                Assert(Orders(f)[0].Jumlah == 99 && Orders(f)[0].Subtotal == at99 && Orders(f)[0].Diskon == 0, "batas 99 " + service);
                Add(f, service, "1");
                Assert(Orders(f)[0].Jumlah == 100 && Orders(f)[0].Diskon == discount100 && Orders(f)[0].Subtotal == at100, "batas 100 " + service);
                Add(f, service, "900");
                Assert(Orders(f)[0].Jumlah == 1000 && Orders(f)[0].Subtotal == at1000 && Orders(f).Count == 1, "batas gabungan 1000 " + service);
                var before = Snapshot(f);
                Add(f, service, "1");
                Assert(Snapshot(f) == before && Get<ErrorProvider>(f, "errInput").GetError(Get<TextBox>(f, "txtJumlah")) != "", "gabungan 1001 " + service);
                Case("Batas 1, 99, 100, gabungan 1000 dan penolakan 1001: " + service);
            }
            foreach (var service in ModTarif.daftarLayanan)
            {
                using var f = NewForm();
                Add(f, service, "1000");
                Assert(Orders(f).Count == 1 && Orders(f)[0].Jumlah == 1000, "input langsung 1000 " + service);
            }
            Case("Input langsung 1000 diterima untuk keempat layanan");
            results.Add($"TOTAL: {checks} pemeriksaan lulus. Data uji 11 dan 12 diperiksa terpisah melalui dialog aplikasi.");
            Console.WriteLine(string.Join(Environment.NewLine, results));
            return 0;
        }
        catch (Exception e) { Console.Error.WriteLine(e); return 1; }
    }
}
