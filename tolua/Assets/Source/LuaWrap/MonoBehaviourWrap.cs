﻿using UnityEngine;
using System.Collections;
using System;
using LuaInterface;

public class MonoBehaviourWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Invoke", Invoke),
		new LuaMethod("InvokeRepeating", InvokeRepeating),
		new LuaMethod("CancelInvoke", CancelInvoke),
		new LuaMethod("IsInvoking", IsInvoking),
		new LuaMethod("StartCoroutine", StartCoroutine),
		new LuaMethod("StartCoroutine_Auto", StartCoroutine_Auto),
		new LuaMethod("StopCoroutine", StopCoroutine),
		new LuaMethod("StopAllCoroutines", StopAllCoroutines),
		new LuaMethod("print", print),
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("useGUILayout", get_useGUILayout, set_useGUILayout),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object obj = null;

		if (count == 0)
		{
			obj = new MonoBehaviour();
			LuaScriptMgr.PushResult(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.New");
		}

		return 0;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "MonoBehaviour", typeof(MonoBehaviour), regs, fields, "Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useGUILayout(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name useGUILayout");
		}

		MonoBehaviour obj = (MonoBehaviour)o;
		LuaScriptMgr.PushResult(L, obj.useGUILayout);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useGUILayout(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name useGUILayout");
		}

		MonoBehaviour obj = (MonoBehaviour)o;
		obj.useGUILayout = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Invoke(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
		string arg0 = LuaScriptMgr.GetString(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.Invoke(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InvokeRepeating(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
		string arg0 = LuaScriptMgr.GetString(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		obj.InvokeRepeating(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CancelInvoke(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
			obj.CancelInvoke();
			return 0;
		}
		else if (count == 2)
		{
			MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			obj.CancelInvoke(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.CancelInvoke");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsInvoking(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
			bool o = obj.IsInvoking();
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else if (count == 2)
		{
			MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			bool o = obj.IsInvoking(arg0);
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.IsInvoking");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(MonoBehaviour), typeof(string)};
		Type[] types1 = {typeof(MonoBehaviour), typeof(IEnumerator)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Coroutine o = obj.StartCoroutine(arg0);
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
			IEnumerator arg0 = (IEnumerator)LuaScriptMgr.GetNetObject(L, 2);
			Coroutine o = obj.StartCoroutine(arg0);
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else if (count == 3)
		{
			MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object arg1 = (object)LuaScriptMgr.GetNetObject(L, 3);
			Coroutine o = obj.StartCoroutine(arg0,arg1);
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.StartCoroutine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartCoroutine_Auto(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
		IEnumerator arg0 = (IEnumerator)LuaScriptMgr.GetNetObject(L, 2);
		Coroutine o = obj.StartCoroutine_Auto(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopCoroutine(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(MonoBehaviour), typeof(IEnumerator)};
		Type[] types1 = {typeof(MonoBehaviour), typeof(string)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
			IEnumerator arg0 = (IEnumerator)LuaScriptMgr.GetNetObject(L, 2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			obj.StopCoroutine(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MonoBehaviour.StopCoroutine");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopAllCoroutines(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MonoBehaviour obj = (MonoBehaviour)LuaScriptMgr.GetNetObject(L, 1);
		obj.StopAllCoroutines();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int print(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object arg0 = (object)LuaScriptMgr.GetNetObject(L, 1);
		MonoBehaviour.print(arg0);
		return 0;
	}
}
