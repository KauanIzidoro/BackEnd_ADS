# Arquitetura MVC 

A arquitetura MVC (Model-View-Controller) é um padrão de design usado para criar aplicativos organizafos e escaláveis. No contexto do `ASP.NET Core MVC`, este padrão separa uma aplicação em três componentes principais:

#### 1. Model:
O Modelo representa a camada de dados da aplicação. Ele define a lógica dos dados e as regras de negócio, além de interagir com o banco de dados ou outas fontes de dados. Os modelos são responsáveis por recuperar, salvar e manipular os dados da aplicação.

#### 2. View: 
A Visualização é responsável pela interface do usuário, ou seja, pela apresentação dos dados. Ela exibe os dados que o `Model` fornece e gera a interface com que o usuário interage. No `ASP.NET Core`, as visualizações normalmente usam `Razor`, que é uma sintaze específica para a combinação de `C#` e `HTML`.

#### 3. Controller: 
O Controlador atua como intermediário entre o modelo e a visualização. Ele lida com as solicitações do usuário, processa a entrada, chama os métodos apropriados no `Model` e, em seguida, escolhe a `View` apropriada para exibir a resposta.

A vantagem da arquitetura `MVC` é a separação clara de responsabilidades, o que facilita a manutenção, teste e escalabilidade da aplicação. No `ASP.NET Core`, o MVC é altamente flexível e extensível, tornando-o ideal para a construção de aplicações `WEB` modernas.