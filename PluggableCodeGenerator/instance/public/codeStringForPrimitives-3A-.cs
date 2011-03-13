codeStringForPrimitives: classAndSelectorList 
	self addClass: InterpreterPlugin.
	InterpreterPlugin declareCVarsIn: self.
	^super codeStringForPrimitives: classAndSelectorList 