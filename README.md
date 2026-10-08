# Roll-a-Ball — 3D Unity Academic Project

[![Unity](https://img.shields.io/badge/Engine-Unity%203D-black?logo=unity&logoColor=white)](https://unity.com/)
[![Language](https://img.shields.io/badge/Language-C%23-239120?logo=csharp&logoColor=white)](https://docs.microsoft.com/dotnet/csharp/)
[![Physics](https://img.shields.io/badge/Physics-PhysX%20%2F%20Rigidbody-blue)](#gameplay--mechanics)
[![Course](https://img.shields.io/badge/Course-PSM%20(Lab%2002)-informational)](#academic-context)

A 3D physics-based arcade game developed in Unity as part of the academic coursework for the **PSM** (*Programowanie Systemów Multimedialnych*) laboratory classes.

---

## 🌐 Language / Język
- [🇬🇧 English](#-english-version)
- [🇵🇱 Polski](#-wersja-polska)

---

## 🇬🇧 English Version

### About the Project
This repository contains the laboratory implementation of the classic **Roll-a-Ball** prototype built with **Unity** and **C#**. The primary objective was to master fundamental game development workflows, 3D vector mathematics, rigid-body physics simulation, dynamic user interfaces, and modular component architecture.

### Gameplay & Mechanics
- **Physics-Based Movement:** Player sphere is controlled using input axes applying forces (`Rigidbody.AddForce`) within a 3D environment.
- **Dynamic Camera Follow:** Custom camera controller script maintaining a calculated offset relative to the player sphere.
- **Collectible System:** Rotating pickup prefabs (`Transform.Rotate`) detected via non-blocking trigger colliders (`OnTriggerEnter`).
- **Game State & UI HUD:** Real-time score counting and win condition feedback rendered through the Unity UI Canvas system.
- **Playfield Boundaries:** Box and mesh colliders preventing the sphere from leaving the designated arena.

### Controls
| Action | Key / Input |
| :--- | :--- |
| **Move Forward / Backward** | `W` / `S` or `Up` / `Down` Arrow |
| **Move Left / Right** | `A` / `D` or `Left` / `Right` Arrow |

### Tech Stack
- **Game Engine:** Unity (3D Core)
- **Programming Language:** C#
- **Physics Engine:** Unity Built-in 3D Physics (PhysX)
- **UI System:** Unity UI (uGUI / TextMeshPro)
