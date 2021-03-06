/* ====================================================================
   

   
	
   
   
   

       

   
   
   
   
   


   
   
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;            // need this for the properties metadata
using System.Drawing.Design;
using System.Xml;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Oranikle.ReportDesigner
{
    /// <summary>
    /// PropertyExpr - 
    /// </summary>
    [TypeConverter(typeof(PropertyMarginConverter))]
    internal class PropertyMargin
    {
        PropertyReport _pr;

        internal PropertyMargin(PropertyReport pr)
        {
            _pr = pr;
        }
        [RefreshProperties(RefreshProperties.Repaint)]
        public string Left
        {
            get
            {
                return _pr.GetReportValue("LeftMargin");
            }
            set
            {
                SetMargin("LeftMargin", value);
            }
        }
        [RefreshProperties(RefreshProperties.Repaint)]
        public string Right
        {
            get
            {
                return _pr.GetReportValue("RightMargin");
            }
            set
            {
                SetMargin("RightMargin", value);
            }
        }
        [RefreshProperties(RefreshProperties.Repaint)]
        public string Top
        {
            get
            {
                return _pr.GetReportValue("TopMargin");
            }
            set
            {
                SetMargin("TopMargin", value);
            }
        }
        [RefreshProperties(RefreshProperties.Repaint)]
        public string Bottom
        {
            get
            {
                return _pr.GetReportValue("BottomMargin");
            }
            set
            {
                SetMargin("BottomMargin", value);
            }
        }

        void SetMargin(string l, string v)
        {
            DesignerUtility.ValidateSize(v, true, false);
            _pr.SetReportValue(l, v);
        }

    }

    internal class PropertyMarginConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context,
                                         System.Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, 
            CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is PropertyMargin)
            {
                PropertyMargin pe = value as PropertyMargin;
                return string.Format("(l={0}, t={1}, r={2}, b={3})", pe.Left, pe.Top, pe.Right, pe.Bottom);
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

    }
}