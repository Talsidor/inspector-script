using System;
using UnityEngine;
using MoonSharp.Interpreter;

/// <summary>
/// Vector3 proxy class for Inspector Script, utilizing the MoonSharpUserData attribute.
/// Because the Vector3s of a Transform can't be ref'd, this uses a Func to retrieve the values and an Action to set them.
/// </summary>
[MoonSharpUserData]
internal class Vec3
{
	public Vec3(Func<Vector3> getFunc, Action<Vector3> setAction)
	{
		Get = getFunc;
		Set = setAction;
	}

	readonly Func  <Vector3> Get;
	readonly Action<Vector3> Set;

	public float x
	{
		get { return Get().x; }
		set 
		{
			var v = Get();
			v.x = value;
			Set(v);
		}
	}

	public float y
	{
		get { return Get().y; }
		set
		{
			var v = Get();
			v.y = value;
			Set(v);
		}
	}

	public float z
	{
		get { return Get().z; }
		set
		{
			var v = Get();
			v.z = value;
			Set(v);
		}
	}
}
