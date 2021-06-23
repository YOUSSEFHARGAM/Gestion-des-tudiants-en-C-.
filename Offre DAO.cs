using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OffreDAO
    {
        #region Singleton


        private static readonly object myLock = new object();
        private static OffreDAO instance = null;
        private OffreDAO()
        {

        }
        public static OffreDAO getInstance()
        {
            lock (myLock)
            {
                if (instance == null) instance = new OffreDAO();

                return instance;
            }
        }
        #endregion
        #region CRUD
        public void ADDOffreEmploi(OffreEmploi off)
        {
            using (ProjetEntities P = new ProjetEntities())
            {

                P.OffreEmploi.AddObject(off);
                P.SaveChanges();
            }
        }
        public List<OffreEmploi> listeOffreEmploi()
        {
            using (ProjetEntities ce = new ProjetEntities())
            {
                return ce.OffreEmploi.ToList<OffreEmploi>();
            }
        }
        public void DeleteOffreEmploi(OffreEmploi off)
        {
            using (ProjetEntities ce = new ProjetEntities())
            {

                var req = ce.OffreEmploi.Where(etu => etu.IdOffre == off.IdOffre).First();
                ce.OffreEmploi.DeleteObject(req);
                ce.SaveChanges();
            }
        }
        public void UpdateOffreEmploi(OffreEmploi newConv)
        {
            using (ProjetEntities ce = new ProjetEntities())
            {
                var req = (from p in ce.OffreEmploi
                           where p.IdOffre == newConv.IdOffre
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



        public OffreEmploi getOffreEmploiByID(int IdOffre)
        {



            using (ProjetEntities ce = new ProjetEntities())
            {


                return ce.OffreEmploi.Where(e => e.IdOffre == IdOffre).SingleOrDefault();
            }
        }


        #endregion

    }
}
