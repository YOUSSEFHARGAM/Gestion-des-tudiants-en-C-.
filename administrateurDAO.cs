using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class administateurDAO
    {
        #region Singleton


        private static readonly object myLock = new object();
        private static administateurDAO instance = null;
        private administateurDAO()
        {

        }
        public static administateurDAO getInstance()
        {
            lock (myLock)
            {
                if (instance == null) instance = new administateurDAO();
                return instance;
            }
        }
        #endregion
        #region CRUD

        public void AddAdministateur(Administrateur a)
        {
            using (ProjetEntities ce = new ProjetEntities())
            {
                ce.Administrateur.AddObject(a);
                ce.SaveChanges();
            }
        }
        public List<Administrateur> listeAdministrateur()
        {
            using (ProjetEntities ce = new ProjetEntities())
            {
                return ce.Administrateur.ToList<Administrateur>();
            }
        }
        public void DeleteAdministrateur(Administrateur c)
        {
            using (ProjetEntities ce = new ProjetEntities())
            {

                var req = ce.Administrateur.Where(etu => etu.CIN == c.CIN).First();
                ce.Administrateur.DeleteObject(req);
                ce.SaveChanges();
            }
        }
        public void UpdateAdministrateur(Administrateur newConv)
        {
            using (ProjetEntities ce = new ProjetEntities())
            {
                var req = (from p in ce.Administrateur
                           where p.CIN == newConv.CIN
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



        public Administrateur getAdministrateurByID(int CIN)
        {



            using (ProjetEntities ce = new ProjetEntities())
            {

                return ce.Administrateur.Where(e => e.CIN == CIN).SingleOrDefault();
            }
        }


        #endregion

    }
}
