codeStringForPrimitives: classAndSelectorList 
"TPR - appears to be obsolete now"
	self addClass: InterpreterPlugin.
	InterpreterPlugin declareCVarsIn: self.
	^super codeStringForPrimitives: classAndSelectorList 