# Seguridad API

## Español

### Introducción

Esta API está diseñada para gestionar usuarios y autenticación utilizando JWT en .NET. Incluye endpoints para registrar usuarios, obtener usuarios, obtener perfiles de usuario, autenticarse y resetear contraseñas, con roles y protección de rutas.

---

### Instalación y Configuración

#### 1. Clona el repositorio:

```bash
git clone https://github.com/diegoalonsonm/Seguridad.git
```

#### 2. Configura la base de datos y la cadena de conexión:

- Edita el archivo `appsettings.json` y añade la cadena de conexión bajo la clave `Seguridad`.

#### 3. Configura los valores de JWT:

- En la sección `Token` de `appsettings.json`, define:
  - `Issuer`: Emisor del token.
  - `Audience`: Audiencia válida.
  - `key`: Clave secreta para firmar el token.
  - `ExpiresIn`: Minutos de validez del token.

#### 4. Ejecuta la API

```bash
dotnet run --project API
```

La API estará disponible usualmente en `https://localhost:5001` o el puerto configurado.

---

### Métodos de la API

#### 1. Registrar Usuario

- **Ruta:** `POST /api/Usuario/RegistrarUsuario`
- **Acceso:** Público (no requiere autenticación)
- **Descripción:** Registra un nuevo usuario en el sistema.
- **Cuerpo de la petición:**
  ```json
  {
    "nombre": "usuario",
    "passwordHash": "contraseña_hasheada",
    "correo": "correo@dominio.com"
  }
  ```
- **Respuesta:** Devuelve el GUID del usuario creado.

---

#### 2. Obtener Usuario

- **Ruta:** `POST /api/Usuario/ObtenerUsuario`
- **Acceso:** Requiere autenticación y rol `2`
- **Descripción:** Obtiene la información de un usuario existente.
- **Cuerpo de la petición:**
  ```json
  {
    "nombre": "usuario",
    "correo": "correo@dominio.com"
  }
  ```
- **Autenticación:** El encabezado debe incluir `Authorization: Bearer <token>`.
- **Respuesta:** Devuelve la información del usuario.

---

#### 3. Autenticación (Login)

- **Ruta:** `POST /api/Autenticacion/login`
- **Acceso:** Público
- **Descripción:** Autentica al usuario y devuelve un token JWT.
- **Cuerpo de la petición:**
  ```json
  {
    "nombre": "usuario",
    "correo": "correo@dominio.com",
    "passwordHash": "contraseña_hasheada"
  }
  ```
- **Respuesta:**
  ```json
  {
    "accessToken": "<jwt_token>",
    "validacionExitosa": true
  }
  ```

---

#### 4. Resetear Contraseña

- **Ruta:** `POST /api/Autenticacion/ResetearPassword`
- **Acceso:** Público (no requiere autenticación)
- **Descripción:** Permite resetear la contraseña de un usuario utilizando su correo electrónico.
- **Cuerpo de la petición:**
  ```json
  {
    "correo": "correo@dominio.com",
    "nuevoPasswordHash": "nueva_contraseña_hasheada"
  }
  ```
- **Respuesta:** `true` si el reseteo fue exitoso, `false` si falló (usuario no encontrado).

---

#### 5. Obtener Perfiles por Usuario

- **Método interno usado en autenticación**
- **Descripción:** Retorna los perfiles (roles) que tiene el usuario.
- **Parámetros:** Se utiliza el mismo modelo de usuario, con nombre y correo.

---

### Ejemplo paso a paso

1. **Registrar un Usuario**
   - Realiza un `POST /api/Usuario/RegistrarUsuario` con el modelo indicado arriba.

2. **Autenticar Usuario**
   - Realiza un `POST /api/Autenticacion` con tu nombre, correo y contraseña hasheada.
   - Recibe el `accessToken`.

3. **Obtener Usuario**
   - Realiza un `POST /api/Usuario/ObtenerUsuario` con el modelo del usuario.
   - Incluye el token recibido en el encabezado de autorización.

4. **Resetear Contraseña** (Opcional)
   - Realiza un `POST /api/Autenticacion/ResetearPassword` con el correo y la nueva contraseña hasheada.
   - No requiere autenticación previa.

---

### Documentación Interactiva

- Accede a `/swagger` en modo desarrollo para ver y probar los endpoints.

---

## English

### Introduction

This API is designed for user management and authentication using JWT in .NET. It includes endpoints to register users, get users, get user profiles, authenticate, and reset passwords, with roles and route protection.

---

### Installation and Setup

#### 1. Clone the repository:

```bash
git clone https://github.com/diegoalonsonm/Seguridad.git
```

#### 2. Configure the database and connection string:

- Edit the `appsettings.json` file and add your connection string under the `Seguridad` key.

#### 3. Configure JWT values:

- In the `Token` section of `appsettings.json`, set:
  - `Issuer`: Token issuer.
  - `Audience`: Valid audience.
  - `key`: Secret key to sign the token.
  - `ExpiresIn`: Token validity in minutes.

#### 4. Run the API

```bash
dotnet run --project API
```

The API will usually be available at `https://localhost:5001` or the configured port.

---

### API Methods

#### 1. Register User

- **Route:** `POST /api/Usuario/RegistrarUsuario`
- **Access:** Public (no authentication required)
- **Description:** Registers a new user in the system.
- **Request body:**
  ```json
  {
    "nombre": "user",
    "passwordHash": "hashed_password",
    "correo": "email@domain.com"
  }
  ```
- **Response:** Returns the GUID of the created user.

---

#### 2. Get User

- **Route:** `POST /api/Usuario/ObtenerUsuario`
- **Access:** Requires authentication and role `2`
- **Description:** Gets information about an existing user.
- **Request body:**
  ```json
  {
    "nombre": "user",
    "correo": "email@domain.com"
  }
  ```
- **Authentication:** The header must include `Authorization: Bearer <token>`.
- **Response:** Returns user information.

---

#### 3. Authentication (Login)

- **Route:** `POST /api/Autenticacion/login`
- **Access:** Public
- **Description:** Authenticates the user and returns a JWT token.
- **Request body:**
  ```json
  {
    "nombre": "user",
    "correo": "email@domain.com",
    "passwordHash": "hashed_password"
  }
  ```
- **Response:**
  ```json
  {
    "accessToken": "<jwt_token>",
    "validacionExitosa": true
  }
  ```

---

#### 4. Reset Password

- **Route:** `POST /api/Autenticacion/ResetearPassword`
- **Access:** Public (no authentication required)
- **Description:** Allows resetting a user's password using their email address.
- **Request body:**
  ```json
  {
    "correo": "email@domain.com",
    "nuevoPasswordHash": "new_hashed_password"
  }
  ```
- **Response:** `true` if reset was successful, `false` if failed (user not found).

---

#### 5. Get Profiles by User

- **Internal method used in authentication**
- **Description:** Returns the profiles (roles) the user has.
- **Parameters:** Uses the same user model, with name and email.

---

### Step-by-step Example

1. **Register a User**
   - Make a `POST /api/Usuario/RegistrarUsuario` request with the model shown above.

2. **Authenticate User**
   - Make a `POST /api/Autenticacion` request with your name, email, and hashed password.
   - Receive the `accessToken`.

3. **Get User**
   - Make a `POST /api/Usuario/ObtenerUsuario` request with the user model.
   - Include the received token in the authorization header.

4. **Reset Password** (Optional)
   - Make a `POST /api/Autenticacion/ResetearPassword` request with the email and new hashed password.
   - No prior authentication required.

---

### Interactive Documentation

- Access `/swagger` in development mode to view and test the endpoints.

---
