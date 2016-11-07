using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class AuthorAttribute : Attribute
{
	string sayMyName;

	public AuthorAttribute (string sayMyName, TeamRole role)
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
public enum TeamRole{
	Programmer,
	Designer,
	Animator,
	Writer,
	Miscellaneous,
	Foreign
}