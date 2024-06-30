
using Buoi_10.DTA.DTO;
using Buoi_10.DTA.Interface;
using System;
using System.Collections.Generic;

namespace Buoi_10.DTA.Interface
{

    public interface IQuanLyNhanVien
    {

       
        Employy SearchEmployy(int id);


        void Generateoutput(int id, Stage stage);
        void ExportReport();
        void AddEmployy(Employy employy);

    }
}
