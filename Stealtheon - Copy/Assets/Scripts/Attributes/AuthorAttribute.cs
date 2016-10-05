using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class AuthorAttribute : Attribute
{
	string sayMyName;

	public AuthorAttribute (string sayMyName)
	{
		this.sayMyName = sayMyName;
	}

	public string SayMyName {
		get {
			return sayMyName;
		}
	}

	public override string ToString ()
	{
		string value = "Author : " + SayMyName;
		return  value;
	}
}