using Eequiis.Xamarin.Popup.Paginas;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eequiis.Xamarin.Popup.Servicios
{
	/// <summary>
	/// <para>Clase con métodos de extensión para la infraestructura de la biblioteca Rg.Plugins.Popup.</para>
	/// </summary>
	public static class ExtensionesPilaPopup
	{
		/// <summary>
		/// <para>Dado un <see cref="IPopupNavigation"/>, obtiene la <see cref="PopupPage"/> que está en la cima de su
		/// pila de páginas (<see cref="IPopupNavigation.PopupStack"/>).</para>
		/// <para>Si el objeto de navegación de páginas indicado es nulo, o su pila es nula o está vacía, se devolverá
		/// <c>null</c>.</para>
		/// <para><i>Nota: este método no altera la pila del navegador, es decir, no saca la página en la cima de la
		/// propia pila, por lo que difiere del método <c>pop</c> típico de las pilas.</i></para>
		/// </summary>
		/// <param name="navigation">Objeto de navegación de páginas de popup cuya cima se va a obtener.</param>
		/// <returns>La página que está en la cima de la pila de este navegador, o <c>null</c>.</returns>
		public static PopupPage CimaPila(this IPopupNavigation navigation)
			=> navigation?.PopupStack is IReadOnlyList<PopupPage> pila && pila.Count > 0 ? pila.Last() : null;

		/// <summary>
		/// <para>Dado un <see cref="IPopupNavigation"/>, obtiene el número de páginas (<see cref="PopupPage"/>) que
		/// contiene la pila del objeto de navegación.</para>
		/// <para>Si el objeto de navegación de páginas indicado es nulo, o su pila es nula, se devolverá 0.</para>
		/// </summary>
		/// <param name="navigation">Objeto de navegación cuyo número de páginas de popup se va a consultar.</param>
		/// <returns>El número de páginas del objeto de navegación indicado.</returns>
		public static int Paginas(this IPopupNavigation navigation)
			=> navigation?.PopupStack is IReadOnlyList<PopupPage> pila ? pila.Count : 0;

		/// <summary>
		/// <para>Comprueba si la pila del navegador indicado debería estar bloqueada, es decir, si se debería impedir
		/// que se pueda desapilar páginas.</para>
		/// <para>En este sentido, se considerará que un navegador debería bloquear su pila si su cima es un página de
		/// tipo <see cref="PopupCarga"/>.</para>
		/// <para><i>Nota: este método no bloquea la pila en sí misma, sino que únicamente comprueba si debería
		/// bloquearse de manera externa.</i></para>
		/// </summary>
		/// <param name="navigation">Navegador de páginas de popup cuya pila se va a comprobar.</param>
		/// <returns>Un valor booleano que indica si la pila del navegador indicado debería bloquer las operaciones de
		/// desapilado.</returns>
		[Obsolete("Sustituir por comprobación de tipos \"CimaPila() is PopupCarga\".", false)]
		public static bool DebeBloquearPila(this IPopupNavigation navigation) => navigation.CimaPila() is PopupCarga;
	}
}
