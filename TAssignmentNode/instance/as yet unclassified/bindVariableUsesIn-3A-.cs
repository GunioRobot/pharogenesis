bindVariableUsesIn: aDictionary
	"Do NOT bind the variable on the left-hand-side of an assignment statement."

	expression _ expression bindVariablesIn: aDictionary.
