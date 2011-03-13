bindVariableUsesIn: aDictionary
	"Do NOT bind the variable on the left-hand-side of an assignment statement."
	"was bindVariablesIn:"
	expression _ expression bindVariableUsesIn: aDictionary.
