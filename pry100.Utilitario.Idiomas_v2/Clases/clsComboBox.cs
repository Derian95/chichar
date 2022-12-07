using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry100.Utilitario.Idiomas_v2.Clases
{
    public class clsComboBox
    {
        public class customComboBox
        {
            public long Valor { get; set; }
            public string Item { get; set; }
            public customComboBox(long valor, string item)
            {
                Valor = valor;
                Item = item;
            }
        }

        public static void mtdLimpiarComboBox(ComboBox target)
        {
            try
            {
                //target.Items.Clear();
                target.DataSource = null;
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        public static void mtdLlenarComboBoxManual(ComboBox controlComboBox
                                                , List<customComboBox> objComboContenido
                                                , bool agregarDefault = true
                                                , long valorDefault = -1
                                                , string contenidoDefault = "Seleccione..."
                                                , bool seleccionar = false
                                                , long valorSeleccion = -1)
        {
            List<customComboBox> objBase = new List<customComboBox>();
            bool encontro = new bool();
            try
            {
                if (objComboContenido.Count > 0)
                {
                    if (agregarDefault)
                    {
                        //objBase.Add(new customComboBox<int> { Valor = valorDefault, Item = contenidoDefault });
                        objBase.Add(new customComboBox(valorDefault, contenidoDefault));
                        foreach (customComboBox reg in objComboContenido)
                        {
                            objBase.Add(new customComboBox(reg.Valor, reg.Item));
                            //objBase.Add(new customComboBox<int> { Valor = reg.Valor, Item = reg.Item });
                        }
                    }
                    else
                    {
                        objBase = objComboContenido;
                    }

                    mtdLimpiarComboBox(controlComboBox);
                    
                    controlComboBox.DataSource = objBase;
                    controlComboBox.ValueMember = "Valor";
                    controlComboBox.DisplayMember = "Item";

                    if (seleccionar)
                    {
                        foreach (customComboBox reg in objComboContenido)
                        {
                            if (Convert.ToInt64(reg.Valor) == valorSeleccion && valorSeleccion != -1) { encontro = true; }
                        }
                    }

                    if (encontro) { controlComboBox.SelectedValue = Convert.ToInt64(valorSeleccion); } else { controlComboBox.SelectedIndex = 0; }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
    }
}
