pushReceiverVariable: offset

	| var |
	(var _ instVars at: offset + 1 ifAbsent: []) == nil
		ifTrue:
			["Not set up yet"
			var _ constructor codeInst: offset.
			instVars size < (offset + 1) ifTrue: [
				instVars _ (Array new: offset + 1)
					replaceFrom: 1 to: instVars size with: instVars; yourself ].
			instVars at: offset + 1 put: var].
	stack addLast: var