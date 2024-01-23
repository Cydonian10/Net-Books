
namespace BookApi.Servicios
{
    public class EscribirArchivo : IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string nombreArhivo = "Archivo.txt";
        private Timer? timer;

        public EscribirArchivo(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            Escribir("Proceso iniciado");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Dispose();
            Escribir("Proceso finailzado");
            return Task.CompletedTask;
        }

        private void Escribir(string mensaje)
        {
            var ruta = $@"{env.ContentRootPath}\wwwroot\{nombreArhivo}";

            using (StreamWriter writer = new StreamWriter(ruta,append:true))
            {
                writer.WriteLine(mensaje);
            }
        }

        private void DoWork(object? state)
        {
            Escribir("Proceso en ejecución: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }
    }
}
