checkState		"DynamicInterpreter checkState"

	"Quick check for which instance variables in InterpreterState could be moved down to Interpreter"

	| classList varList okList |
	classList _ Set with: DynamicContextCache with: DynamicTranslator.
	varList _ DynamicInterpreterState instVarNames.
	okList _ varList asSet.
	classList do: [:cls |
		okList removeAll: (varList select: [:var | (cls whichSelectorsAccess: var) isEmpty not])].
	Transcript cr; cr; show: 'The following state is accessed only from within DynamicInterpreter:'; cr.
	Transcript show: okList printString.