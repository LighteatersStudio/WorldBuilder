# WorldBuilder (Unity UPM package)

This repository is structured as a UPM package (Unity Package Manager) so it can be added to Unity via a `git URL`.

## Installation

### 1) Install WorldBuilder

In Unity open **Package Manager** → **Add package from git URL...** and paste:

```
https://github.com/LighteatersStudio/WorldBuilder.git
```

To install a specific version, use a git tag (e.g. `v0.1.0`):

```
https://github.com/LighteatersStudio/WorldBuilder.git#v0.1.0
```

### 2) Install Extenject (Zenject)

Extenject is added as a git dependency via the **Project manifest**.
Add this to your Unity project's `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.svermeulen.extenject": "https://github.com/Mathijs-Bakker/Extenject.git?path=UnityProject/Assets/Plugins/Zenject/Source"
  }
}
```

## Samples

In Package Manager open **WorldBuilder** → **Samples** section → import **WorldBuilder Demo**.

## Package structure

- `Runtime/` — runtime code
- `Samples~/` — demo scene and assets
- `Documentation~/` — package documentation
