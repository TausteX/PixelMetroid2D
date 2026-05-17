# Pixel Metroid 2D - Documentación del Proyecto

---

## 1. Descripción del Proyecto

Pixel Metroid 2D es un juego de plataformas tipo metroidvania desarrollado en Unity como proyecto académico. El jugador controla a un explorador espacial que debe navegar por diferentes niveles, recoger objetos, disparar a enemigos y completar objetivos para avanzar en la historia.

---

## 2. Historia del Juego

### Trasfondo

En el año 2347, la humanidad ha colonizado múltiples planetas del sistema Alpha. El investigador espacial **Alex** es enviado al planeta-Xenon-7 para investigar una señal de origen desconocido proveniente de unas ruinas antiguas. Al descender en la superficie del planeta, Alex descubre que el lugar está infestado de criaturas mutantes protectoras de un artifacts tecnológico valioso.

La misión de Alex es sencilla en teoría: recuperar el artifacts y regresar a la nave. Sin embargo, los guardianes mecánicos y las criaturas del planeta no piensan dejarlo pasar tan fácilmente. Con su arsenal básico y sus habilidades de movimiento, Alex deberá abrirse camino a través de las ruinas, recoger potenciadores para mejorar sus capacidades y enfrentar al guardián final.

### Personaje Principal

- **Nombre:** Alex
- **Rol:** Explorador espacial / Investigador
- **Objetivo:** Recuperar el artifacts antiguo y escapar del planeta

---

## 3. Desarrollo del Proyecto - Paso a Paso

### Fase 1: Setup y Estructura Inicial
1. Crear proyecto Unity 2D con URP
2. Configurar carpetas del proyecto (Scripts, Prefabs, Scenes, Sprites, Sounds)
3. Añadir scripts básicos al repositorio Git

### Fase 2: Movimiento del Jugador
1. Crear script `PlayerController.cs` para movimiento y salto
2. Configurar Rigidbody2D y colliders
3. Implementar detección de suelo
4. Resolver problemas de Input System

### Fase 3: Sistema de Disparo
1. Crear script `Disparo.cs`
2. Crear prefab de Bala con `Bala.cs`
3. Configurar tags y capas
4. Ajustar dirección del disparo

### Fase 4: Enemigos y Puntuación
1. Crear script `Enemigo.cs` con patrón de patrulla
2. Crear script `Puntaje.cs` (singleton)
3. Integrar puntuación con muertes de enemigos y coleccionables

### Fase 5: Cambio de Escenas
1. Crear script `CambioEscena.cs`
2. Configurar Build Settings
3. Añadir transiciones entre niveles

### Fase 6: Mejoras Adicionales
1. Generador de plataformas (`GeneradorPlataformas.cs`)
2. Sistema de Game Over
3. Documentación completa

---

## 4. Controles

| Acción | Tecla |
|--------|-------|
| Moverse izquierda | A / ← |
| Moverse derecha | D / → |
| Saltar | Space |
| Disparar | Right Control |

### Control Táctil (Móvil)
- Botones UI para movimiento, salto y disparo
- Configurar en Canvas > UI > Buttons

---

## 5. Scripts del Juego - Documentación del Código

### PlayerController.cs
**Ubicación:** `Assets/Scripts/PlayerController.cs`

Controla el movimiento del jugador, salto y detección de suelo.

```csharp
public class PlayerController : MonoBehaviour
{
    // Variables configurables en Inspector
    public float velocidad = 5f;      // Velocidad de movimiento horizontal
    public float fuerzaSalto = 10f;   // Fuerza vertical del salto
    
    // Estado interno
    private Rigidbody2D rb;            // Componente física del jugador
    private bool enSuelo = true;      // Flag para detectar si está en el suelo
    private bool movimientoActivo = true;  // Flag para frozen en game over
}
```

**Métodos públicos:**
- `Saltar()` - Ejecuta el salto si el jugador está en el suelo
- `MoverDerecha()` - Mueve al jugador a la derecha
- `MoverIzquierda()` - Mueve al jugador a la izquierda
- `DetenerMovimiento()` - Detiene el movimiento horizontal
- `Morir()` - Mata al jugador, muestra Game Over
- `RecargarEscena()` - Reinicia la escena actual

