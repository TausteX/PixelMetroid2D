# Pixel Metroid 2D

Juego de plataformas 2D desarrollado en Unity.

## Controles

| Acción | Tecla |
|--------|-------|
| Moverse izquierda | A / ← |
| Moverse derecha | D / → |
| Saltar | Space |
| Disparar | Right Control |

## Características

- Movimiento y salto del personaje
- Sistema de disparo
- Enemigos con patrón de patrulla
- Coleccionables
- Sistema de puntuación
- Cambio de escenas (niveles)
- Generación automática de plataformas

## Estructura

```
Assets/
└── Scripts/
    ├── PlayerController.cs   - Control del jugador
    ├── Disparo.cs            - Sistema de disparo
    ├── Bala.cs               - Comportamiento de balas
    ├── Enemigo.cs            - Enemigos
    ├── Coleccionable.cs      - Objetos recopilables
    ├── CambioEscena.cs       - Transición entre niveles
    ├── GeneradorPlataformas.cs - Generador de plataformas
    └── Puntaje.cs            - Sistema de puntuación
```

## Configuración

1. Añadir escenas en **File > Build Settings**
2. Configurar tags en **Edit > Project Settings > Tags and Layers**
3. Crear prefabs de balas y asignar en el script Disparo
4. Configurar UI para puntuación

## Documentación

Ver [DOCUMENTACION.md](./DOCUMENTACION.md) para información detallada.

## Licencia

MIT