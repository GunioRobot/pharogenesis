codeStringForPrimitives: classAndSelectorList
	"add the code for the setInterpreter() to the list"

	^super codeStringForPrimitives: (classAndSelectorList copyWith: #(InterpreterPlugin setInterpreter:))
