using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationAPI.Extensions
{
    public static class DataBaseExtension
    {
        public static T IsDBNull<T>(this object dataRow) where T: IConvertible
        {
			try
			{
				return (T) Convert.ChangeType(dataRow, typeof(T));
			}
			catch (Exception)
			{

				return default(T);
			}
        }   
    }
}
