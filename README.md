# Inspector Script
Lua-powered, ultra-fast micro scripts in the Unity Inspector

| :warning: Please note           |
|:----------------------------|
| This package has a UPM dependency on a [UPM fork of MoonScript by k0dep](https://github.com/k0dep/MoonSharp/). |
| If this package becomes unavailable, you don't trust it, or any other reason, feel free to switch this out for any other implementation of MoonScript |

# 1. Installation

This repository is set up to be Unity Package Manager compatible.
To install via the Package Manager:
1. Open Package Manager window in your Unity Editor.
2. Click the '+' icon in the top left and select 'Add package from git URL...'
3. Enter 'https://github.com/Talsidor/inspector-script.git' and click Add.
4. Confirm you can now use Inspector Script by opening the 'Examples' scene, or adding an Inspector Script component to a Game Object.

## 1.1. Compatibility

Inspector Script should work in any version of Unity that supports MoonScript and the Unity Package Manager.
But it was built in, and so far as only been tested in, Unity 2022.3.

----

# 2. Example Scene

The 'Examples' scene included in this package contains 5 examples of Inspector Script's functionality. Open and run the scene to see the scripts in motion, and select each of the Cube objects under the `[Examples]` scene object to see their scripts.

Try making some changes to these scripts! Changes made in Play Mode will take effect immediately, but beware that like all Unity objects, changes made during Play Mode will be lost when leaving Play Mode.

----

# 3. Getting Started

## 3.1. Supported object properties:
- 'pos' - this object's local position
- 'rot' - this object's local rotation (in euler angles)
- 'scale' - this object's local scale

All three of these properties are Vector3s. Like with regular Unity Vector3s, you can get each axis with '.x', '.y', and '.z'. But unlike usual Transform Vector3s, you can also set these values.

### Examples

Get value: 
`var x = pos.x`
Set value: 
`rot.x = 5`
Increment value:
`scale.y = scale.y + 0.1`

## 3.2. Available Unity properties:
- 'time' - seconds since play started
- 'delta' - fraction of time taken by this frame

### Examples

Move forward at one unit per second
`pos.z = pos.z + delta`
Make Y position equal to seconds elapsed
`pos.y = time`

## 3.3. Lua functions confirmed working:
- 'print(x)' - Routed to log the passed argument to the Unity Debug Console
- 'math.sin(x)' - Can be used for sine wave functionality directly in Lua
- if statements - See example either below or in the 'Examples' scene

### Examples

Log value of z position every frame
`print(pos.z)`
Oscillate x between -1 and 1 once per second
`pos.x = math.sin(time)`
If statement
```
if (pos.y < -10) then
  pos.y = 0
end
```

To learn more about the Lua interpreter backing Inspector Script, check out MoonScript's [Getting Started](https://www.moonsharp.org/getting_started.html) guide.