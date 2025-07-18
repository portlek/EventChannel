# EventChannel for Unity

A simple and effective Event Channel library for Unity, designed to decouple different parts of your game and improve modularity. This pattern uses ScriptableObjects as communication channels, allowing GameObjects to subscribe to and broadcast events without needing direct references to each other.

## Core Concepts

The library is built around two key components:

-   **`EventChannel<T>`**: A `ScriptableObject` that acts as the communication channel. You create instances of these in your project assets. They carry a payload of a specific type (`T`), like `string`, `int`, `bool`, or your own custom classes.
-   **`EventListener<T>`**: A `MonoBehaviour` component that you add to GameObjects in your scene. It listens to a specific `EventChannel` and invokes a `UnityEvent` when the channel fires an event.

## How to Use

### 1. Create an Event Channel

First, you need to create a channel asset. These are specialized `ScriptableObject` assets for different data types.

-   In the Project window, right-click and go to **Create > Events Channels**.
-   Select the type of channel you want to create (e.g., `string`, `integer`, `float`).
-   Name the new asset something descriptive, like `OnPlayerScored` or `OnGameStarted`.

### 2. Listen to the Channel

Next, set up a listener in your scene.

-   Select a GameObject that should react to an event (e.g., a UI Text element that displays the score).
-   Click **Add Component** and search for the corresponding `EventListener` (e.g., `EventListenerInteger`).
-   In the Inspector for the `EventListener`, drag your newly created `EventChannel` asset into the `Event Channel` field.
-   Configure the `Unity Event ()` section. Drag the component that has the function you want to execute (e.g., the `Text` component) into the object field and select the public function to call (e.g., `Text.text`).

### 3. Fire an Event from Code

Finally, you need a script to fire the event.

-   Create a new C# script (e.g., `PlayerController`).
-   Create a public field for your `EventChannel`.
-   Drag your `EventChannel` asset onto this field in the Inspector.
-   Call the `Fire()` method on the channel whenever you want to trigger the event.

**Example: Firing a score event**

```csharp
using UnityEngine;
using EventChannel; // Don't forget to import the namespace

public class PlayerController : MonoBehaviour {
    // Assign this in the Inspector
    public EventChannelInteger onPlayerScored;

    private int score = 0;

    public void AddScore(int amount) {
        score += amount;
        // Fire the event and pass the new score as the payload
        if (onPlayerScored != null) {
            onPlayerScored.Fire(score);
        }
    }
}
```

## Creating Custom Channels

You can easily create new types of channels and listeners for your own data structures.

**1. Create the Channel Script:**

```csharp
// Assets/Scripts/Events/EventChannelMyCustomData.cs
using UnityEngine;
using EventChannel;

[CreateAssetMenu(menuName = "Events/MyCustomData Channel")]
public class EventChannelMyCustomData : EventChannel<MyCustomData> {}
```

**2. Create the Listener Script:**

```csharp
// Assets/Scripts/Events/EventListenerMyCustomData.cs
using EventChannel;

public class EventListenerMyCustomData : EventListenerSerializedField<MyCustomData> {}
```

**3. Create your Data Class:**

```csharp
public class MyCustomData {
    public string playerName;
    public int score;
}
```

Now you can create `MyCustomData` channels from the `Assets/Create` menu and use the `EventListenerMyCustomData` component just like the built-in types.

## Installation

You can install this library as a Unity package directly from this Git repository.

In Unity, open the **Package Manager** (`Window > Package Manager`), click the `+` icon, select **"Add package from git URL..."**, and paste the following URL:

```
https://github.com/portlek/EventChannel.git?path=Assets
```