﻿namespace WellFormedNames
{
	public class InvalidVariableDefinitionException : Exception
	{
		public InvalidVariableDefinitionException(string str)
			: base(str + " is not a well formated variable definition")
		{
		}
	}
}