checkVariables
	"DynamicInterpreter checkVariables"

	| vars |
	vars _ IdentitySet new addAll: (
				ObjectMemory instVarNames ,
				DynamicContextCache instVarNames ,
				DynamicInterpreter instVarNames);
			yourself.
	(vars select: [:var | (ObjectMemory whichSelectorsAccess: var) isEmpty
							and: [(DynamicContextCache whichSelectorsAccess: var) isEmpty
							and: [(DynamicInterpreter whichSelectorsAccess: var) isEmpty]]])
		do: [:var | Transcript show: var; cr]