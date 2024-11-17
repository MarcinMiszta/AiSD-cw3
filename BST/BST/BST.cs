using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
/* kasowanie wezla
 * 1) Gdy nie ma dziecka odcinamy od góry.
 * 2) Gdy jest jedno dziecko odcinamy od gory i od dołu a dziecko zastepuje wezeł
 * 3) gdy dwoje dzieci to :
 * a) znajdujemy kandydata na zastapienie w prawym poddrzewie kasowanego wezła znajdujemy najmniejsza wartosc
 * b) odłaczenie kandydata od drzewa
 * c) zamiana usunietego wezła na znalezionego kandydata 
 */