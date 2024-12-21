// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

// Caminho do script Python e do arquivo de imagem
string pythonPath = "python3";  // Ou "python", dependendo do seu ambiente
string scriptPath = "/app/command.py"; // Caminho do script Python no container

// Primeiro, passar o nome do arquivo de texto para ler
string fileName = "file.txt"; // Nome do arquivo a ser lido pelo Python

// Configurar o processo para executar o script Python e capturar a saída
ProcessStartInfo startInfo = new ProcessStartInfo
{
    FileName = pythonPath,
    Arguments = $"{scriptPath} {fileName}",  // Passar o arquivo como argumento
    RedirectStandardOutput = true,  // Capturar a saída do script Python
    UseShellExecute = false,
    CreateNoWindow = true  // Não exibir a janela do terminal
};

// Iniciar o processo para ler o arquivo
using (Process process = Process.Start(startInfo))
{
    // Ler a saída do script Python
    using (System.IO.StreamReader reader = process.StandardOutput)
    {
        string result = reader.ReadToEnd();
        Console.WriteLine("Conteúdo do arquivo lido pelo Python:");
        Console.WriteLine(result);  // Exibe o conteúdo retornado pelo Python
    }
}

// Agora, passar o caminho de uma imagem para o Python copiar
string caminhoImagem = @"foto/teste.jpg"; // Caminho da imagem no PC
string destinoImagem = @"/app/imagem_copiada.jpg"; // Destino no container

// Configurar o processo para executar o script Python e copiar a imagem
startInfo.Arguments = $"{scriptPath} {caminhoImagem}"; // Passar caminho da imagem para o Python

// Iniciar o processo para copiar a imagem
using (Process process = Process.Start(startInfo))
{
    // Ler a saída do script Python
    using (System.IO.StreamReader reader = process.StandardOutput)
    {
        string result = reader.ReadToEnd();
        Console.WriteLine("Resultado ao copiar imagem:");
        Console.WriteLine(result);  // Exibe o resultado da cópia
    }
}