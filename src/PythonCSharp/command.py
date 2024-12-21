import sys
import shutil
import os

def read_file(file_path):
    """Lê o conteúdo de um arquivo de texto e imprime no console."""
    try:
        with open(file_path, 'r') as file:
            content = file.read()  # Lê todo o conteúdo do arquivo
            print(f"Conteúdo do arquivo {file_path}:\n{content}")  # Exibe o conteúdo do arquivo
    except FileNotFoundError:
        print(f"O arquivo '{file_path}' não foi encontrado.")
    except Exception as e:
        print(f"Ocorreu um erro ao ler o arquivo: {e}")

def copiar_imagem(origem, destino):
    """Copia a imagem do caminho de origem para o destino."""
    try:
        # Verifica se o caminho de origem existe
        if os.path.exists(origem):
            # Copia o arquivo para o destino
            shutil.copy(origem, destino)
            print(f"Imagem copiada de {origem} para {destino}")
        else:
            print(f"O caminho da imagem {origem} não existe.")
    except Exception as e:
        print(f"Erro ao copiar a imagem: {e}")

if __name__ == "__main__":
    # Verifica se o argumento para o arquivo de texto foi fornecido
    if len(sys.argv) > 1:
        if sys.argv[1].lower().endswith('.txt'):
            # Caminho do arquivo de texto fornecido
            file_path = sys.argv[1]
            read_file(file_path)
        else:
            # Caminho da imagem fornecido
            caminho_imagem = sys.argv[1]
            destino = "/app/imagem_copiada.jpg"  # Caminho para salvar a imagem
            copiar_imagem(caminho_imagem, destino)
    else:
        print("Nenhum caminho foi fornecido. Por favor, forneça um caminho para o arquivo ou imagem.")