**Métodos privados:**
- `OnCollisionEnter2D()` - Detecta colisión con suelo/plataformas
- `OnCollisionStay2D()` - Mantiene flag de suelo activo

---

### Disparo.cs
**Ubicación:** `Assets/Scripts/Disparo.cs`

Gestiona la creación y lanzamiento de proyectiles.

```csharp
public class Disparo : MonoBehaviour
{
    public GameObject balaPrefab;     // Prefab de la bala a instanciar
    public Transform puntoDisparo;    // Posición donde aparece la bala
    public float velocidadBala = 15f; // Velocidad del proyectil
}
```

**Métodos públicos:**
- `Disparar()` - Instancia la bala y la lanza hacia arriba

---

### Bala.cs
**Ubicación:** `Assets/Scripts/Bala.cs`

Comportamiento de las balas disparadas.

```csharp
public class Bala : MonoBehaviour
{
    // Se destruye al tocar cualquier cosa que no sea el jugador o otra bala
    // Al tocar un enemigo, destruye both (enemigo + bala)
}
```

**Funcionalidad:**
- Destrucción automática tras 2 segundos
- Detección de colisiones para destruir enemigos
- No afecta al jugador que la disparó

---

### Enemigo.cs
**Ubicación:** `Assets/Scripts/Enemigo.cs`

Gestiona el comportamiento de los enemigos con patrón de patrulla.

```csharp
public class Enemigo : MonoBehaviour
{
    public float velocidad = 2f;              // Velocidad de movimiento
    public float distanciaPatrulla = 3f;      // Distancia antes de girar
    
    private Vector2 puntoInicial;              // Punto de referencia para patrulla
    private int direccion = 1;                // 1 = derecha, -1 = izquierda
}
```

**Comportamiento:**
- Movimiento horizontal automático
- Cambio de dirección al llegar al límite de patrulla
- Invierte sprite al cambiar dirección
- Al colisionar con el jugador, llama a `Morir()`
- Al ser alcanzado por una bala, se destruye y otorga 10 puntos

---

### Coleccionable.cs
**Ubicación:** `Assets/Scripts/Coleccionable.cs`

Objetos que el jugador puede recoger para obtener puntos.

```csharp
public class Coleccionable : MonoBehaviour
{
    public int puntosRecompensa = 5;  // Puntos otorgados al recoger
    public AudioClip sonidoRecoger;    // Sonido opcional al recoger
}
```

**Funcionalidad:**
- Detecta colisión con el jugador (trigger)
- Añade puntos mediante `Puntaje.Instance.AgregarPuntos()`
- Reproduce sonido (si está asignado)
- Se destruye automáticamente tras ser recogido

---

### CambioEscena.cs
**Ubicación:** `Assets/Scripts/CambioEscena.cs`

Permite cambiar de nivel al llegar a una puerta o meta.

```csharp
public class CambioEscena : MonoBehaviour
{
    public string nombreSiguienteEscena;  // Nombre de la escena destino
}
```

**Funcionalidad:**
- Detecta trigger con el jugador
- Usa `SceneManager.LoadScene()` para cambiar de escena
- Necesita que las escenas estén añadidas en Build Settings

---

### GeneradorPlataformas.cs
**Ubicación:** `Assets/Scripts/GeneradorPlataformas.cs`

Genera plataformas automáticamente al iniciar el juego (útil para testing).

```csharp
public class GeneradorPlataformas : MonoBehaviour
{
    public int numeroPlataformas = 10;
    public float distanciaHorizontal = 3f;
    public float alturaSuelo = -2f;
    public float anchoPlataforma = 3f;
}
```

**Nota:** Para producción, usar plataformas diseñadas manualmente.

---

### Puntaje.cs
**Ubicación:** `Assets/Scripts/Puntaje.cs`

Gestiona la puntuación del juego (patrón Singleton).

```csharp
public class Puntaje : MonoBehaviour
{
    public static Puntaje Instance { get; private set; }  // Singleton
    public Text textoPuntaje;        // Referencia al UI Text
    public GameObject textoGameOver;  // Referencia al UI Game Over
}
```

