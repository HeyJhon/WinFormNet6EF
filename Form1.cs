namespace WinFormsAppEF
{
    public partial class Form1 : Form
    {
        SchoolContext schoolContext;
        public Form1()
        {
            InitializeComponent();
            schoolContext = new();
            schoolContext.Database.EnsureCreated();
            Listar();
        }

        private void Listar()
        {
            dgvDatos.DataSource = schoolContext.Alumnos.ToList();
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Alumno alumnoNuevo = new()
            {
                Id = Guid.NewGuid(),
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text

            };

            schoolContext.Alumnos.Add(alumnoNuevo);
            schoolContext.SaveChanges();
            MessageBox.Show("Agregado correctamente");
            Listar();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Text = String.Empty;
            txtNombre.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Guid id;
            Guid.TryParse(txtId.Text, out id);
            Alumno alumnoEliminar = schoolContext.Alumnos.Find(id);

            if (alumnoEliminar != null)
            {
                schoolContext.Alumnos.Remove(alumnoEliminar);
                schoolContext.SaveChanges();
                MessageBox.Show("Registro eliminado correctamente");
                Listar();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Registro no encontrado");
            }
            

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Guid id;
            Guid.TryParse(txtId.Text, out id);
            Alumno alumnoActualizar = schoolContext.Alumnos.Find(id);

            if (alumnoActualizar !=null)
            {
                alumnoActualizar.Nombre = txtNombre.Text;
                alumnoActualizar.Descripcion = txtDescripcion.Text;

                schoolContext.SaveChanges();
                MessageBox.Show("Actualizado correctamente");
                LimpiarCampos();
                Listar();
            }
            else
            {
                MessageBox.Show("Registro no encontrado");
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           Alumno alumnoSeleccionado =(Alumno)dgvDatos.CurrentRow.DataBoundItem;
            if (alumnoSeleccionado!=null)
            {
                txtId.Text = alumnoSeleccionado.Id.ToString();
                txtNombre.Text = alumnoSeleccionado.Nombre;
                txtDescripcion.Text = alumnoSeleccionado.Descripcion;
            }
        }
    }
}