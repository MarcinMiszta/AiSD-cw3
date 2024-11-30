using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BST
{
    internal class BST
    {
        public NodeT root;
        public NodeT Add(int liczba)
        {
            var dziecko = new NodeT(liczba);
            if (this.root == null)
            { 
                this.root = dziecko;
            }
            else
            {
                var rodzic = this.ZnajdzRodzica(dziecko);
                dziecko.rodzic = rodzic;
                if(dziecko.data < rodzic.data)
                {
                    rodzic.lewe = dziecko;
                }
                else
                {
                    rodzic.prawe = dziecko;
                }
            }

            return dziecko;
        }
        /* kasowanie wezla
 * 1) Gdy nie ma dziecka odcinamy od góry.
 * 2) Gdy jest jedno dziecko odcinamy od gory i od dołu a dziecko zastepuje wezeł
 * 3) gdy dwoje dzieci to :
 * a) znajdujemy kandydata na zastapienie w prawym poddrzewie kasowanego wezła znajdujemy najmniejsza wartosc
 * b) odłaczenie kandydata od drzewa
 * c) zamiana usunietego wezła na znalezionego kandydata 
 */
        public void Remove(int liczba)
        {
            var node = ZnajdzNodeT(liczba);

           //1
            if (node.lewe == null && node.prawe == null)
            {
                if (node.rodzic == null)
                {
                    root = null;
                }
                else if (node.rodzic.data < liczba)
                {
                    node.rodzic.prawe = null;
                }
                else
                {
                    node.rodzic.lewe = null;
                }
            }
            // 2
            else if (node.lewe == null && node.rodzic != null && node.rodzic.prawe == node)
            {
                node.rodzic.prawe = node.prawe;
                if (node.prawe != null)
                {
                    node.prawe.rodzic = node.rodzic;
                }
            }
            // 2
            else if (node.prawe == null && node.rodzic != null && node.rodzic.prawe == node)
            {
                node.rodzic.prawe = node.lewe;
                if (node.lewe != null)
                {
                    node.lewe.rodzic = node.rodzic;
                }
            }
            // 2
            else if (node.lewe == null && node.rodzic != null && node.rodzic.lewe == node)
            {
                node.rodzic.lewe = node.prawe;
                if (node.prawe != null)
                {
                    node.prawe.rodzic = node.rodzic;
                }
            }
            // 2
            else if (node.prawe == null && node.rodzic != null && node.rodzic.lewe == node)
            {
                node.rodzic.lewe = node.lewe;
                if (node.lewe != null)
                {
                    node.lewe.rodzic = node.rodzic;
                }
            }
            // 3
            else
            {
                var tmp = node.prawe;
                while (tmp.lewe != null)
                {
                    tmp = tmp.lewe;
                }

                var data = tmp.data;
                tmp.data = node.data;
                node.data = data;

                if (tmp.rodzic.prawe == tmp)
                {
                    tmp.rodzic.prawe = tmp.prawe;
                }
                else
                {
                    tmp.rodzic.lewe = tmp.prawe;
                }

                if (tmp.prawe != null)
                {
                    tmp.prawe.rodzic = tmp.rodzic;
                }
            }
        }


        public NodeT ZnajdzNodeT(int liczba)
        {
            if (root == null)
                throw new KeyNotFoundException("Drzewo jest puste.");
            NodeT node = root;
            while (true)
            {
                if (node.data == liczba) return node;
                if (liczba > node.data)
                {
                    if (node.prawe == null) throw new KeyNotFoundException("Nie znaleziono."); 
                    node = node.prawe;
                    
                }
                else
                {
                    if (node.lewe == null) throw new KeyNotFoundException("Nie znaleziono."); 
                    node = node.lewe;
                }
            
            }
        }
        public string WypiszDrzewo()
        {
            if (root == null) return "Drzewo jest puste.";
            StringBuilder sb = new StringBuilder();
            WypiszRekurencyjnie(root, 0, sb);
            return sb.ToString();
        }

        private void WypiszRekurencyjnie(NodeT node, int poziom, StringBuilder sb)
        {
            if (node == null) return;

            WypiszRekurencyjnie(node.prawe, poziom + 1, sb); 
            sb.AppendLine(new string(' ', poziom * 4) + node.data); 
            WypiszRekurencyjnie(node.lewe, poziom + 1, sb); 
        }


        public NodeT ZnajdzRodzica(NodeT dziecko)
        {
            var rodzic = root;
            while (true) {
                if (dziecko.data < rodzic.data)
                {
                    if (rodzic.lewe == null)
                    {
                        return rodzic;
                    }
                    else
                    {
                        rodzic = rodzic.lewe;
                    }
                }
                else
                {
                    if (rodzic.prawe == null)
                    {
                        return rodzic;
                    }
                    else
                    {
                        rodzic = rodzic.prawe;
                    }
                }
            } 
        }

    }
}
