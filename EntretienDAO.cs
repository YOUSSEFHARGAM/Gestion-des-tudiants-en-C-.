using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class EntretienDAO
    {
        #region Singleton


        private static readonly object myLock = new object();
        private static EntretienDAO instance = null;
        private EntretienDAO()
        {

        }
        public static EntretienDAO getInstance()
        {
            lock (myLock)
            {
                if (instance == null) instance = new EntretienDAO();

                return instance;
            }
        }
        #endregion
        #region CRUD
        public void ADDEntretien(Entretien en)
        {
            using (ProjetEntities P = new ProjetEntities())
            {

                P.Entretien.AddObject(en);
                P.SaveChanges();
            }
        }
        public List<Entretien> listeEntretien()
        {
            using (ProjetEntities ce = new ProjetEntities())
            {
                return ce.Entretien.ToList<Entretien>();
            }
        }
        public void DeleteEntretien(Entretien en)
        {
            using (ProjetEntities ce = new ProjetEntities())
            {

                var req = ce.Entretien.Where(etu => etu.IdEntretien == en.IdEntretien).First();
                ce.Entretien.DeleteObject(req);
                ce.SaveChanges();
            }
        }
        public void UpdateEntretien(Entretien newConv)
        {
            using (ProjetEntities ce = new ProjetEntities())
            {
                var req = (from p in ce.Entretien
                           where p.IdEntretien == newConv.IdEntretien
                           select p).FirstOrDefault();
                //req.Date_deb = newConv.Date_deb;
                //req.Date_fin = newConv.Date_fin;
                //req.Periodicite = newConv.Periodicite;
                //req.Code_regroup = newConv.Code_regroup;
                //req.Type_convention = newConv.Type_convention;
                //req.branche = newConv.branche;


                ce.SaveChanges();
            }
        }



        public Entretien getEntretienByID(int IdEntretien)
        {



            using (ProjetEntities ce = new ProjetEntities())
            {


                return ce.Entretien.Where(e => e.IdEntretien == IdEntretien).SingleOrDefault();
            }
        }


        #endregion

    }
}
