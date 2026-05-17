# Pixel Metroid 2D - Documentación

## Índice
1. [Descripción del Proyecto](#descripción-del-proyecto)
2. [Controles](#controles)
3. [Scripts del Juego](#scripts-del-juego)
4. [Configuración en Unity](#configuración-en-unity)
5. [Estructura del Proyecto](#estructura-del-proyecto)

---

## Descripción del Proyecto

Pixel Metroid 2D es un juego de plataformas tipo metroidvania desarrollado en Unity. El jugador controla a un personaje que debe moverse, saltar, disparar y recoger coleccionables mientras evita enemigos.

---

## Controles

| Acción | Tecla |
|--------|-------|
| Moverse izquierda | A o ← |
| Moverse derecha | D o → |
| Saltar | Space |
| Disparar | Right Control |

### Control Táctil (Móvil)
- Botones UI para movimiento, salto y disparo
- Configurar en Canvas > UI Buttons

---

## Scripts del Juego

### PlayerController.cs
Controla el movimiento del jugador.

**Variables públicas:**
- `velocidad` - Velocidad de movimiento (default: 5)
- `fuerzaSalto` - Fuerza del salto (default: 10)

**Métodos públicos:**
- `Saltar()` - Ejecuta el salto
- `MoverDerecha()` - Mueve a la derecha
- `MoverIzquierda()` - Mueve a la izquierda
- `DetenerMovimiento()` - Detiene el movimiento
- `Morir()` - Mata al jugador
- `RecargarEscena()` - Reinicia la escena

---

### Disparo.cs
Gestiona el sistema de disparo del jugador.

**Variables públicas:**
- `balaPrefab` - Prefab de la bala
- `puntoDisparo` - Punto donde aparece la bala
- `velocidadBala` - Velocidad de la bala (default: 15)

**Métodos públicos:**
- `Disparar()` - Crea una bala y la lanza hacia arriba

---

### Bala.cs
Comportamiento de las balas disparadas.

**Funcionalidad:**
- Se destruye al tocar enemigos (los elimina)
- Se destruye al tocar paredes u otros objetos
- No afecta al jugador que la disparó

---

### Enemigo.cs
Gestiona el comportamiento de los enemigos.

**Variables públicas:**
- `velocidad` - Velocidad de movimiento (default: 2)
- `distanciaPatrulla` - Distancia antes de girar (default: 3)

**Comportamiento:**
- patrulla de izquierda a derecha
- Al tocar al jugador, lo mata
- Al recibir una bala, muere y otorga 10 puntos

---

### Coleccionable.cs
Objetos que el jugador puede recoger.

**Variables públicas:**
- `puntosRecompensa` - Puntos otorgados al recoger (default: 5)
- `sonidoRecoger` - Sonido al recoger el objeto

**Funcionalidad:**
- Añade puntos al contador
- Reproduce sonido (si está asignado)
- Se destruye al ser recogido

---

### CambioEscena.cs
Permite cambiar de nivel al llegar a una puerta/meta.

**Variables públicas:**
- `nombreSiguienteEscena` - Nombre de la escena a cargar

**Funcionalidad:**
- Detecta cuando el jugador entra en el trigger
- Carga la siguiente escena

---

### GeneradorPlataformas.cs
Genera plataformas automáticamente al iniciar el juego.

**Variables públicas:**
- `numeroPlataformas` - Cantidad de plataformas (default: 10)
- `distanciaHorizontal` - Espacio entre plataformas (default: 3)
- `alturaSuelo` - Altura de las plataformas (default: -2)
- `anchoPlataforma` - Ancho de cada plataforma (default: 3)

---

### Puntaje.cs
Gestiona la puntuación del juego.

**Variables públicas:**
- `textoPuntaje` - Componente Text para mostrar puntos
- `textoGameOver` - Objeto con texto de Game Over

**Métodos:**
- `AgregarPuntos(int cantidad)` - Añade puntos
- `ObtenerPuntos()` - Devuelve los puntos actuales
- `Reiniciar()` - Reinicia la puntuación
- `MostrarGameOver()` - Muestra el mensaje de fin de juego

**Instancia singleton:** `Puntaje.Instance`

---

## Configuración en Unity

### Player (Jugador)
1. Crear un GameObject con Sprite
2. Añadir **Rigidbody2D**:
   - Freeze Rotation Z
   - Collision Detection: Continuous
3. Añadir **BoxCollider2D** o **CapsuleCollider2D**
4. Asignar tag: **"Player"**
5. Añadir scripts: **PlayerController**, **Disparo**
6. Crear un hijo Empty como **puntoDisparo** (posición donde sale la bala)

### Plataformas/Suelo
1. Crear objeto con Sprite y **BoxCollider2D**
2. Asignar tag: **"Suelo"** o **"Plataforma"**

### Bala (Prefab)
1. Crear objeto pequeño con Sprite
2. Añadir **Rigidbody2D** (Gravity Scale: 0)
3. Añadir **BoxCollider2D** (Is Trigger: true)
4. Asignar tag: **"Bala"**
5. Añadir script **Bala**
6. Arrastrar a carpeta Prefabs

### Enemigo
1. Crear objeto con Sprite
2. Añadir **Rigidbody2D** (Is Kinematic: true)
3. Añadir **BoxCollider2D**
4. Asignar tag: **"Enemigo"**
5. Añadir script **Enemigo**

### Coleccionable
1. Crear objeto (moneda, gema, etc.)
2. Añadir **BoxCollider2D** (Is Trigger: true)
3. Añadir script **Coleccionable**
4. Opcional: asignar sonido en inspector

### UI (Puntaje)
1. **Canvas** > UI > Text (para puntuación)
2. Crear GameObject vacío, añadir script **Puntaje**
3. Arrastrar el Text al campo `textoPuntaje`

### Cambio de Escenas
1. Crear objeto (puerta/meta) con **BoxCollider2D** (Is Trigger: true)
2. Añadir script **CambioEscena**
3. Escribir nombre de la siguiente escena en `nombreSiguienteEscena`
4. Añadir escenas en **File > Build Settings > Add Open Scenes**

---

## Estructura del Proyecto

```
Assets/
├── Scripts/
│   ├── Bala.cs
│   ├── CambioEscena.cs
│   ├── Coleccionable.cs
│   ├── Disparo.cs
│   ├── Enemigo.cs
│   ├── GeneradorPlataformas.cs
│   ├── PlayerController.cs
│   └── Puntaje.cs
├── Prefabs/
│   ├── Bala.prefab
│   └── (otros prefabs)
├── Scenes/
│   ├── SampleScene.unity
│   └── (otros niveles)
├── Sprites/
│   └── (sprites del juego)
└── Sounds/
    └── (efectos de sonido)
```

---

## Tags Recomendados

| Tag | Uso |
|-----|-----|
| Player | Jugador |
| Suelo | Plataformas suelo |
| Plataforma | Plataformas flotantes |
| Enemigo | Enemigos |
| Bala | Proyectiles |

---

## Notas Importantes

1. **Input System**: El proyecto usa el nuevo Input System de Unity. Si hay errores, verificar en Project Settings > Player que "Active Input Handling" esté en "Both".

2. **Build Settings**: Para cambio de escenas, todas las escenas deben estar añadidas en File > Build Settings.

3. **Puntaje**: El script Puntaje es un singleton. Solo debe haber una instancia en la escena.

---

*Documentación generada para Pixel Metroid 2D*