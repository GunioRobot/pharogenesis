codeInst: index

	^VariableNode new
		name: (instVars at: index + 1 ifAbsent: ['unknown', index asString])
		index: index
		type: LdInstType