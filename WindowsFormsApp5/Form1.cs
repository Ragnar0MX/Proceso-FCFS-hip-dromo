using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        private Random rand;
        public Queue<PictureBox> cola;
        public Form1()
        {
            InitializeComponent();
            Cargar_Caballos();
            rand = new Random();
            cola = new Queue<PictureBox>();
        }

        public void Cargar_Caballos()
        {
            C1.Image = imageList1.Images[0];
            C2.Image = imageList1.Images[0];
            C3.Image = imageList1.Images[0];
            C4.Image = imageList1.Images[0];
            C5.Image = imageList1.Images[0];
        }

        private void Iniciar_Click(object sender, EventArgs e)
        {
            C1.Tag = rand.Next(30, 100);
            C2.Tag = rand.Next(30, 100);
            C3.Tag = rand.Next(30, 100);
            C4.Tag = rand.Next(30, 100);
            C5.Tag = rand.Next(30, 100);
            int i = 0;
            while(i < 5){
                int c = rand.Next(1, 6);
                switch (c)
                {
                    case 1:
                        if (!cola.Contains(C1)){
                            cola.Enqueue(C1);
                            i++;
                        }
                        break;
                    case 2:
                        if (!cola.Contains(C2)) {
                            i++;
                            cola.Enqueue(C2);
                        }    
                        break;
                    case 3:
                        if (!cola.Contains(C3)){
                            i++;
                            cola.Enqueue(C3);
                        }
                        break;
                    case 4:
                        if (!cola.Contains(C4)){
                            cola.Enqueue(C4);
                            i++;
                        }
                        break;
                    case 5:
                        if (!cola.Contains(C5)) {
                            cola.Enqueue(C5);
                            i++;
                        }
                        break;
                }
            }
            for (int j = 0; j < cola.Count; j++) { 
                PictureBox aux = cola.Dequeue();
                dataGridView2.Rows.Add(aux.Name);
                cola.Enqueue(aux);
            }
            timer1.Start();

        }

        private void mover_caballo_actual()
        {
            if (cola.Count() > 0)
            {

                PictureBox actual = cola.Peek();
                int x, y;
                x = actual.Location.X;
                y = actual.Location.Y;
                if (x < 800)
                {
                    x += Convert.ToInt32(actual.Tag);
                    if (x > 800)
                        x = 810;
                    actual.Location = new System.Drawing.Point(x, y);
                    PictureBox aux = cola.Dequeue();
                    cola.Enqueue(aux);
                }

                else{
                    int cont = 1;
                    cont += dataGridView1.Rows.Count;
                    dataGridView1.Rows.Add(cont, actual.Name, actual.Tag);
                    cola.Dequeue();
                }
                    
            }
            else
                timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mover_caballo_actual();
        }

        private void Reiniciar_Click(object sender, EventArgs e)
        {
            C1.Location = new System.Drawing.Point(0, 1);
            C2.Location = new System.Drawing.Point(0, 51);
            C3.Location = new System.Drawing.Point(0, 101);
            C4.Location = new System.Drawing.Point(0, 151);
            C5.Location = new System.Drawing.Point(0, 201);
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }
    }
}
