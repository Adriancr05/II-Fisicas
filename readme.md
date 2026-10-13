# Práctica 3 - Físicas

# Ejercicio Físicas 3D – Rigidbody y Collider en Unity

Experimentos con distintas configuraciones de los componentes **Rigidbody** y **Collider** en Unity, explicando los resultados según lo visto en clase.

## Índice

- [Situación 1](#situación-1)
- [Situación 2](#situación-2)
- [Situación 3](#situación-3)
- [Situación 4](#situación-4)
- [Situación 5](#situación-5)
- [Situación 6](#situación-6)
- [Situación 7](#situación-7)
- [Situación 8](#situación-8)
- [Situación 9](#situación-9)
- [Conclusiones](#conclusiones)

## Situación 1

**Configuración**

| Objeto | Componentes |
|--------|-------------|
| Plano | Collider |
| Cubo | Collider + **Rigidbody** |
| Esfera | Collider |

**Resultado:** al darle al *Play* no ocurre nada visible. El cubo permanece sobre el plano y la esfera se queda flotando en el aire.

**Explicación:** el cubo es el único objeto con Rigidbody, así que es el único afectado por la gravedad, pero ya está apoyado sobre el plano (collider estático) y no cae. La esfera no tiene Rigidbody, por lo que el motor de físicas la trata como un objeto estático: la gravedad no actúa sobre ella y se queda en su posición.

> 📸 `![Situación 1](media/situacion1.gif)`

---

## Situación 2

**Configuración**

| Objeto | Componentes |
|--------|-------------|
| Plano | Collider |
| Cubo | Collider + **Rigidbody** |
| Esfera | Collider + **Rigidbody** |

**Resultado:** la esfera cae por la gravedad, impacta en el borde superior del cubo, lo empuja ligeramente en la dirección contraria y acaba rodando por el plano.

**Explicación:** ahora la esfera es un objeto físico y la gravedad la acelera. Como su centro está desplazado respecto al cubo, no se queda encima: al chocar con la arista superior del cubo, el motor de físicas calcula el choque entre ambos Rigidbody (con la misma masa, 1 kg por defecto) y se reparte el impulso. El cubo, al ser empujado, se desplaza o gira un poco, y la esfera sigue rodando hasta frenar por la fricción con el plano.

> 📸 `![Situación 2](media/situacion2.gif)`

---

## Situación 3

**Configuración**

| Objeto | Componentes |
|--------|-------------|
| Plano | Collider |
| Cubo | Collider + **Rigidbody** |
| Esfera | Collider + **Rigidbody** con **Is Kinematic ✔** |

**Resultado:** igual que en la Situación 1, no se mueve nada y la esfera sigue flotando.

**Explicación:** la esfera tiene Rigidbody, pero al ser cinemática la física no la controla: no le afecta la gravedad ni las fuerzas. Visualmente es igual que la Situación 1, pero la diferencia es importante: un objeto cinemático **puede moverse por script o animación** y, al hacerlo, empuja correctamente a los objetos dinámicos (como el cubo), mientras que mover un collider estático (sin Rigidbody) en tiempo de ejecución es ineficiente y no está recomendado.

> 📸 `![Situación 3](media/situacion3.gif)`

---

## Situación 4

**Configuración**

| Objeto | Componentes |
|--------|-------------|
| Plano | Collider + **Rigidbody** |
| Cubo | Collider + **Rigidbody** |
| Esfera | Collider + **Rigidbody** |

**Resultado:** los tres objetos caen indefinidamente hacia abajo, manteniendo prácticamente la misma posición relativa entre ellos.

**Explicación:** al darle Rigidbody (no cinemático) al plano, éste también obedece a la gravedad y cae, ya no actúa como suelo. Como todos los cuerpos caen con la misma aceleración (independientemente de su masa), plano, cubo y esfera caen a la vez sin separarse y no hay choques entre ellos. La esfera sigue sin llegar a golpear al cubo porque ambos caen juntos.

> ⚠️ **Nota:** el plano de Unity trae por defecto un `Mesh Collider` no convexo, que **no es compatible con un Rigidbody no cinemático**. Unity muestra un aviso en consola y la colisión no funciona correctamente. Para que el experimento tenga sentido hay que sustituirlo por un `Box Collider` (aplanado en Y) o similar.

> 📸 `![Situación 4](media/situacion4.gif)`

---

## Situación 5

**Configuración**

| Objeto | Componentes |
|--------|-------------|
| Plano | Collider + **Rigidbody** con **Is Kinematic ✔** |
| Cubo | Collider + **Rigidbody** (masa = 1) |
| Esfera | Collider + **Rigidbody** (masa = 10) |

**Resultado:** el plano se queda fijo. La esfera cae, golpea el borde del cubo y lo empuja con bastante más fuerza que en la Situación 2; el cubo se desplaza más lejos mientras que la esfera apenas se desvía de su trayectoria.

**Explicación:** el plano, al ser cinemático, no cae pero sigue funcionando como suelo sólido. La esfera cae a la misma velocidad que antes (la masa no influye en la caída), pero al chocar, la **masa sí influye**: al tener 10 veces más masa que el cubo, transmite mucho más impulso y sale poco frenada, mientras que el cubo, más ligero, acaba más desplazado y puede incluso volcar.

> 📸 `![Situación 5](media/situacion5.gif)`

---

## Situación 6

**Configuración**

| Objeto | Componentes |
|--------|-------------|
| Plano | Collider + **Rigidbody** con **Is Kinematic ✔** |
| Cubo | Collider + **Rigidbody** (masa = 1) |
| Esfera | Collider + **Rigidbody** (masa = 100) |

**Resultado:** la esfera casi no se ve afectada por el cubo: lo aplasta contra el plano y lo lanza lejos, con un movimiento más brusco que en la Situación 5.

**Explicación:** con una relación de masas de 100 a 1, el cubo es prácticamente un obstáculo "de papel" para la esfera, que conserva casi todo su movimiento y sigue su camino. El cubo recibe un impulso muy grande y sale despedido. Además, una diferencia de masas tan grande puede dar lugar a **inestabilidades del solver** de Unity (vibraciones, penetraciones momentáneas), que es una razón para evitar ratios de masa muy altos en los proyectos reales.

> 📸 `![Situación 6](media/situacion6.gif)`

---

## Situación 7

**Configuración**

| Objeto | Componentes |
|--------|-------------|
| Plano | Collider + **Rigidbody** |
| Cubo | Collider + **Rigidbody** |
| Esfera | Collider (con **Physic Material** con fricción) + **Rigidbody** |

**Resultado:** igual que en la Situación 4: los tres objetos caen juntos y la fricción de la esfera no se llega a apreciar.

**Explicación:** como el plano es un objeto físico no cinemático, cae por la gravedad y no hay un suelo que haga de superficie de contacto. La esfera tampoco llega a rozar con el cubo porque caen a la vez. La fricción solo actúa **cuando dos colliders están en contacto**, así que aquí no tiene efecto.

**Variante para observar la fricción** (plano cinemático, como en la Situación 5):

- **Fricción alta** (por ejemplo 1): la esfera "agarra" el cubo y el suelo, rueda en vez de deslizar, pierde velocidad rápidamente y se detiene antes.
- **Fricción 0**: la esfera desliza sin apenas rotar y recorre más distancia tras el choque.

> 📸 `![Situación 7](media/situacion7.gif)`

---

## Situación 8

**Configuración**

| Objeto | Componentes |
|--------|-------------|
| Plano | Collider + **Rigidbody** con **Is Kinematic ✔** |
| Cubo | Collider + **Rigidbody** |
| Esfera | Collider con **Is Trigger ✔** + **Rigidbody** con **Is Kinematic ✔** (no física) |

**Resultado:** no se mueve nada. El cubo sigue sobre el plano y la esfera flota.

**Explicación:** consideramos "no física" a la esfera como cinemática, por lo que no le afecta la gravedad. Además, al ser Trigger, su collider **no es sólido**: cualquier objeto que se mueva hacia ella la atravesaría sin rebotar, y lo único que ocurriría es que se dispararían los eventos `OnTriggerEnter`, `OnTriggerStay` y `OnTriggerExit`. Se cumple la condición para que se lancen eventos de trigger (al menos uno de los objetos tiene Rigidbody).

> 📸 `![Situación 8](media/situacion8.gif)`

---

## Situación 9

**Configuración**

| Objeto | Componentes |
|--------|-------------|
| Plano | Collider + **Rigidbody** con **Is Kinematic ✔** |
| Cubo | Collider + **Rigidbody** |
| Esfera | Collider con **Is Trigger ✔** + **Rigidbody** (no cinemático, con gravedad) |

**Resultado:** la esfera cae, atraviesa el cubo y el plano sin ser frenada y sigue cayendo indefinidamente. El cubo no se mueve.

**Explicación:** la esfera es física, así que la gravedad la acelera. Pero al ser Trigger no genera colisión sólida: pasa a través del cubo y del plano sin empujarlos ni rebotar. Lo único que sucede son los **eventos de trigger**: se llama a `OnTriggerEnter` al entrar en el cubo y en el plano, `OnTriggerStay` mientras los atraviesa y `OnTriggerExit` al salir.

> 📸 `![Situación 9](media/situacion9.gif)`

---

## Conclusiones

1. **Sin Rigidbody** un objeto es estático: bloquea a los demás pero no se ve afectado por la física.
2. **Con Rigidbody** el objeto responde a la gravedad y a las fuerzas; **con Is Kinematic**, solo se mueve por script o animación, pero sigue siendo sólido y empuja a los dinámicos.
3. Un **suelo** que deba permanecer fijo debe ser estático o cinemático, **nunca** un Rigidbody dinámico (se cae con todo lo demás).
4. La **masa** no afecta a la velocidad de caída, pero sí al resultado de los choques; ratios de masa muy grandes provocan comportamientos poco estables.
5. La **fricción** solo se nota cuando hay contacto entre colliders.
6. Un **Trigger** no genera colisión física: atraviesa y solo lanza eventos.

> ⚠️ Los resultados descritos son los esperados según el comportamiento del motor de físicas de Unity. Pequeñas variaciones (dirección en la que sale rodando la esfera, distancia a la que sale el cubo…) dependen de la versión de Unity y de los valores exactos de posición.
