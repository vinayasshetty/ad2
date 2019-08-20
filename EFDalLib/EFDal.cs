using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDalLib
{
    public class EFDal
    {
        public List<tbl_employee> GetAllEmps()
        {
            using (var dbCtx = new ValtechDBEntities())
            {
                var result = dbCtx.tbl_employee.ToList();
                return result;
            }
        }
        public  void AddEmployee(tbl_employee emp)
        {
            using (var dbCtx = new ValtechDBEntities())
            {
                dbCtx.tbl_employee.Add(emp);
                dbCtx.SaveChanges();
            }

        }
        public void DeleteById(int ecode)
        {
            using (var dbCtx = new ValtechDBEntities())
            {
                var record = dbCtx.tbl_employee
                                    .Where(o => o.Ecode == ecode)
                                    .SingleOrDefault();
                //delete record
                dbCtx.tbl_employee.Remove(record);
                dbCtx.SaveChanges();
            }
                
        }
        public void UpdateEmp(tbl_employee emp)
        {
            using (var dbCtx = new ValtechDBEntities())
            {
                var record = dbCtx.tbl_employee
                                    .Where(o => o.Ecode == emp.Ecode)
                                    .SingleOrDefault();
                //delete record
                record.salary = emp.salary;
                dbCtx.SaveChanges();
            }

        }
        public tbl_employee GetEmpById(int ecode)
        {
            using (var dbCtx = new ValtechDBEntities())
            {
                var record = dbCtx.tbl_employee
                             .Where(o => o.Ecode == ecode)
                             .SingleOrDefault();
               
                return record;
                dbCtx.SaveChanges();
            }

        }
    }
}
