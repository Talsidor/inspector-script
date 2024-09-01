#pragma warning disable CS0414 // Field assigned but not used
using System;
using UnityEngine;

/// <summary>
/// Container class for Inspector Script to display quick reference on each script instance.
/// </summary>
[Serializable]
internal class DocoHeader
{
	[SerializeField]
	[TextArea(30, 50)]
	string _doco = @"
1. supported object properties:
- 'pos' - this object's local position
- 'rot' - this object's local rotation (in euler angles)
- 'scale' - this object's local scale

access each axis with .x, .y, .z

# examples

get value: 
'var x = pos.x'
set value: 
'rot.x = 5'
increment value:
'scale.y = scale.y + 0.1'

2. supported unity properties:
- 'time' - seconds since play started
- 'delta' - fraction of time taken by this frame

# examples

move at one unit per second
'pos.x = pos.x + delta'
position equal to time elapsed
'pos.y = time'

3. example supported functions:
- 'print(x)' logs x to the unity console
- 'math.sin(x)' sine wave

# examples

log value of z position every frame
'print(pos.z)'
oscillate x between -1 and 1 once per second
'pos.x = math.sin(time)'
";

	[SerializeField]
	[TextArea(1, 50)]
	string _notes = "Put your own notes here :)";
}
