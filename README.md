# Climate Surface Heating Simulation (Unity)

This is a small school project built in Unity as part of a _Seminarkurs_ (project seminar) in the German upper secondary school system. It visualizes how different objects heat up and cool down over the course of a simulated day–night cycle.

## What it does

- Simulates a **moving sun** using a rotating light source (`DayCycle`), producing a time-of-day dependent "sun strength" multiplier.
- Treats each object in the scene as a **simulation element** (`Objects`), with its own temperature, surface area, and material-based heating factor.
- Calculates the **surface area** of each mesh (`SurfaceCalculater`) so that larger objects heat more slowly than small ones for the same incoming energy.
- Continuously **heats up** objects during the day based on:
  - The current sun intensity (`DayCycle.DaytimeMultiplier`)
  - A material-specific **heating factor**
  - The object's **surface area**
  - The number of sun rays cast in the scene
- Continuously **cools down** objects based on the temperature difference between the object and the **surrounding air temperature**.
- Tracks and updates a **global surrounding temperature** in the `gameController`, which all objects use as their cooling reference.
- Visualizes temperature by **coloring each object** using a gradient from cold to hot.

## Main features

- Simple **climate / heat exchange simulation** with:
  - Per-object temperature
  - Material-based heating factor
  - Cooling proportional to temperature difference to the environment
- **Automatic setup**: the `gameController` finds all objects tagged as `SimulationObjects` and attaches the simulation scripts.
- **Mesh-based surface area calculation**, not just a fixed value.
- **Visual feedback** through a temperature gradient, making it easy to see which objects heat up more and faster.

## Notes

Everything was put together a bit scrappily, but it was a fun small school project to explore basic ideas behind heat, materials, and environmental cooling in a visual way.

## Background: Seminarkurs

This project was created as part of a _Seminarkurs_, a longer-term project seminar in the German **gymnasiale Oberstufe**. In a Seminarkurs, students plan and carry out an independent project over several semesters, usually combining:

- a written report or documentation,
- a practical or experimental component (like this Unity simulation), and
- a presentation or colloquium.

The goal is to practice working in a more scientific / academic way, managing a project over time, and presenting the results at the end.
