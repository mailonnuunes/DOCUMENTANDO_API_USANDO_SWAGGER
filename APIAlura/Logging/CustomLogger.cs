namespace APIAlura.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _providerConfiguration;

        public CustomLogger(string nome,CustomLoggerProviderConfiguration configuration)
        {
            _loggerName = nome;
            _providerConfiguration = configuration;
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel,
            EventId eventId,
            TState state, 
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            var mensagem = string.Format($"{logLevel} : {eventId}" + 
                $" - {formatter(state, exception)}");
            EscreverTextoNoArquivo(mensagem);
        }
        private void EscreverTextoNoArquivo(string mensagem)
        {
            var caminhoDoArquivo = $@"C:\Users\mailo\OneDrive\Documentos\.net\Trabalhando com logs com Ilogger\APIAlura\bin\LOG-{DateTime.Now:yyyy-MM-dd}.txt";

            if (!File.Exists(caminhoDoArquivo))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(caminhoDoArquivo));
                File.Create(caminhoDoArquivo).Dispose();
            }

            using StreamWriter streamWriter = new StreamWriter(caminhoDoArquivo, true);
            streamWriter.WriteLine(mensagem);
            streamWriter.Close();
        }
    }
}
