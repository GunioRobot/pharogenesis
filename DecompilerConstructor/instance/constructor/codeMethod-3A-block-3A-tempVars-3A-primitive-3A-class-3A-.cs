codeMethod: selector block: block tempVars: vars primitive: primitive class: class

	| node |
	node _ self codeSelector: selector code: nil.
	tempVars _ vars.
	^MethodNode new
		selector: node
		arguments: (tempVars copyFrom: 1 to: nArgs)
		precedence: selector precedence
		temporaries: (tempVars copyFrom: nArgs + 1 to: tempVars size)
		block: block
		encoder: (Encoder new initScopeAndLiteralTables
					nTemps: tempVars size
					literals: literalValues
					class: class)
		primitive: primitive