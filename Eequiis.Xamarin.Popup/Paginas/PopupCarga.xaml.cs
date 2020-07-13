using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Eequiis.Xamarin.Popup.Paginas
{
	/// <summary>
	/// <para>Es una página con fondo transparente que contiene un indicador de carga infinito (una ruletita).</para>
	/// <para>El indicador estará en una caja de un color no transparente (<see cref="Color.WhiteSmoke"/> por defecto,
	/// con 100px de lado), y tendrá un borde (2px de color <see cref="Color.Gray"/> por defecto). Estos valores se
	/// pueden cambiar en el momento de la construcción del Popup.</para>
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupCarga : PopupPage
	{
		private static readonly int BordeMinimo = 1;    // 1px como borde mínimo, pero desaconsejado
		private static readonly int BordeEstandar = 2;  // 2px de borde está bien, menos se ve raro
		private static readonly int BordeMaximo = 100;  // 100px de borde es descomunal, limitando

		private static readonly Color ColorBorde = Color.Gray;      // Color más oscuro que la caja
		private static readonly Color ColorCaja = Color.WhiteSmoke; // Color más claro que el borde

		/// <summary>
		/// <para>26px es el lado mínimo establecido para cualquier Popup de Carga.</para>
		/// <para>Es un tamaño enano, que solo se debería utilizar como valor de rescate, ya que no es efectivamente
		/// visible en una pantalla normal, incluso en dispositivos pequeños (Salvo pantallas de 144px o de dimensiones
		/// similares).</para>
		/// </summary>
		public static readonly int LadoMinimo = 26;

		/// <summary>
		/// <para>100px es el lado estándar establecido para cualquier Popup de Carga.</para>
		/// <para>Es un tamaño suficientemente grande para ser visible en dispositivos pequeños como smartphones de
		/// menos de 5" de pantalla, pero sigue siendo un tamaño pequeño para la mayoría de dispositivos.</para>
		/// <para>Su uso como valor estándar se bede a compatibilidad con pantallas muy pequeñas (4" o menos).</para>
		/// </summary>
		public static readonly int LadoEstandar = 100;

		/// <summary>
		/// <para>400px es el lado grande establecido para cualquier Popup de Carga.</para>
		/// <para>Es suficientemente grande y cómodamente visible para casi cualquier dispositivo de 5" de pantalla, o
		/// tamaños similares. Aunque puede ser muy grande para pantallas pequeñas. Se recomienda tamaños más grandes
		/// para tablets de alrededor de 7", o tamaños superiores.</para>
		/// </summary>
		public static readonly int LadoGrande = 400;        // Suficientemente grande para smatphones de 5"+

		/// <summary>
		/// <para>El tamaño máximo de un Popup de Carga es 8192px, coincidiendo con el tamaño del ancho de la
		/// resolución 8K utilizada en cine (las TV 8K UHD son más pequeñas).</para>
		/// <para>En cualquier caso, se recomienda un tamaño más pequeño que el ancho de la pantalla donde estará el
		/// Popup de Carga.</para>
		/// </summary>
		public static readonly int LadoMaximo = 8192;       // 8K píxeles (super enorme, pero why not? :D)

		private static readonly bool ActivoEstandar = true; // Inicialmente estará activo y corriendo

		/// <summary>
		/// <para>Construye un Popup de Carga con los tamaños y colores indicados.</para>
		/// <para>Si los tamaños son menores que los mínimos o mayores que los máximos establecidos, se saturará por
		/// exceso y por defecto dicha medida, para no salirse de los rangos establecidos.</para>
		/// </summary>
		/// <param name="borde">Ancho del borde de la caja que contiene el indicador (cargador).</param>
		/// <param name="colorBorde">Color del borde anteriormente descrito.</param>
		/// <param name="colorCaja">Color de la caja que contiene el indicador (cargador).</param>
		/// <param name="lado">Lado (ancho y alto) de la caja anteriormente descrita.</param>
		/// <param name="activo">Indica si el indicador de carga estará visible y activo.</param>
		public PopupCarga(int borde, Color colorBorde, Color colorCaja, int lado, bool activo)
		{
			if (borde < BordeMinimo) borde = BordeMinimo;
			else if (borde > BordeMaximo) borde = BordeMaximo;

			if (lado < LadoMinimo) lado = LadoMinimo;
			else if (lado > LadoMaximo) lado = LadoMaximo;

			InitializeComponent();

			BordeCaja.Padding = borde;
			BordeCaja.BackgroundColor = colorBorde;

			CajaIndicador.BackgroundColor = colorCaja;

			Indicador.WidthRequest = lado;
			Indicador.HeightRequest = lado;
			Indicador.IsVisible = activo;
			Indicador.IsRunning = activo;
		}

		/// <summary>
		/// <para>Construye un Popup de Carga con valores por defecto: 2px de ancho de borde; <see cref="Color.Gray"/>
		/// como color de borde; <see cref="Color.WhiteSmoke"/> como color de la caja contenedora del indicador de
		/// carga; 100px como lado estándar de la caja; e inicialmente visible y corriendo.</para>
		/// </summary>
		public PopupCarga() : this(BordeEstandar, ColorBorde, ColorCaja, LadoEstandar, ActivoEstandar) { }
	}
}