# 🔗 Encurtador de URL — ASP.NET + React + SQLite

Este é um projeto completo de encurtador de URLs desenvolvido com **ASP.NET Core no back-end**, **React com Vite no front-end** e **SQLite como banco de dados**.

O objetivo é permitir que o usuário insira uma URL longa e receba uma versão curta, que pode ser compartilhada. Ao acessar a URL curta, o sistema redireciona automaticamente para o link original.

---

## ✨ Funcionalidades

- ✅ Encurtar URLs longas gerando códigos únicos
- ✅ Redirecionar automaticamente para a URL original
- ✅ Front-end amigável e responsivo com React + Tailwind CSS

---

## ⚙️ Tecnologias utilizadas

### Back-end
- ASP.NET Core
- Entity Framework Core (SQLite)
- CORS configurado para integração com front-end
- Swagger para testes da API

### Front-end
- React + Vite
- Tailwind CSS
- Fetch API para integração com o back-end

---

## 🚀 Como rodar o projeto localmente

### 1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/encurtador_url.git
cd encurtador_url
```

---

### 2. Configurar e rodar o Back-end
```bash
cd back
dotnet restore
dotnet ef database update
dotnet run
```

A API será iniciada em: `http://localhost:5285`  
Documentação Swagger: `http://localhost:5285/swagger`

---

### 3. Configurar e rodar o Front-end
Abra outro terminal:
```bash
cd front
npm install
npm run dev
```

O front-end estará disponível em: `http://localhost:5173`

---

## 📌 Endpoints da API

| Método | Rota                               | Descrição                               |
|--------|------------------------------------|------------------------------------------|
| POST   | `/encurtador_url/shorten`          | Encurta uma URL                          |
| GET    | `/encurtador_url/{shortCode}`      | Redireciona para a URL original          |

---


##  Contribuição

Este projeto foi desenvolvido com fins didáticos
Sinta-se à vontade para contribuir melhorar ou adaptar para seus próprios projetos

---

##  inspirações

Este projeto foi inspirado nos vídeos abaixo:

-Codando um encurtador de URL na prática(Augusto Galego)
https://www.youtube.com/watch?v=gHfpFFA3zIQ

-How To Build a URL Shortener With .NET and SQL Server(Milan Jovanovic)
https://www.youtube.com/watch?v=2UoA_PoEvuA

## 👨‍💻 Desenvolvido por

Rafael santos  
