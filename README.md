# Implementação de PCDs na Amazônia 

Contexto: Brasil resolve implementar um sistema que monitora rios (coleta de dados). Assim, eles espalham na Amazônia plataformas que medem esses dados sobre os rios: temperaturas, pH, pressão atmosférica, umidade do ar. 

Mais precisamente, existem várias plataformas de coletas de dados e várias Instituições Acadêmicas em diferentes cidades do brasil. Nesse sentido, cada Universidade começa a demonstrar interesse em observar algum rio específico.

Logo, deve-se instanciar várias PCDs e várias Instituições e, depois, usando o padrão “observer”, fazer com que as instituições se tornem observadoras dos rios (sujeitos). Além disso, quando houver um update em algum dos atributos (sensores), é necessário que os observadores sejam notificados da mudança e implementem (no seu método update - implementado da interface Observer) uma impressão na tela, que descreva aquela modificação.  
