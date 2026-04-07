<div align="center">

![Banner](https://capsule-render.vercel.app/api?type=waving&color=00b4d8&height=250&section=header&text=GYM%20SYSTEM%20API&fontSize=70&animation=fadeIn&fontColor=ffffff)

<p align="center">
  <img src="https://img.shields.io/badge/.NET_Core-10.0-512BD4?style=for-the-badge&logo=.net&logoColor=white" alt=".NET Core" />
  <img src="https://img.shields.io/badge/C%23-12.0-blue?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/SQL_Server-2022-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server" />
  <img src="https://img.shields.io/badge/JWT-Secure-black?style=for-the-badge&logo=json-web-tokens&logoColor=white" alt="JWT" />
</p>

> **Sistema integral de gestión para gimnasios desarrollado con ASP.NET Core Web API, diseñado para automatizar el control de socios, membresías y planes de entrenamiento bajo un entorno seguro de roles.**

</div>

<br />

## 📖 1. Contexto del Proyecto
El proyecto surge ante la necesidad de digitalizar la gestión manual de un gimnasio. El sistema centraliza la información de usuarios, permitiendo un control estricto sobre quién accede a las instalaciones y qué rutinas deben seguir, eliminando errores de duplicidad y pérdida de datos físicos.

## 🛠️ 2. Tecnologías Utilizadas
| Categoría | Tecnología | Uso |
| :--- | :--- | :--- |
| **Backend** | .NET 10 / C# 12 | Lógica principal y API |
| **Base de Datos** | SQL Server 2022 | Almacenamiento persistente |
| **ORM** | Entity Framework Core | Gestión de datos y migraciones |
| **Seguridad** | JWT (JSON Web Tokens) | Autenticación y Autorización |
| **Testing** | Postman | Validación de Endpoints |

## 📂 3. Estructura del Proyecto
El código está organizado siguiendo las mejores prácticas de legibilidad y mantenibilidad:
* **Controllers:** Exposición de las rutas de la API.
* **Models:** Entidades principales (Socio, Membresía, Rutina, Ejercicio, etc.).
* **Dtos:** Objetos para la transferencia segura de datos.
* **Services:** Lógica de negocio separada de los controladores.
* **Data:** Contexto de la base de datos (DbContext).

## 4. Seguridad y Control de Roles (RBAC)
Se ha implementado un sistema de **Control de Acceso Basado en Roles** para garantizar que cada usuario acceda solo a lo que le corresponde:
* **👑 ADMIN:** Acceso total (Usuarios, Roles, Membresías).
* **👟 ENTRENADOR:** Gestión de rutinas, ejercicios y seguimiento de socios.
* **🏋️ SOCIO:** Consulta de perfil, membresía activa y plan de entrenamiento.

##  5. Endpoints Principales
### Autenticación
- `POST /api/Auth/registro` -> Registro de nuevos usuarios con rol.
- `POST /api/Auth/login` -> Generación de Token JWT.
### Gestión de Gimnasio
- `GET /api/Socio` -> Lista de socios (Requiere Autorización).
- `POST /api/SocioMembresia` -> Asignación de planes.
- `GET /api/Asistencia/{id}` -> Historial de ingresos del socio.
- `GET /api/RutinaEjercicio` -> Detalle de ejercicios por rutina.

##  6. Instalación y Ejecución
1. **Clonar repositorio:** `git clone https://github.com/VALDIVIEZOatero/GYM_SERVICIOS_WEB.git`
2. **Configurar DB:** Editar `appsettings.json` con tu servidor local de SQL Server.
3. **Migrar datos:** Ejecutar `dotnet ef database update` en la consola.
4. **Correr proyecto:** Ejecutar `dotnet run`.

## 7. Calidad y Pruebas
- **Validaciones:** Uso de `Data Annotations` para asegurar campos obligatorios y formatos correctos.
- **Postman:** Colección de pruebas configurada para validar respuestas 200, 401 (No autorizado) y 403 (Prohibido).
- **Manejo de Errores:** Respuestas estandarizadas en caso de credenciales incorrectas o tokens expirados.

## 👥 8. Equipo de Desarrollo - Grupo 3
| Integrante |
| :--- | 
| **Siri Vergara María Alejandra** | 
| **Santisteban Manrique Adrián** | 
| **Villasante Contreras Jean Paul** | 
| **Valdiviezo Atero Yoli Jhunior** | 
| **Zurita Rimaicuna Abner ** | 

<br />

---
<p align="center"><b>Proyecto Final - Desarrollo de Servicios Web | Idat abril 2026</b></p>
