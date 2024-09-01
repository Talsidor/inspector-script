using System;
using UnityEngine;
using UnityEngine.Serialization;
using MoonSharp.Interpreter;

public partial class InspectorScript : MonoBehaviour
{
	[SerializeField]
	DocoHeader _openForQuickReference = new();

	[SerializeField]
	[TextArea(1, 50)]
	string _start;

	[SerializeField]
	[TextArea(1, 50)]
	[FormerlySerializedAs("_input")]
	string _update;

	Script _session;

	#region UNITY MESSAGES

	void Awake()
	{
		Init();
	}

	void Start()
	{
		if (_start == null)
			return;

		_session.DoString(_start, codeFriendlyName: gameObject.name);
	}

	void Update()
	{
		_session.Globals[ "time"] = Time.time;
		_session.Globals["delta"] = Time.deltaTime;

		if (_update == null)
			return;

		_session.DoString(_update, codeFriendlyName: gameObject.name);
	}

	#endregion UNITY MESSAGES

	void Init()
	{
		_session = new Script();

		// Routes any calls to Lua's 'print' function to Unity's Debug Console
		_session.Options.DebugPrint = s => { Debug.LogFormat(this, $"Lua print: {0}", s); };

		UserData.RegisterType<Vec3>();

		_session.Globals[ "time"] = Time.time;
		_session.Globals["delta"] = Time.deltaTime;

		_session.Globals[  "pos"] = new Vec3(() => transform.localPosition	 , v => transform.localPosition	   = v);
		_session.Globals[  "rot"] = new Vec3(() => transform.localEulerAngles, v => transform.localEulerAngles = v);
		_session.Globals["scale"] = new Vec3(() => transform.localScale		 , v => transform.localScale	   = v);
	}
}
