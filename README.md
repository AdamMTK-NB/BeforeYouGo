# Before You Go 🏥

> VR experience for pediatric patients — step into the doctor's shoes before your procedure.

Built solo in **48 hours** for the **CareXR Hackathon 2026** at Shriners Hospitals for Children, Montreal.

---

## What It Does

Before You Go is a Meta Quest 3 VR application that helps children aged 5–14 understand medical procedures before they happen — by letting them perform the procedure themselves as the doctor.

The child enters a calm hospital waiting room, selects a procedure card, and is transported to a hospital room where they are the doctor. Step-by-step instructions guide them through each interaction — picking up tools, walking to the patient, and completing the procedure. When they sit in the real chair minutes later, nothing is a surprise.

**Procedures implemented:**
- 💉 Blood Draw — pick up syringe, walk to patient, inject highlighted spot on arm
- 🩹 Dressing Change — remove old bandage, grab new bandage roll, apply to wound

---

## Features

- **Hospital lobby** — Waiting room environment with animated title, Start and How It Works screens
- **Procedure selection** — 5 comic-style procedure cards with fade transition
- **Blood Draw scene** — Grabbable syringe, glowing injection spot, patient model swap on completion
- **Dressing Change scene** — Clickable old bandage removal, grabbable bandage roll, arm mesh collider detection
- **Step-by-step UI** — Comic-style instruction images float at eye level and update with each action
- **Arrow pointer** — Bobbing cyan arrow guides player to the next object
- **Scene transitions** — Custom fade in/out system using a sphere renderer
- **Ambient audio** — Hospital background music + button click sounds
- **Controller interaction** — Full XR Ray Interactor setup for UI and 3D object interaction

---

## Tech Stack

| Layer | Technology |
|---|---|
| Engine | Unity 6.3 LTS |
| Headset | Meta Quest 3 (standalone, no PC required) |
| XR Framework | OpenXR + XR Interaction Toolkit 3.3.1 |
| Rendering | Universal Render Pipeline (URP) |
| Language | C# |
| UI | World Space Canvas + Tracked Device Graphic Raycaster |
| 3D Assets | Sketchfab + Unity Asset Store |
| Art | Gemini-generated comic/cartoon UI assets |
| Build Target | Android (ARM64, ASTC compression) |

---

## Project Structure
```
BeforeYouGo/
├── Assets/
│   ├── Audio/              # Ambient music, button click SFX, cheer sounds
│   ├── Images/             # Comic-style UI sprites (cards, instructions, title)
│   ├── Models/             # Hospital room, patient, syringe, bandage assets
│   ├── Resources/          # Materials (glow, fade sphere)
│   ├── Scenes/
│   │   ├── LobbyScene      # Main menu + procedure selection
│   │   ├── BloodDrawScene  # Blood draw procedure
│   │   └── DressingChangeScene  # Dressing change procedure
│   ├── Scripts/
│   │   ├── ArrowPointer.cs         # Bobbing arrow that points at target objects
│   │   ├── BloodDrawManager.cs     # Blood draw sequence controller
│   │   ├── BandageGrab.cs          # Bandage grab + arm activation
│   │   ├── DressingChangeManager.cs # Dressing change sequence controller
│   │   ├── FadeScreen.cs           # Fade in/out via sphere renderer
│   │   ├── FollowCamera.cs         # Instruction canvas follows player view
│   │   ├── GameStartMenu.cs        # Lobby menu controller
│   │   ├── ProcedureCard.cs        # Procedure card selection + scene load
│   │   ├── PulseGlow.cs            # Pulsing glow effect on interactable spots
│   │   ├── RemoveBandage.cs        # Old bandage click removal
│   │   ├── SceneTransitionManager.cs # Scene loading with fade
│   │   ├── StepManager.cs          # Step-by-step instruction image manager
│   │   └── SyringeGrab.cs          # Syringe grab + injection spot activation
│   └── Settings/           # URP render pipeline assets
├── Packages/
└── ProjectSettings/
```

---

## How to Install

### Requirements
- Meta Quest 3 headset
- Developer Mode enabled on headset
- ADB installed on your computer (via Android Studio or Platform Tools)

### Install via ADB
1. Clone the repo:
```bash
git clone https://github.com/AdamMTK-NB/BeforeYouGo.git
```

2. Connect Quest 3 via USB — accept the USB debugging prompt inside the headset

3. Install the APK:
```bash
adb install Builds/BeforeYouGo.apk
```

4. Find the app in your Quest library under **Unknown Sources**

---

## Building from Source

### Requirements
- Unity 6.3 LTS
- Android Build Support module
- OpenJDK (included with Unity Hub)
- Meta Quest Developer Hub (optional, for wireless deployment)

### Steps
1. Open project in Unity 6.3 LTS
2. **File → Build Settings** → select **Android** → Switch Platform
3. Connect Quest 3 via USB
4. **Build & Run** — Unity compiles and deploys directly to headset

### Key Unity Settings
- **XR Plug-in Management → Android** → OpenXR ✅
- **Interaction Profiles** → Meta Quest Touch Plus Controller ✅
- **Texture Compression** → ASTC
- **Scripting Backend** → IL2CPP
- **Target Architecture** → ARM64

---

## Challenges

**XR Interaction complexity** — Getting UI buttons, grabbable objects, and 3D interactables working simultaneously on the same controller required careful setup of Tracked Device Graphic Raycaster, XR Interaction Manager, and Input Action Manager together.

**48-hour solo scope** — Hard cuts were made throughout. Hand animations, biometric integration, and 3 additional procedure scenes were deferred in favor of a polished 2-procedure demo.

**Child-appropriate design** — Every instruction, interaction, and visual had to be friendly and non-threatening. The comic/cartoon visual language was iterated on multiple times.

---

## Author

**Adam Maatouk**
Computer Engineering student at Concordia University
[LinkedIn](https://linkedin.com) · [GitHub](https://github.com/YOURUSERNAME)

---

## License

Copyright © 2026 Adam Maatouk. All rights reserved.
