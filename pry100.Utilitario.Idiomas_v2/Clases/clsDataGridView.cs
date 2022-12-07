using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using pry100.Utilitario.Idiomas_v2.Enumerables;

using static pry100.Utilitario.Idiomas_v2.Clases.Constantes;
using static pry100.Utilitario.Idiomas_v2.Clases.clsGeneral;

namespace pry100.Utilitario.Idiomas_v2.Clases
{
    public class clsDataGridView
    {
        public class customDataGridViewRow
        {
            public string ColumnName { get; set; }
            public string HeaderText { get; set; }
            public enm_G_Alignment HeaderAlignment { get; set; }
            public enm_G_Alignment ValueAlignment { get; set; }
            public bool AutoSize { get; set; }
            public int Width { get; set; }
            public bool ReadOnly { get; set; }
            public bool Resizable { get; set; }
            public bool Frozen { get; set; }
            public customDataGridViewRow(string columnName
                , string headerText
                , enm_G_Alignment headerAlignment = default
                , enm_G_Alignment valueAlignment = default
                , bool autoSize = default
                , int width = default
                , bool readOnly = true
                , bool resizable = default
                , bool frozen = default)
            {
                ColumnName = columnName;
                HeaderText = headerText;
                HeaderAlignment = headerAlignment;
                ValueAlignment = valueAlignment;
                AutoSize = autoSize;
                Width = width;
                ReadOnly = readOnly;
                Resizable = resizable;
                Frozen = frozen;
            }
        }
        public static void mtdAjustarDataGridView(DataGridView controlDataGridView, List<customDataGridViewRow> objDataGridViewContenido)
        {
            int secuencia = new int();
            try
            {
                foreach (customDataGridViewRow reg in objDataGridViewContenido)
                {
                    if (controlDataGridView.Columns[reg.ColumnName] != null)
                    {
                        DataGridViewColumn _target = controlDataGridView.Columns[reg.ColumnName];

                        _target.DisplayIndex = secuencia;
                        _target.Visible = true;
                        _target.HeaderText = reg.HeaderText;
                        _target.HeaderCell.Style.Alignment = reg.HeaderAlignment == enm_G_Alignment.Left? DataGridViewContentAlignment.MiddleLeft:
                                                                reg.HeaderAlignment == enm_G_Alignment.Center? DataGridViewContentAlignment.MiddleCenter:
                                                                    reg.HeaderAlignment == enm_G_Alignment.Rigth? DataGridViewContentAlignment.MiddleRight: DataGridViewContentAlignment.MiddleCenter;

                        _target.DefaultCellStyle.Alignment = reg.ValueAlignment == enm_G_Alignment.Left? DataGridViewContentAlignment.MiddleLeft:
                                                                reg.ValueAlignment == enm_G_Alignment.Center? DataGridViewContentAlignment.MiddleCenter:
                                                                    reg.ValueAlignment == enm_G_Alignment.Rigth? DataGridViewContentAlignment.MiddleRight: DataGridViewContentAlignment.MiddleCenter;

                        _target.AutoSizeMode = reg.AutoSize? DataGridViewAutoSizeColumnMode.Fill: DataGridViewAutoSizeColumnMode.None;

                        if (reg.AutoSize) { _target.MinimumWidth = reg.Width; } else { _target.Width = reg.Width; }

                        _target.ReadOnly = reg.ReadOnly;
                        _target.Resizable = reg.Resizable? DataGridViewTriState.True: DataGridViewTriState.False;
                        _target.Frozen = reg.Frozen;

                        secuencia++;
                    }
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }
        public static void mtdNoOrdenarDataGridView(DataGridView controlDataGridView)
        {
            try
            {
                controlDataGridView.ColumnHeadersVisible = true;
                controlDataGridView.RowHeadersVisible = false;
                controlDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                controlDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                controlDataGridView.ReadOnly = false;
                
                foreach (DataGridViewColumn columna in controlDataGridView.Columns)
                {
                    columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        public static void mtdFormatearDataGridView(DataGridView controlDataGridView, List<string> columnas, enm_G_TipoFormatoDataGridView tipo = default)
        {
            string strCantidadDigitos = string.Empty;
            foreach (string columna in columnas)
            {
                if (controlDataGridView.Columns[columna] != null)
                {
                    switch (tipo)
                    {
                        case enm_G_TipoFormatoDataGridView.Fecha:
                            controlDataGridView.Columns[columna].DefaultCellStyle.Format = "dd/MM/yyyy";
                            break;
                        case enm_G_TipoFormatoDataGridView.Decimal:
                            controlDataGridView.Columns[columna].DefaultCellStyle.Format = "N2";
                            break;
                        case enm_G_TipoFormatoDataGridView.Visible:
                            controlDataGridView.Columns[columna].Visible = false;
                            break;
                    }
                }
            }
        }

        public static void mtdSeleccionarRegistro(DataGridView controlDataGridView, string columna)
        {
            try
            {
                if (controlDataGridView.Rows.Count > 0)
                {
                    //Agregar para buscar, no set 0
                    //
                    
                    //Set 0
                    controlDataGridView.Rows[0].Cells[columna].Selected = true;
                }
            }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
        }

        public static object mtdObtenerCeldaDataGridViewRow(DataGridViewRow controlDataGridViewRow, string columnHeader)
        {
            try { return controlDataGridViewRow.Cells[columnHeader].Value; }
            catch (Exception ex) { mtdMostrarMensaje(ex.Message); }
            return null;
        }
    }
}
