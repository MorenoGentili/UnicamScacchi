using System.Collections.Generic;
using System.Linq;
using Scacchi.Modello;
using Scacchi.Modello.Pezzi;

namespace Scacchi.Extensions {
    public static class ScacchieraExtensions {
        public static IEnumerable<ICasa> ConPezzi(this IEnumerable<ICasa> listaCase) {
            return listaCase.Where(casa => casa.PezzoPresente != null);
        }

        public static IEnumerable<ICasa> ConPezzi(this IEnumerable<ICasa> listaCase, Colore colore) {
            return listaCase.Where(casa => casa.PezzoPresente?.Colore == colore);
        }

        public static IEnumerable<ICasa> DiTipo<T>(this IEnumerable<ICasa> listaCase) where T : IPezzo {
            return listaCase.Where(casa => casa.PezzoPresente?.GetType() == typeof(T));
        }

    }
}