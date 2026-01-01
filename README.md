# Smart Program: VR / AR / XR Tech for Virtual Learning Spaces (Summer 2024)

## Overview
This repository contains a **Summer 2024 exploratory project** focused on building a **Unity-based XR (VR/AR/MR) learning environment**, with early experimentation in:

- Interactive 3D environments (VR/AR/XR)
- Hardware interaction via serial communication
- Conceptual integration of **Generative AI (LLMs)** for user assistance
- Scanned environments and assets for immersive learning spaces

The project was developed as a **research and prototyping effort**, not a production-ready system.



## Project Goals
The original goals of this project were to explore:

1. **XR Learning Environments**
   - Build interactive VR/AR scenes in Unity
   - Enable object manipulation and task-based learning scenarios

2. **Hands-On Interaction**
   - Simulate electronics concepts (breadboards, wires, resistors)
   - Explore external hardware input via serial communication

3. **Generative AI Assistance (Exploratory)**
   - Investigate how a large language model (LLM) could provide
     contextual, real-time guidance inside a Unity XR environment

4. **Environment Capture & Assets**
   - Use scanned datasets (e.g., Scaniverse) to create realistic learning spaces

> ⚠️ **Important:**  
> Not all goals were fully implemented end-to-end. This repository reflects **experimentation, partial implementations, and proof-of-concept work** completed during a limited summer timeframe.



## Repository Structure

```
.
├── vr_unity/                 # Main Unity VR/XR project
├── unity-llama-scripts/      # Experimental Unity ↔ LLM integration scripts
├── unity_serial_comm/        # Unity serial communication experiments
├── Scaniverse_Dataset/       # Scanned environment assets
├── wire_*_script.cs          # Wire interaction logic (Unity C#)
├── resistor_*_script.cs      # Resistor interaction logic
├── breadboard_row_script.cs  # Breadboard simulation logic
├── AR-XR-VR-Gen-AI-block-diagram_pipeline.*
└── README.md
```



## What Is Implemented

### ✅ Unity XR Interaction (Partial)
- Unity C# scripts for interactive components
- Object-level logic for electronics concepts (wires, resistors, breadboards)
- Scene-level interaction suitable for VR/XR experimentation

### ✅ Hardware Communication (Exploratory)
- Serial communication scripts intended for:
  - External devices
  - Gloves / controllers / microcontrollers
- Focused on **data flow**, not finalized hardware integration

### ✅ Dataset & Environment Assets
- Included scanned assets for immersive environments
- Intended for use as XR learning spaces



## What Is Exploratory / Incomplete

### ⚠️ Generative AI Integration
- Scripts exist for **Unity ↔ LLM communication experiments**
- No guaranteed:
  - Real-time streaming
  - Production inference pipeline
  - Fully deployed LLaMA runtime
- Intended as a **conceptual and architectural exploration**

### ⚠️ Meta Quest / AR Deployment
- Unity project supports XR concepts
- Full deployment pipeline to Meta Quest devices may require:
  - Additional SDK setup
  - Platform-specific configuration
  - Build validation

### ⚠️ Computer Vision & Gloves
- Hand tracking / glove support was explored conceptually
- No finalized CV pipeline or glove SDK integration is guaranteed



## Intended Use
This repository is best viewed as:

- A **research prototype**
- A **learning and experimentation sandbox**
- A **foundation for future XR + AI projects**

It is **not** a turnkey product or finished training system.



## How to Use

1. Open the Unity project inside `vr_unity/`
2. Review individual C# scripts to understand interaction logic
3. Treat AI and hardware folders as **experimental references**
4. Extend or refactor as needed for your own XR research



## Limitations
- No single “run this and it works” pipeline
- Minimal documentation for setup dependencies
- No packaged builds or releases
- AI, CV, and hardware components are **not fully integrated**



## Future Improvements
- Formal XR platform targeting (Quest / OpenXR)
- Clear AI backend (local or cloud inference)
- Robust hardware abstraction layer
- Task-driven learning scenarios
- Documentation + demo recordings



## Acknowledgment
This project represents a **time-boxed academic exploration**.  
Its value lies in **concept validation, learning outcomes, and architectural groundwork**, rather than completeness.


