1 REM *** ORIGEM: GUIA PRATICO DE SISTEMAS GRAFICOS - APPLE II ***

Escala Humana Obtida com o armazenamento e repeticifo da figura em varias escalas (Fig. 30). 
CAD PARA TRES DIMENSOES 
Fig. 31 - Perspective de peca meanies. 

PERSPECTIVA 
Este programa, adaptado pars o APPLE II, realiza o desenho de perspectivas de objetos 
simples e pode auxiliar no projeto a medida que facilita o encontro de uma posiogo 
favoravel pan se obter uma boa %tido do objeto (Fig. 31). Os dados sao guardados no 
final do programa na instruogo DATA nesta forma:
 - Numero de vertices
 - Vertices (coordenadas X, Y e Z)
 - Numero de arestas (semi-retas de urn vertice a outro)
 - Arestas (aresta de partida, aresta final) 


As primeiras vezes que for entrar os dados procure organizar-se no tocante as linhas de
dados da forma mostrada, pois esta permite a localizacao facil de erros de digitacAo. 
Com o tempo vocé podera verificar vantagens, tais como a diminuicdo do numero de linhas e 
consequiente liberacao de memoria, que justificarao o acumulo de dados numa mesma instrucao DATA.

Examinemos o programa:

40 Ajuste de memoria
50 Dimensionamento de variaveis
70 - 150 Carregamento das matrizes de vértices e arestas
166 - Coordenadas do observador
170 - 230 Calculo de constantes (geometria analitica)
240 - 310 Calculo dos pontos projetados no plano da tela do computador.
320 - 425 Ajuste da figura ao tamanho da tela. 
	Caso essa seja muito menor as constantes aumentarao seus valores, proporcionalmente. 
	Caso-seja maior estas vdo reduzi-la.
430 - 460 Ajuste horizontal e vertical especifico do APPLE. Vide Capitulo 1.
470 - 500 Plotagem
807 - Linha de impressao
1000 - 1999 Dados dos vértices
2006 - 2999 Dados das arestas

Rode o programa. Caso tudo esteja correto vocé devera obter a figura abaixo (Fig. 32) ao
entrar com as coordenadas 10, 20, 30 para o observador.

Fig. 32 - Perspectiva de peca mecanica 10, 10, 10.

Na confeccao de graficos de alta resolucao quanto maior a definicao, o numero de pontos
e ligagcoes, maior a quantidade de memoria requerida para o processamento das imagens.
Uma maneira eficaz de se aumentar a memoria disponfvel seria a criacao de um programa
auxiliar que gravasse os dados num arquivo externo para posterior leitura.
Um pequeno programa poderia receber uma entrada via teclado. Optaremos pelo uso,
mais uma vez, de READ e DATA pois estas facilitam a ediago dos dados.
Utilize o programa a seguir para gerar o arquivo:

O REM ************************************
1 REM * CARREGAMENTO DE FIGURAS EM DISCO
2 REM * ALVARO LUIS CRUZ 
3 REM ************************************
10 DS=CHR$ (4)
20 INPUT "NOME DO ARGUIVO ":NO$
30 PRINT D$; "OPEN "; NO$
40 PRINT D$; "CLOSE"; NO$
50 PRINT D$; "DELETE"; NO$
60 PRINT D$; "OPEN";  NO$
70 PRINT D$; "WRITE "; NO$
80 READ NV
90 PRINT NV
100 FOR A = 1 TO NV
110 READ X,Y,2
120 PRINT X: PRINT Y: PRINT Z
130 NEXT A
140 READ NA
150 PRINT NA
160 FOR A= 1 TO NA
470 READ A1, A2
180 PRINT A1: PRINT A2
190 NEXT
200 PRINT D$: "CLOSE"
210 REM A PARTIR DESTA LINHA ENTRE COM OS DADOS NESTA SEQUENCIA : 
211 REM N* DE VERTICES, VERTICES (X,Y,.Z),... , N* DE ARESTAS, ARESTA INICIAL, ARESTA FINAL, ...
220 DATA ....

Transcreva para este programa os dados da peca anterior.
Para poder acessa-los faremos algumas modificacoes ne programa de perspectiva.
Acrescente estas linhas:

43 D$=CHRS$(4)
72 PRINT D$: "CATALOG"
74 INPUT "LER DADOS DE QUE ARQUIVO ": AQ$
76 PRINT D$: "OPEN ": AQ$
78 PRINT Ds: "READ ": AQ$
80 INPUT NV
100 INPUT X(I), Y(I), Z(I)
120 INPUT NA
140 INPUT V1(I), V2(I)
155 PRINT D$: "CLOSE"

Com estas linhas seu programa ja poderd ler dados nos disquetes. 
Agora, delete as linhas DATA a partir da linha 1000.

DEL 1000, 2999

Com isso, figuras mais complexas podem ser desenhadas, 
pois a drea que os valores das varigveis do programa ocupavam esta livre.

Tente agora com uma figura propria.

PASSOS BASICOS

1. Monte uma tabela com todos os vértices da figura. 
Lembre-se que um circulo pode ser aproximado como um conjunto de semi-retas proximas.

2. Relacionar todas as ligacdes entre os diferentes vértices, ou seja, qual vértice se liga
com qual. O numero dos vértices e o numero da posicao de entrada de cada um deles. 
No nosso caso o vértice 1 e' o 0,0,0; o 2 é o 10,0,0 etc.

3. Preencha as instrucSes DATA do nosso Programa de carregamento de figuras com estes valores.

4. Execute o programa.

5. Rode, agora, o novo programa de perspectiva.

6. Caso nao haja ligagdes ou vértices mal posicionados e a figura ndo va sofrer novas alteracoe,
vocé pode deletar as linhas DATA do carregamento de figuras. 
Caso contrario, retorne e ajuste os DADOS.

Caso vocé deseje imprimir a figura, sera perguntado pelos caracteres de impressao que sao
caracteres especificos da placa que poder&o duplicar a pagina grafica, rodé-la de 180’ ou ainda
imprimi-la de modo inverso. A auséncia destes determina IMPRESSAO PADRAO.

Com o auxilio da geometria analitica varios Programas podem ser desenvaividos nesta area.

Qualquer contribuicao, tal como, agilizagdo destes programas e ou criacdo de outros, pode ser comunicada ao autor.


