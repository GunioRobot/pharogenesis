codeMethod: selector block: block tempVars: vars primitive: primitive class: class

	| node methodTemps |
	node _ self codeSelector: selector code: nil.
	tempVars _ vars.
	methodTemps _ tempVars select: [:t | t scope >= 0].
	^MethodNode new
		selector: node
		arguments: (methodTemps copyFrom: 1 to: nArgs)
		precedence: selector precedence
		temporaries: (methodTemps copyFrom: nArgs + 1 to: methodTemps size)
		block: block
		encoder: (Encoder new initScopeAndLiteralTables
					temps: tempVars
					literals: literalValues
					class: class)
		primitive: primitive