**Métodos:**
- `AgregarPuntos(int cantidad)` - Añade puntos al contador
- `ObtenerPuntos()` - Devuelve puntuación actual
- `Reiniciar()` - Pone puntuación a 0
- `MostrarGameOver()` - Muestra pantalla de fin de juego
- `ActualizarUI()` - Actualiza el texto en pantalla

---

## 6. Dificultades Encontradas y Soluciones

### Dificultad 1: El personaje caía al iniciar el juego
**Problema:** No había suelo en la escena inicial.

**Solución:** Crear script `GeneradorPlataformas.cs` que genera plataformas automáticamente al Start.

---

### Dificultad 2: Input System incompatible
**Problema:** Error: "You are trying to read Input using the UnityEngine.Input class but you have switched active Input handling to Input System package"

**Solución:** Actualizar scripts para usar `Input.GetAxis("Horizontal")` y `Input.GetButtonDown("Jump")` en lugar del nuevo Input System, compatible con ambos modos.

---

### Dificultad 3: Error de método duplicado
**Problema:** Error CS0111: Type 'PlayerController' already defines a member called 'OnCollisionEnter2D'

**Solución:** Existían dos archivos (`PlayerController.cs` y `PlayerControler.cs`). Eliminé el archivo duplicado.

---

### Dificultad 4: Deprecated velocity
**Problema:** Warning CS0618: 'Rigidbody2D.velocity' is obsolete

**Solución:** Cambiar `velocity` por `linearVelocity` en todos los scripts.

---

### Dificultad 5: La bala disparaba en dirección incorrecta
**Problema:** La bala salía horizontalmente en lugar de hacia arriba

**Solución:** Modificar `Disparo.cs` para usar `new Vector2(0, velocidadBala)` en lugar de velocidad horizontal.

---

### Dificultad 6: Push a GitHub fallaba
**Problema:** No había credenciales configuradas

**Solución:** El usuario proporcionó un Personal Access Token (PAT) y se configuró el remote URL con las credenciales embebidas.

---

## 7. Capturas de Pantalla

> **Nota:** Las capturas de pantalla deben tomarse desde el Editor de Unity (modo Play) y desde un dispositivo real.

**Captura 1 - Editor Unity (Emulador):**
- [INSERTAR CAPTURA AQUÍ]
- *Incluir foto del perfil de GitHub en una esquina*

**Captura 2 - Dispositivo Móvil:**
- [INSERTAR CAPTURA AQUÍ]
- *Incluir foto del perfil de GitHub en una esquina*

---

## 8. Consideraciones para el Profesor

1. **Modularidad:** El código está estructurado en scripts independientes, facilitando la extensión y mantenimiento.

2. **Patrones utilizados:** Singleton (Puntaje), Componentes (cada script encapsula una funcionalidad).

3. **Escalabilidad:** El juego puede ampliarse fácilmente con:
   - Más tipos de enemigos
   - Mejoras de equipamiento
   - Niveles adicionales
   - Sistema de guardado

4. **Control táctil:** Preparado para implementación en dispositivos móviles mediante Canvas UI.

5. **GitHub:** Proyecto versionado con commits claros y documentación disponible.

---

## 9. Estructura del Proyecto

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
│   └── (prefabs del juego)
├── Scenes/
│   └── (escenas/niveles)
├── Sprites/
│   └── (gráficos)
└── Sounds/
    └── (audio)
```

---

## 10. Tags Recomendados

| Tag | Uso |
|-----|-----|
| Player | Jugador |
| Suelo | Plataformas suelo |
| Plataforma | Plataformas flotantes |
| Enemigo | Enemigos |
| Bala | Proyectiles |

---

## 11. Notas Importantes

1. **Input System**: El proyecto usa `Input.GetAxis()` que funciona con ambos sistemas (Legacy y Nuevo).

2. **Build Settings**: Para cambio de escenas, todas las escenas deben estar añadidas en File > Build Settings.

3. **Puntaje**: El script Puntaje es un singleton. Solo debe haber una instancia en la escena.

4. **GitHub**: Repositorio disponible en https://github.com/TausteX/PixelMetroid2D

---

*Documentación elaborada para la entrega del proyecto académico.*
*Autor: TausteX*
*Fecha: Mayo 2026*