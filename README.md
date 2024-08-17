## Guía para correr el proyecto `MyTask` de forma local

- #### Levantar la Imagen de PostgreSQL con Docker Compose

  Para levantar la base de datos PostgreSQL con Docker Compose, ejecuta el siguiente comando en la raíz del proyecto donde está el archivo `docker-compose.yml`:

  ```
  docker-compose up -d
  ```

  Esto descargará la imagen de PostgreSQL (si no está ya descargada) y levantará el contenedor en segundo plano.

- #### Configurar la Conexión a la Base de Datos

  En el proyecto `MyTask`, asegúrate de que el archivo `appsettings.json`  esté configurado correctamente para conectarse a la base de datos PostgreSQL que acabas de levantar.

- #### Aplicar Migraciones a la Base de Datos

  aplicar las migraciones para crear el esquema de la base de datos en PostgreSQL:

  ```
  dotnet ef database update
  ```

  Este comando aplicará las migraciones y creará las tablas necesarias en la base de datos PostgreSQL.

- #### Correr la API Localmente

  Ahora, puedes correr la API localmente usando el siguiente comando:

  ```
  dotnet run
  ```

  Este comando compilará y ejecutará la API en el puerto `5215`.

En el proyecto se agregó una colección de Postman para probarlo.
