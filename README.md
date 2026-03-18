# 🐳 DOCKER DESDE CERO - GUÍA COMPLETA

**Docker desde Cero** es un sitio educativo completo diseñado para enseñar Docker desde los fundamentos hasta conceptos avanzados, con explicaciones claras, ejemplos prácticos y código listo para usar.

> *"Docker ha revolucionado la forma en que desarrollamos, desplegamos y ejecutamos aplicaciones."*

---

## 🎯 ¿Qué es este Proyecto?

Este proyecto proporciona un recurso educativo gratuito para aprender Docker, incluyendo:

- **Documentación completa** de cada tema
- **Ejemplos de código** listos para ejecutar
- **Ejercicios prácticos** para reforzar el aprendizaje
- **Sitio web educativo** con navegación intuitiva

---

## 📚 Contenido del Curso

### Módulo 1: Fundamentos

1. **Introducción**
   - ¿Qué es Docker?
   - Contenedores vs Máquinas Virtuales
   - Beneficios de Docker

2. **Instalación**
   - Docker Desktop en Windows
   - Docker en macOS
   - Docker en Linux
   - Verificación de instalación

3. **Conceptos básicos**
   - Imágenes y contenedores
   - Docker Hub
   - Comandos esenciales
   - Ciclo de vida de contenedores

### Módulo 2: Intermedio

4. **Ejemplos prácticos**
   - Dockerfile personalizado
   - Construcción de imágenes
   - Volúmenes y persistencia
   - Redes en Docker

5. **Buenas prácticas**
   - Imágenes ligeras (Alpine)
   - Multi-stage builds
   - Seguridad en contenedores
   - Optimización de capas

### Módulo 3: Avanzado

6. **Casos reales**
   - Docker Compose
   - Orquestación de servicios
   - CI/CD con Docker
   - Microservicios

7. **Proyecto final**
   - Aplicación completa containerizada
   - Deploy a producción
   - Monitoreo y logs

---

## 🗂️ Estructura del Proyecto

```
Examen/
├── index.html          # Página principal
├── css/
│   └── styles.css      # Estilos del sitio
├── js/
│   └── main.js         # JavaScript del sitio
└── README.md
```

---

## 🚀 Cómo Usar este Proyecto

### Opción 1: Navegar el Sitio Web

1. Abre `index.html` en tu navegador
2. Navega por las secciones del curso
3. Haz clic en los temas para ver la documentación detallada

### Opción 2: Ejecutar los Ejemplos

1. Instala Docker Desktop
2. Abre terminal o PowerShell
3. Ejecuta los comandos de ejemplo

### Requisitos

- **Docker Desktop** instalado
- 4GB RAM mínimo recomendado
- Virtualización activada en BIOS

---

## 📝 Ejemplos Rápidos

### Comandos Básicos

```bash
# Ver versión de Docker
docker --version

# Descargar imagen
docker pull nginx:latest

# Ejecutar contenedor
docker run -d -p 80:80 nginx

# Listar contenedores
docker ps

# Detener contenedor
docker stop <container_id>

# Eliminar contenedor
docker rm <container_id>
```

### Dockerfile Ejemplo

```dockerfile
FROM node:18-alpine

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

EXPOSE 3000

CMD ["npm", "start"]
```

### Docker Compose

```yaml
version: '3.8'

services:
  web:
    build: .
    ports:
      - "3000:3000"
    volumes:
      - .:/app
    depends_on:
      - db

  db:
    image: postgres:15
    environment:
      POSTGRES_PASSWORD: secret
    volumes:
      - pgdata:/var/lib/postgresql/data

volumes:
  pgdata:
```

### Multi-stage Build

```dockerfile
# Build stage
FROM node:18 AS builder

WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Production stage
FROM nginx:alpine

COPY --from=builder /app/dist /usr/share/nginx/html

EXPOSE 80
```

---

## 🎓 Metodología de Aprendizaje

### 1. Leer la Teoría
Cada tema comienza con una explicación clara del concepto.

### 2. Ver Ejemplos
Los ejemplos de código muestran la aplicación práctica.

### 3. Practicar
Los ejercicios te permiten aplicar lo aprendido.

### 4. Experimentar
Modifica los ejemplos para entender cómo funcionan.

---

## 🔧 Comandos Esenciales

### Gestión de Imágenes

```bash
# Listar imágenes
docker images

# Buscar imagen en Docker Hub
docker search nginx

# Eliminar imagen
docker rmi <image_id>

# Construir imagen
docker build -t mi-app .
```

### Gestión de Contenedores

```bash
# Ejecutar interactivo
docker run -it ubuntu bash

# Ejecutar con volumen
docker run -v /host:/container nginx

# Ver logs
docker logs <container_id>

# Ejecutar comando en contenedor running
docker exec -it <container_id> bash
```

### Redes y Volúmenes

```bash
# Crear red
docker network create mi-red

# Crear volumen
docker volume create mi-volumen

# Listar volúmenes
docker volume ls
```

---

## 📖 Recursos Adicionales

### Documentación Oficial

- [Docker Documentation](https://docs.docker.com/)
- [Docker Hub](https://hub.docker.com/)
- [Dockerfile Reference](https://docs.docker.com/engine/reference/builder/)

### Herramientas Recomendadas

- **Docker Desktop** - Interfaz gráfica oficial
- **Portainer** - Gestión visual de contenedores
- **Watchtower** - Actualización automática

### Comunidades

- [Docker Community](https://www.docker.com/community/)
- [Stack Overflow - Docker](https://stackoverflow.com/questions/tagged/docker)
- [Reddit r/docker](https://www.reddit.com/r/docker/)

---

## 💡 Consejos para Principiantes

1. **Empieza simple**: Usa imágenes oficiales primero.
2. **Entiende volúmenes**: Los datos persisten fuera del contenedor.
3. **Usa .dockerignore**: Como .gitignore pero para Docker.
4. **Nombra tus contenedores**: `--name` facilita la gestión.
5. **Limpia regularmente**: `docker system prune` libera espacio.

---

## ⚠️ Mejores Prácticas

### Seguridad

- No ejecutes como root
- Escanea imágenes con `docker scan`
- Usa secretos para datos sensibles

### Rendimiento

- Usa imágenes Alpine cuando sea posible
- Minimiza el número de capas
- Usa caché de build eficientemente

### Producción

- Usa tags específicos, no `latest`
- Implementa health checks
- Configura restart policies

---

## 🧪 Ejercicios Prácticos

### Nivel Básico

1. Ejecuta tu primer contenedor Nginx
2. Crea un contenedor interactivo Ubuntu
3. Expón un puerto y accede al servicio

### Nivel Intermedio

1. Crea tu propio Dockerfile
2. Configura volúmenes persistentes
3. Usa Docker Compose con 2 servicios

### Nivel Avanzado

1. Implementa multi-stage build
2. Crea red personalizada entre contenedores
3. Deploy de aplicación completa con CI/CD

---

## 👨‍💻 Desarrollado por Isaac Esteban Haro Torres

**Ingeniero en Sistemas · Full Stack · Automatización · Data**

- 📧 Email: zackharo1@gmail.com
- 📱 WhatsApp: 098805517
- 💻 GitHub: https://github.com/ieharo1
- 🌐 Portafolio: https://ieharo1.github.io/portafolio-isaac.haro/

---

© 2026 Isaac Esteban Haro Torres - Todos los derechos reservados.
