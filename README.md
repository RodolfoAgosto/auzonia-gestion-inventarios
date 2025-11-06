# Auzonia - Gestión de Inventario

[![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-blue)](https://www.microsoft.com/en-us/sql-server)  
[![VB.NET](https://img.shields.io/badge/Backend-VB.NET-green)](https://docs.microsoft.com/en-us/dotnet/visual-basic/)  
[![Estado](https://img.shields.io/badge/Estado-Funcional-orange)](#estado-y-limitaciones)  

**Video de introducción:** [Ver presentación](https://www.youtube.com/watch?v=VhusjG-6ek4&t=83s)

---

## 🌟 Descripción General
Auzonia es un **sistema de escritorio avanzado para la gestión de inventarios**, diseñado para distribuidores y mayoristas de neumáticos. Permite controlar compras, entregas, valuación de inventario y reportes, con trazabilidad completa y seguridad robusta.  

> ⚠️ **Nota:** Proyecto funcional, pero **no sigue principios de código limpio ni refactorización profesional**.  

---

## 🏗 Tecnologías
- **Lenguaje:** VB.NET (Windows Forms / escritorio)  
- **Base de datos:** SQL Server (30 tablas normalizadas, >100 procedimientos almacenados)  
- **Patrones de diseño:** Composite, Observer  
- **Otros:** Multiidioma, generación de informes PDF, serialización JSON/XML, instalador con asistente  

---

## 🏛 Arquitectura
- Arquitectura de **7 capas** con más de 100 clases modulares  
- Separación clara de responsabilidades, fácil mantenimiento y escalabilidad  

---

## ⚙ Funcionalidades Clave

### 1️⃣ Gestión de Compras
- Circuito controlado de generación de notas de pedido  
- Cálculo automático de cantidades sugeridas según:  
  - Stock de seguridad  
  - Stock físico  
  - Pedidos pendientes de clientes y proveedores  
- Validación y ajuste de cantidades por el jefe de ventas  
- Generación de remitos y registro de recepción en depósito  

### 2️⃣ Gestión de Entregas
- Preparación, validación y despacho de pedidos  
- Control del stock físico y reservado, planificación de envíos  
- Generación de notas de envío y actualización de trazabilidad  
- Confirmación final de entrega por vendedor y registro automático de inventario  

### 3️⃣ Valuación de Inventario
- Métodos de valuación **FIFO** y **LIFO**  
- Cálculo del valor económico actualizado por artículo y consolidado  
- Integración con módulo contable para registro de movimientos  

### 4️⃣ Seguridad y Auditoría
- Autenticación segura, encriptación SHA1 y bloqueo automático de usuarios  
- Registro completo de sesiones y cambios críticos en la bitácora  

### 5️⃣ Permisos y Perfiles (Composite)
- Jerarquía de permisos y perfiles con herencia automática  
- Control granular por módulo y funcionalidad  
- Prevención de bucles infinitos en la jerarquía  

### 6️⃣ Multiidioma (Observer)
- Cambio dinámico de idioma en toda la interfaz (formulario principal y secundarios)  
- Patrón Observer para actualización inmediata de leyendas y títulos  
- Actualmente soporta **español** e **inglés**, con 244 mensajes traducibles  

### 7️⃣ Instalador y Ayuda en Línea
- Instalador con asistente guiado, framework integrado y carga inicial de datos  
- ToolTips y ayuda tipo árbol para navegación rápida y sencilla  

### 8️⃣ Informes y Exportación
- Generación de informes visuales, exportación a **PDF**, **JSON** y **XML**  
- Personalización según necesidades del usuario  

---

## 🗄 Base de Datos
- SQL Server con 30 tablas normalizadas  
- Más de 100 procedimientos almacenados  
- Validadores de integridad y módulo Backup/Restore  

---

## 🖥 Interfaz
- Windows Forms con diseño modular y organizado  
- Interfaz clara, accesible y escalable  

---

## 🎥 Videos de Demostración
- [Introducción a Auzonia](https://www.youtube.com/watch?v=VhusjG-6ek4&t=83s)  
- [Gestión de Compras](https://www.youtube.com/watch?v=ssGL0uKugoQ)  
- [Gestión de Entregas](https://www.youtube.com/watch?v=OQP8eX4zHcA)  
- [Valuación de Inventario](https://www.youtube.com/watch?v=Ox8pG_Y2T2U)  
- [Multiidioma + Patrón Observer](https://www.youtube.com/watch?v=hZbOHes4YaQ)  

---

## 📂 Estructura del Proyecto
